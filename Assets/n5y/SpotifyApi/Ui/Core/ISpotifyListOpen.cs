using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core {
    public interface ISpotifyListOpen {
        VisualElement OpenListView();
        void Close();
    }
}
