using System.IO;
using Unity.UI.Builder;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.UIElements
{
    public class ExportUnityStyle : Editor
    {
        private static readonly string s_ToolbarDarkStyleSheetPath = "StyleSheets/Generated/DefaultCommonLight.uss.asset";

        [MenuItem("Tools/CustomToolbar/PPAP")]
        private static void GetFi()
        {
            var s = EditorGUIUtility.Load(
                UIElementsEditorUtility.GetStyleSheetPathForCurrentFont(s_ToolbarDarkStyleSheetPath)) as StyleSheet;
            
            var a = s.GenerateUSS();
            Debug.Log(a);
            
            File.WriteAllText(Application.dataPath + "/DefaultCommonLight.uss", a);
            
            AssetDatabase.Refresh();
        }
    }
}