using System;
using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.PubSub {
    public class MusicMessagePipePublisher : ICurrentMusicPublisher, IMusicCatalogPublisher, IMusicSelectPublisher {
        public IPublisher<MusicData> NewMusic { get; }
        public IPublisher<PlaylistTuple> Playlist { get; }
        public IPublisher<AlbumTuple> Album { get; }
        public IPublisher<DeviceTuple> Device { get; }
        public IPublisher<PlaylistMusicTuple> PlaylistMusic { get; }
        public IPublisher<AlbumMusicTuple> AlbumMusic { get; }
        public IPublisher<MusicId> MusicSelect { get; }
        public IPublisher<DeviceId> DeviceSelect { get; }

        public MusicMessagePipePublisher(IServiceProvider resolver) {
            NewMusic = resolver.GetRequiredService<IPublisher<MusicData>>();
            Playlist = resolver.GetRequiredService<IPublisher<PlaylistTuple>>();
            Album = resolver.GetRequiredService<IPublisher<AlbumTuple>>();
            Device = resolver.GetRequiredService<IPublisher<DeviceTuple>>();
            PlaylistMusic = resolver.GetRequiredService<IPublisher<PlaylistMusicTuple>>();
            AlbumMusic = resolver.GetRequiredService<IPublisher<AlbumMusicTuple>>();
            MusicSelect = resolver.GetRequiredService<IPublisher<MusicId>>();
            DeviceSelect = resolver.GetRequiredService<IPublisher<DeviceId>>();
        }
    }
}
