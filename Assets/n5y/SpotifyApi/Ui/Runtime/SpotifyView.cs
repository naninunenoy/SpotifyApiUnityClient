using n5y.SpotifyApi.Ui.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Runtime {
    public class SpotifyView : MonoBehaviour, ISpotifyListOpen {
        [SerializeField] UIDocument musicView;
        [SerializeField] UIDocument listView;
        SpotifyMusicViewMain main;

        void Start() {
            SetUp();
        }

        void SetUp() {
            // TODO runtime env and token storage
            main = new SpotifyMusicViewMain(musicView.rootVisualElement, this, null,null);
            main.Process();
        }

        VisualElement ISpotifyListOpen.OpenListView() {
            musicView.gameObject.SetActive(false);
            listView.gameObject.SetActive(true);
            return listView.rootVisualElement;
        }

        void ISpotifyListOpen.Close() {
            listView.gameObject.SetActive(false);
            musicView.gameObject.SetActive(true);
            SetUp();
        }
    }
}
