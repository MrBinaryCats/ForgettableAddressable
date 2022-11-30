using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Build.DataBuilders;
using UnityEngine;

namespace ForgettableAddressable.Editor
{
    [InitializeOnLoad]
    public class AddressableToast
    {
        static AddressableToast()
        {
            EditorApplication.playModeStateChanged += OnPlayStateChanged;
        }

        private static readonly GUIContent NotificationMsg = new GUIContent("Using Prebuilt Addressables");

        private static void OnPlayStateChanged(PlayModeStateChange obj)
        {
            if (obj == PlayModeStateChange.EnteredPlayMode)
            {
                if (AddressableAssetSettingsDefaultObject.Settings != null)
                {
                    if (AddressableAssetSettingsDefaultObject.Settings.ActivePlayModeDataBuilder is BuildScriptPackedPlayMode)
                    {
                        GetMainGameView().ShowNotification(NotificationMsg);
                    }
                }
            }
        }

        private static EditorWindow GetMainGameView()
        {
            var assembly = typeof(EditorWindow).Assembly;
            var type = assembly.GetType("UnityEditor.GameView");
            return  EditorWindow.GetWindow(type);
        }
    }
}
