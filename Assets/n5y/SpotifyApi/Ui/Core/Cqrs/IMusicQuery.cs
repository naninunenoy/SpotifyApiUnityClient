using Cysharp.Threading.Tasks;
using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IMusicQuery {
        ISubscriber<(PlaylistTuple, MusicTuple)> PlaylistMusic { get; }
        ISubscriber<(AlbumTuple, MusicTuple)> AlbumMusic { get; }
        UniTask<MusicData> GetMusicByIdAsync(MusicId musicId);
    }
}
