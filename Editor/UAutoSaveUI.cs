
namespace UCommon.AutoSave.Editor
{
    public class UAutoSaveUI
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
        }

        /// <summary>
        /// Pings current existing auto save configuration file for the user.
        /// </summary>
        [MenuItem("Window/Autosave/Find Configuration file.")]
        public static void showConfig()
        {
            EditorGUIUtility.PingObject(AssetDatabase.LoadAssetAtPath<AutoSaveConfigSo>(getConfigPath()).GetInstanceID());
        }
    }
}
