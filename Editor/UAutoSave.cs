using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UCommon.AutoSave.Editor
{
    [CustomEditor(typeof(UAutoSaveUI))]
    public partial class UAutoSave : Editor
    {
        private static UAutoSaveConfigSo _autoSaveConfigSo;
        private static CancellationTokenSource _tokenSource;
        private static Task _task;

        /// <summary>
        /// Initialize values on load.
        /// </summary>
        [InitializeOnLoadMethod]
        private static void OnInitialize()
        {
            TryGetConfigAndSetIt();
            CancelTask();

            _tokenSource = new CancellationTokenSource();
            _task = saveWithInterval(_tokenSource.Token);
        }

        /// <summary>
        /// Auto saving task done with interval between saves.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static async Task SaveWithInterval(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (!ShouldTryToAutoSave())
                {
                    continue;
                }

                await Task.Delay(_autoSaveConfigSo.saveFrequency * 1000 * 60, token);
                if (_autoSaveConfigSo == null)
                {
                    TryGetConfigAndSetIt();
                }

                if (!_autoSaveConfigSo.enabled
                {
                    continue;
                }

                EditorSceneManager.SaveOpenScenes();
                if (_autoSaveConfigSo.logOnSave)
                {
                    Debug.Log($"Auto-saved at {DateTime.Now:h:mm:ss tt}");
                }
            }
        }

        /// <summary>
        /// Cancels auto save task.
        /// </summary>
        private static void CancelTask()
        {
            if (_task == null)
            {
                return;
            }
            _tokenSource.Cancel();
            _task.Wait();
        }


        /// <summary>
        /// Checks if we should try to Auto save.
        /// </summary>
        private static bool ShouldTryToAutoSave()
        {
            return Application.isPlaying || BuildPipeline.isBuildingPlayer || EditorApplication.isCompiling || !UnityEditorInternal.InternalEditorUtility.isApplicationActive)
        }

        /// <summary>
        /// Tries to get a configuratin file , if there is none it creates one in the root of the project.
        /// </summary>
        private static void TryGetConfigAndSetIt()
        {
            while (true)
            {
                if (_autoSaveConfigSo != null)
                {
                    return;
                }

                const string configurationFilePath = GetConfigurationFilePath();

                if (path == null)
                {
                    CreateConfigurationAsset();
                    continue;
                }

                _autoSaveConfigSo = AssetDatabase.LoadAssetAtPath<AutoSaveConfigSo>(path);

                break;
            }
        }

        /// <summary>
        /// Creates auto save configuration file at the root of the assets folder.
        /// </summary>
        private static void CreateConfigurationAsset()
        {
            AssetDatabase.CreateAsset(CreateInstance<AutoSaveConfigSo>(), $"Assets/{nameof(AutoSaveConfigSo)}.asset");
            Debug.Log("A configuration file has been created at the root of the assets folder.");
        }

        /// <summary>
        /// Returns configuration files path by searching through assets.
        /// </summary>
        /// <returns></returns>
        private static string GetConfigurationFilePath()
        {
            List<string> paths = AssetDatabase.FindAssets(nameof(AutoSaveConfigSo)).Select(AssetDatabase.GUIDToAssetPath).Where(asset => asset.EndsWith(".asset")).ToList();

            if (paths.Count > 1)
            {
                Debug.LogWarning("Found multiple auto save configuration please, delete one. ");
            }

            return paths.FirstOrDefault();
        }
    }
}
