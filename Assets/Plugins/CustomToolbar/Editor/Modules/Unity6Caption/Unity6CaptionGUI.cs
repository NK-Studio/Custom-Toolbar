using UnityEngine.UIElements;

namespace NKStudio
{
    public static class Unity6CaptionGUI
    {
        public static void OnGUI(VisualElement element)
        {
            var caption = element.Q<VisualElement>("ToolbarProductCaption");

            if (caption != null)
                element.Remove(caption);
        }
    }
}