using UnityEditor;

namespace NKStudio
{
    public static class ToolbarUtility
    {
        /// <summary>
        /// 에디터가 플레이 모드가 아닌 상태인지 확인하는 유틸리티 프로퍼티입니다.
        /// </summary>
        internal static bool IsNotPlaying => !EditorApplication.isPlaying;

        /// <summary>
        /// 에디터의 다크 모드 접두사를 반환하는 유틸리티 프로퍼티입니다.
        /// </summary>
        internal static string DarkModePrefix => EditorGUIUtility.isProSkin ? "d_" : "";
    }
}