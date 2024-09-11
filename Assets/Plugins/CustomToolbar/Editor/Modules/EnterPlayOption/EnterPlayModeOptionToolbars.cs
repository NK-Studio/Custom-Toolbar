using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace NKStudio
{
    public static class EnterPlayModeOptionToolbars
    {
        public static void OnGUI(VisualElement element)
        {
            var toggle = new Toggle();
            toggle.name = "EnterPlayModeOption";
            toggle.text = "Enter Play Mode";

            var icon = new Image();
            
            // 사이즈 변경
            icon.style.width = 16;
            icon.style.height = 16;

            // 이미지 적용
            var iconPath = AssetDatabase.GUIDToAssetPath("c0b301a9175a74304992d875f40f670d");
            icon.image = AssetDatabase.LoadAssetAtPath<Texture2D>($"{iconPath}/{ToolbarUtility.DarkModePrefix}rush.png");
            
            // 토글 맨 앞에 아이콘 추가
            toggle[0].Insert(0, icon);
            
            // 체크박스 삭제 후 뒤에 생성하도록 처리
            var check = toggle[0].Q<VisualElement>("unity-checkmark");
            toggle[0].Remove(check);
            toggle[0].Add(check);

            // 마진 추가
            var label = toggle[0].Q<Label>();
            label.style.marginLeft = 4;
            label.style.marginRight = 4;

            // 초기 값 설정
            toggle.value = EditorSettings.enterPlayModeOptionsEnabled;
            
            // 값 변경 이벤트 설정
            toggle.RegisterValueChangedCallback(evt => EditorSettings.enterPlayModeOptionsEnabled = evt.newValue);

            // 툴바에 추가
            element.Add(toggle);
        }
    }
}