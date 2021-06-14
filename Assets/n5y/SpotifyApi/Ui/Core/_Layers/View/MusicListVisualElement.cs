using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core.View {
    public class MusicListVisualElement : IMusicListPresentation, IListViewTrigger {
        readonly VisualElement root;
        readonly Subject<Unit> onClose;
        readonly Subject<Unit> onPlaylistSelect;
        readonly Subject<Unit> onAlbumSelect;
        readonly Subject<Unit> onDeviceSelect;
        readonly Subject<PlaylistId> onDecidePlaylist;
        readonly Subject<AlbumId> onDecideAlbum;
        readonly Subject<DeviceId> onDecideDevice;
        readonly Subject<MusicId> onDecideMusic;
        readonly CompositeDisposable disposable;

        Button closeButton;
        Foldout playlistFoldout;
        Foldout albumFoldout;
        Foldout deviceFoldout;
        readonly Dictionary<PlaylistId, Foldout> playlistMusicFoldoutDict;
        readonly Dictionary<AlbumId, Foldout> albumMusicFoldoutDict;

        public MusicListVisualElement(VisualElement visualElement, CompositeDisposable lifeTime) {
            root = visualElement;
            onClose = new Subject<Unit>();
            onPlaylistSelect = new Subject<Unit>();
            onAlbumSelect = new Subject<Unit>();
            onDeviceSelect = new Subject<Unit>();
            onDecidePlaylist = new Subject<PlaylistId>();
            onDecideAlbum = new Subject<AlbumId>();
            onDecideDevice = new Subject<DeviceId>();
            onDecideMusic = new Subject<MusicId>();
            disposable = lifeTime;
            playlistMusicFoldoutDict = new Dictionary<PlaylistId, Foldout>();
            albumMusicFoldoutDict = new Dictionary<AlbumId, Foldout>();
        }

        public void Bind() {
            closeButton = root.Q<Button>("closeButton");
            playlistFoldout = root.Q<Foldout>("PlaylistFoldout");
            albumFoldout = root.Q<Foldout>("AlbumFoldout");
            deviceFoldout = root.Q<Foldout>("DeviceFoldout");
            closeButton.clickable.clicked += () => onClose.OnNext(Unit.Default);

            playlistFoldout.OnValueChangedObservable()
                .Subscribe(isOn => {
                    if (isOn) {
                        onPlaylistSelect.OnNext(Unit.Default);
                    } else {
                        playlistFoldout.Clear();
                        playlistMusicFoldoutDict.Clear();
                    }
                })
                .AddTo(disposable);
            albumFoldout.OnValueChangedObservable()
                .Subscribe(isOn => {
                    if (isOn) {
                        onAlbumSelect.OnNext(Unit.Default);
                    } else {
                        albumFoldout.Clear();
                        albumMusicFoldoutDict.Clear();
                    }
                })
                .AddTo(disposable);
            deviceFoldout.OnValueChangedObservable()
                .Subscribe(isOn => {
                    if (isOn) {
                        onDeviceSelect.OnNext(Unit.Default);
                    } else {
                        deviceFoldout.Clear();
                    }
                })
                .AddTo(disposable);
        }

        void IMusicListPresentation.AddPlaylist(PlaylistTuple playlist) {
            var foldout = new Foldout { text = playlist.name, value = false};
            foldout.OnValueChangedObservable()
                .Subscribe(isOn => {
                    UnityEngine.Debug.Log($"AddPlaylist {playlist.playlistId} {isOn}");
                    if (isOn) {
                        onDecidePlaylist.OnNext(playlist.playlistId);
                    } else {
                        foldout.Clear();
                    }
                })
                .AddTo(disposable);
            playlistFoldout.Add(foldout);
            playlistMusicFoldoutDict.Add(playlist.playlistId, foldout);
        }

        void IMusicListPresentation.AddAlbum(AlbumTuple album) {
            var foldout = new Foldout { text = album.name, value = false};
            foldout.OnValueChangedObservable()
                .Subscribe(isOn => {
                    if (isOn) {
                        onDecideAlbum.OnNext(album.albumId);
                    } else {
                        foldout.Clear();
                    }
                })
                .AddTo(disposable);
            albumFoldout.Add(foldout);
            albumMusicFoldoutDict.Add(album.albumId, foldout);
        }

        void IMusicListPresentation.AddDevice(DeviceTuple device) {
            var button = new Button { text = device.name };
            button.clickable.clicked += () => {
                onDecideDevice.OnNext(device.deviceId);
                onClose.OnNext(Unit.Default);
            };
            deviceFoldout.Add(button);
        }

        void IMusicListPresentation.AddPlaylistMusic(PlaylistId playlistId, MusicTuple music) {
            if (playlistMusicFoldoutDict.TryGetValue(playlistId, out var foldout)) {
                var button = new Button { text = music.name };
                button.clickable.clicked += () => {
                    onDecideMusic.OnNext(music.musicId);
                    onClose.OnNext(Unit.Default);
                };
                foldout.Add(button);
            }
        }

        void IMusicListPresentation.AddAlbumMusic(AlbumId albumId, MusicTuple music) {
            if (albumMusicFoldoutDict.TryGetValue(albumId, out var foldout)) {
                var button = new Button { text = music.name };
                button.clickable.clicked += () => {
                    onDecideMusic.OnNext(music.musicId);
                    onClose.OnNext(Unit.Default);
                };
                foldout.Add(button);
            }
        }

        IObservable<Unit> IListViewTrigger.OnClose => onClose;
        IObservable<Unit> IListViewTrigger.OnPlaylistSelect => onPlaylistSelect;
        IObservable<Unit> IListViewTrigger.OnAlbumSelect => onAlbumSelect;
        IObservable<Unit> IListViewTrigger.OnDeviceSelect => onDeviceSelect;
        IObservable<PlaylistId> IListViewTrigger.OnDecidePlaylist => onDecidePlaylist;
        IObservable<AlbumId> IListViewTrigger.OnDecideAlbum => onDecideAlbum;
        IObservable<DeviceId> IListViewTrigger.OnDecideDevice => onDecideDevice;
        IObservable<MusicId> IListViewTrigger.OnDecideMusic => onDecideMusic;
    }

    internal static class FoldoutValueChangedObservable {
        public static IObservable<bool> OnValueChangedObservable(this Foldout foldout) {
            return Observable.IntervalFrame(1)
                .Select(_ => foldout.value)
                .Pairwise()
                .Where(x => x.Previous != x.Current)
                .Select(x => x.Current);
        }
    }
}
