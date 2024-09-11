using UnityEngine.UIElements;

namespace NKStudio
{
    public static class ToolbarRegister
    {
        public static void OnDrawToolbarLeft(VisualElement element)
        {
#if UNITY_6000
            // Unity Preview 캡션 지우기
            Unity6CaptionToolbars.OnGUI(element);
#endif
            // Enter Play Mode Option
            EnterPlayModeOptionToolbars.OnGUI(element);

#if USE_LOCALIZATION
            // Localization
            LocalizationToolbars.OnGUI(element);
#endif
        }

        public static void OnDrawToolbarRight(VisualElement element)
        {
        }

        public static void OnDrawToolbarCenterLeft(VisualElement element)
        {
            // 0번째 씬에 이동
            SceneSwitchLeftButton.OnGUI(element);
        }

        public static void OnDrawToolbarCenterRight(VisualElement element)
        {
            // 씬 메뉴를 통해 이동
            SceneSwitchRightButton.OnGUI(element);
        }
    }
}