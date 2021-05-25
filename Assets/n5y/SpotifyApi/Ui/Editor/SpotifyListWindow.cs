using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Editor {
    public class SpotifyListWindow : EditorWindow {
        const string uxmlPath = "Assets/n5y/SpotifyApi/Ui/ToolKit/SpotifyListWindow.uxml";

        //[MenuItem("Window/UI Toolkit/SpotifyListWindow")]
        public static void ShowListWindow() {
            SpotifyListWindow wnd = GetWindow<SpotifyListWindow>();
            wnd.titleContent = new GUIContent("SpotifyListWindow");
        }

        public void CreateGUI() {
            var root = rootVisualElement;
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(uxmlPath);
            var uxml = visualTree.Instantiate();
            root.Add(uxml);
        }
    }
}
