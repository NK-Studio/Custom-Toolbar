using NKStudio;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

internal static class TimeScaleGUI
{
    internal static void OnGUI(VisualElement element)
    {
        var timeScaleSlider = new TextField()
        {
            name = "TimeScaleSlider",
            label = "Time Scale",
            value = "Hi, My Name is TimeScale",
        };
        
        //timeScaleSlider.AddToClassList("unity-search-field-base__text-field");

        // 값 변경 이벤트 설정
        // timeScaleSlider.RegisterValueChangedCallback(evt =>
        // {
        //     var newValue = evt.newValue;
        //     Time.timeScale = newValue;
        // });

        // 플레이 중에는 비활성화
        timeScaleSlider.SetEnabled(ToolbarUtility.IsNotPlaying);

        // 플레이 중에는 비활성화
        EditorApplication.playModeStateChanged += _ => timeScaleSlider.SetEnabled(ToolbarUtility.IsNotPlaying);

        // 툴바에 추가
        element.Add(timeScaleSlider);
    }
}