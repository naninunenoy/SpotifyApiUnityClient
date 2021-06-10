using n5y.SpotifyApi.Editor;
using n5y.SpotifyApi.Ui.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Editor {
    // クラス名が SpotifyWindow だとなぜか window が表示されない
    public class SpotifyWindow00 : EditorWindow, ISpotifyListOpen {
        const string uxmlPath = "Assets/n5y/SpotifyApi/Ui/ToolKit/SpotifyWindow.uxml";
        SpotifyMusicViewMain musicView;
        SpotifyListWindow listWindow;

        [MenuItem("Window/UI Toolkit/SpotifyWindow")]
        public static void ShowExample() {
            var wnd = GetWindow<SpotifyWindow00>();
            wnd.titleContent = new GUIContent("SpotifyWindow");
        }

        public void CreateGUI() {
            var root = rootVisualElement;
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(uxmlPath);
            var uxml = visualTree.Instantiate();
            root.Add(uxml);

            var spotifySettings = new SpotifyClientSettingsPrefs();
            var tokenStorage = new EditorPrefsTokenStorage(spotifySettings);

            musicView = new SpotifyMusicViewMain(root, this, spotifySettings, tokenStorage);
            musicView.Process();
        }

        void OnDestroy() {
            musicView?.Dispose();
        }

        VisualElement ISpotifyListOpen.OpenListView() {
            CloseListWindow();

            listWindow = GetWindow<SpotifyListWindow>();
            listWindow.titleContent = new GUIContent("SpotifyListWindow");
            return listWindow.rootVisualElement;
        }

        void ISpotifyListOpen.Close() {
            CloseListWindow();
        }

        void CloseListWindow() {
            if (listWindow != null) {
                listWindow.Close();
                listWindow = null;
            }
        }
    }
}
