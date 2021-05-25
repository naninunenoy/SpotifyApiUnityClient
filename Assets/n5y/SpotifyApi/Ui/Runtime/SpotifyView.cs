using n5y.SpotifyApi.Ui.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Runtime {
    public class SpotifyView : MonoBehaviour, ISpotifyListOpen {
        [SerializeField] UIDocument musicView;
        [SerializeField] UIDocument listView;


        VisualElement ISpotifyListOpen.OpenListView() {
            listView.gameObject.SetActive(true);
            return listView.rootVisualElement;
        }

        void ISpotifyListOpen.Close() {
            listView.gameObject.SetActive(false);
        }
    }
}
