using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui {
    // クラス名が SpotifyWindow だとなぜか window が表示されない
    public class SpotifyWindow0 : EditorWindow {
        const string uxmlPath = "Assets/n5y/SpotifyApi/Ui/SpotifyWindow.uxml";

        [MenuItem("Window/UI Toolkit/SpotifyWindow")]
        public static void ShowExample() {
            var wnd = GetWindow<SpotifyWindow0>();
            wnd.titleContent = new GUIContent("SpotifyWindow");
        }

        public void CreateGUI() {
            var root = rootVisualElement;
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(uxmlPath);
            var uxml = visualTree.Instantiate();
            root.Add(uxml);

            var listButton = root.Q<Button>("openButton");
            listButton.clickable.clicked += SpotifyListWindow.ShowListWindow;
        }
    }
}
