using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace n5y.SpotifyApi.Ui {
    public class SpotifyWindow : EditorWindow {
        [MenuItem("Window/UI Toolkit/SpotifyWindow")]
        public static void ShowExample() {
            SpotifyWindow wnd = GetWindow<SpotifyWindow>();
            wnd.titleContent = new GUIContent("SpotifyWindow");
        }

        public void CreateGUI() {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            //VisualElement label = new Label("Hello World! From C#");
            //root.Add(label);

            // Import UXML
            var visualTree =
                AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/n5y/SpotifyApi/Ui/SpotifyWindow.uxml");
            VisualElement labelFromUXML = visualTree.Instantiate();
            root.Add(labelFromUXML);

            // A stylesheet can be added to a VisualElement.
            // The style will be applied to the VisualElement and all of its children.
            //var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/n5y/SpotifyApi/Ui/SpotifyWindow.uss");
            //VisualElement labelWithStyle = new Label("Hello World! With Style");
            //labelWithStyle.styleSheets.Add(styleSheet);
            //root.Add(labelWithStyle);
        }
    }
}
