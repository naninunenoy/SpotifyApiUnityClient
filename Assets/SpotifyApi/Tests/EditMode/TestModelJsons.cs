using UnityEngine;

namespace SpotifyApi.Tests.EditMode {
    //[CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    public class TestModelJsons : ScriptableObject {
        [SerializeField] [Multiline] string albumsResponse = "";
        [SerializeField] [Multiline] string albumResponse = "";
        [SerializeField] [Multiline] string albumTracksResponse = "";
        [SerializeField] [Multiline] string artistsResponse = "";
        [SerializeField] [Multiline] string artistResponse = "";
        [SerializeField] [Multiline] string artistAlbumsResponse = "";
        [SerializeField] [Multiline] string userSavedAlbumsResponse = "";
        [SerializeField] [Multiline] string userSavedTracksResponse = "";
        [SerializeField] [Multiline] string userCurrentPlayingResponse = "";
        [SerializeField] [Multiline] string userAvailableDevicesResponse = "";
        [SerializeField] [Multiline] string userCurrentlyPlayingTrackResponse = "";
        [SerializeField] [Multiline] string userRecentlyPlayedTracksResponse = "";
        [SerializeField] [Multiline] string playlistsResponse = "";
        [SerializeField] [Multiline] string playlistResponse = "";
        [SerializeField] [Multiline] string playlistTracksResponse = "";
        [SerializeField] [Multiline] string trackResponse = "";
        [SerializeField] [Multiline] string audioFeaturesResponse = "";
        [SerializeField] [Multiline] string audioAnalysisResponse = "";
        [SerializeField] [Multiline] string userProfileResponse = "";

        public string UserProfileResponse => userProfileResponse;
        public string AudioAnalysisResponse => audioAnalysisResponse;
        public string AudioFeaturesResponse => audioFeaturesResponse;
        public string TrackResponse => trackResponse;
        public string PlaylistTracksResponse => playlistTracksResponse;
        public string PlaylistResponse => playlistResponse;
        public string PlaylistsResponse => playlistsResponse;
        public string UserRecentlyPlayedTracksResponse => userRecentlyPlayedTracksResponse;
        public string UserCurrentlyPlayingTrackResponse => userCurrentlyPlayingTrackResponse;
        public string UserAvailableDevicesResponse => userAvailableDevicesResponse;
        public string UserCurrentPlayingResponse => userCurrentPlayingResponse;
        public string UserSavedTracksResponse => userSavedTracksResponse;
        public string UserSavedAlbumsResponse => userSavedAlbumsResponse;
        public string ArtistAlbumsResponse => artistAlbumsResponse;
        public string ArtistResponse => artistResponse;
        public string ArtistsResponse => artistsResponse;
        public string AlbumTracksResponse => albumTracksResponse;
        public string AlbumResponse => albumResponse;
        public string AlbumsResponse => albumsResponse;
    }
}
