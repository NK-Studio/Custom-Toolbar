using System.Reflection;
using FMODUnity;
using NKStudio;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

internal static class FMODGUI
{
    /// <summary>
    /// FMOD 디버그 토글을 GUI에 추가합니다.
    /// </summary>
    /// <param name="element">추가할 VisualElement입니다.</param>
    internal static void OnGUI(VisualElement element)
    {
        var fmodDebugToggle = new Toggle
        {
            name = "FMODDebugToggle",
            text = "FMOD Debug"
        };

        var icon = new Image
        {
            style =
            {
                width = 54,
                height = 16
            }
        };

        // 아이콘 이미지 적용
        var iconPath = AssetDatabase.GUIDToAssetPath("f0de615af202e44a190b20daca134fc4");
        icon.image = AssetDatabase.LoadAssetAtPath<Texture2D>($"{iconPath}/{ToolbarUtility.DarkModePrefix}fmod.png");

        // 토글 맨 앞에 아이콘 추가
        fmodDebugToggle[0].Insert(0, icon);

        // 체크박스 위치 변경
        var checkmark = fmodDebugToggle[0].Q<VisualElement>("unity-checkmark");
        fmodDebugToggle[0].Remove(checkmark);
        fmodDebugToggle[0].Add(checkmark);

        // 마진 추가
        var label = fmodDebugToggle[0].Q<Label>();
        label.style.marginLeft = 4;
        label.style.marginRight = 4;

        // 초기 값 설정
        fmodDebugToggle.value = IsFMODDebugActive;
        
        // 플레이 중에는 비활성화
        fmodDebugToggle.SetEnabled(ToolbarUtility.IsNotPlaying);
        
        // 값 변경 이벤트 설정
        fmodDebugToggle.RegisterValueChangedCallback(evt =>
        {
            var newValue = evt.newValue;
            SetFMODDebugOverlay(newValue);
        });
        
        // 플레이 중에는 비활성화
        EditorApplication.playModeStateChanged += _ => fmodDebugToggle.SetEnabled(ToolbarUtility.IsNotPlaying);

        // 툴바에 추가
        element.Add(fmodDebugToggle);
    }

    /// <summary>
    /// FMOD 디버그가 활성화되어 있는지 확인합니다.
    /// </summary>
    private static bool IsFMODDebugActive => FMODDebugOverlay == TriStateBool.Enabled;

    /// <summary>
    /// FMOD 디버그 오버레이 값을 설정합니다.
    /// </summary>
    /// <param name="isEnabled">설정할 값입니다.</param>
    private static void SetFMODDebugOverlay(bool isEnabled)
    {
        var editorPlatform = Settings.Instance.PlayInEditorPlatform;

        // Lastly, access the Overlay property.
        var properties = editorPlatform.GetType().GetField("Properties",
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        if (properties == null)
            return;
            
        var editorPlatformSettings = properties.GetValue(Settings.Instance.PlayInEditorPlatform);

        var overlayProperty = editorPlatformSettings.GetType().GetField("Overlay",
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        if (overlayProperty == null)
            return;
            
        var overlayValue = overlayProperty.GetValue(editorPlatformSettings);

        var valueProperty = overlayValue.GetType().GetField("Value",
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        
        if (valueProperty != null)
        {
            TriStateBool nextOverlayState = isEnabled ? TriStateBool.Enabled : TriStateBool.Disabled;
            valueProperty.SetValue(overlayValue, nextOverlayState);
        }

        EditorUtility.SetDirty(editorPlatform);
    }

    /// <summary>
    /// FMOD 디버그 오버레이 값을 가져옵니다.
    /// </summary>
    /// <returns>TriStateBool 값입니다.</returns>
    private static TriStateBool FMODDebugOverlay => Settings.Instance.PlayInEditorPlatform.Overlay;
}