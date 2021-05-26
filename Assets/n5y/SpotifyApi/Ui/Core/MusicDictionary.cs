using System.Collections.Generic;
using System.Linq;

namespace n5y.SpotifyApi.Ui.Core {
    public class MusicDictionary {
        readonly IDictionary<PlaylistTuple, IList<MusicTuple>> playlistDict;
        readonly IDictionary<AlbumTuple, IList<MusicTuple>> albumDict;
        readonly IList<DeviceTuple> devices;

        public MusicDictionary() {
            playlistDict = new Dictionary<PlaylistTuple, IList<MusicTuple>>();
            albumDict = new Dictionary<AlbumTuple, IList<MusicTuple>>();
            devices = new List<DeviceTuple>();
        }

        public void AddNewPlaylist(PlaylistTuple playlist) {
            if (playlistDict.TryGetValue(playlist, out var list)) {
                list.Clear();
            } else {
                playlistDict.Add(playlist, new List<MusicTuple>());
            }
        }

        public void AddMusicInPlaylist(PlaylistTuple playlist, MusicTuple music) {
            if (playlistDict.ContainsKey(playlist)) {
                playlistDict[playlist].Add(music);
            }
        }

        public void AddNewAlbum(AlbumTuple album) {
            if (albumDict.TryGetValue(album, out var list)) {
                list.Clear();
            } else {
                albumDict.Add(album, new List<MusicTuple>());
            }
        }

        public void AddMusicInAlbum(AlbumTuple album, MusicTuple music) {
            if (albumDict.ContainsKey(album)) {
                albumDict[album].Add(music);
            }
        }

        public void AddDevice(DeviceTuple device) {
            devices.Add(device);
        }

        public void Clear() {
            playlistDict.Clear();
            albumDict.Clear();
            devices.Clear();
        }

        public IEnumerable<(PlaylistTuple, IEnumerable<MusicTuple>)> GetPlaylists() {
            return playlistDict.Select(x => (x.Key, (IEnumerable<MusicTuple>)x.Value));
        }

        public IEnumerable<(AlbumTuple, IEnumerable<MusicTuple>)> GetAlbums() {
            return albumDict.Select(x => (x.Key, (IEnumerable<MusicTuple>)x.Value));
        }

        public IEnumerable<DeviceTuple> GetDevices() {
            return devices;
        }
    }
}
