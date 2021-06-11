using System;
using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.PubSub {
    public class MusicMessagePipeSubscriber : ICurrentMusicSubscriber, IMusicCatalogSubscriber, IMusicSelectSubscriber{
        public IBufferedSubscriber<MusicData> Music { get; }
        public ISubscriber<PlaylistTuple> Playlist { get; }
        public ISubscriber<AlbumTuple> Album { get; }
        public ISubscriber<DeviceTuple> Device { get; }
        public ISubscriber<PlaylistMusicTuple> PlaylistMusic { get; }
        public ISubscriber<AlbumMusicTuple> AlbumMusic { get; }
        public ISubscriber<MusicId> MusicSelect { get; }
        public ISubscriber<DeviceId> DeviceSelect { get; }

        public MusicMessagePipeSubscriber(IServiceProvider resolver) {
            Music = resolver.GetRequiredService<IBufferedSubscriber<MusicData>>();
            Playlist = resolver.GetRequiredService<ISubscriber<PlaylistTuple>>();
            Album = resolver.GetRequiredService<ISubscriber<AlbumTuple>>();
            Device = resolver.GetRequiredService<ISubscriber<DeviceTuple>>();
            PlaylistMusic = resolver.GetRequiredService<ISubscriber<PlaylistMusicTuple>>();
            AlbumMusic = resolver.GetRequiredService<ISubscriber<AlbumMusicTuple>>();
            MusicSelect = resolver.GetRequiredService<ISubscriber<MusicId>>();
            DeviceSelect = resolver.GetRequiredService<ISubscriber<DeviceId>>();
        }
    }
}
