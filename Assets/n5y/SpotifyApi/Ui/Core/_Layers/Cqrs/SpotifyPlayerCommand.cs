using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public class SpotifyPlayerCommand : ICurrentPlayerCommand {
        readonly ITokenProvider tokenProvider;
        readonly ITokenValidation tokenValidation;

        public SpotifyPlayerCommand(ITokenProvider tokenProvider, ITokenValidation tokenValidation) {
            this.tokenProvider = tokenProvider;
            this.tokenValidation = tokenValidation;
        }

        async UniTask ICurrentPlayerCommand.PushCurrentMusic(MusicId musicId, CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            await Api.PutPlayAsync(musicId.Identifier, tokenProvider, cancellationToken);
        }

        async UniTask ICurrentPlayerCommand.PushCurrentDevice(DeviceId deviceId, CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            await Api.PutPlayerAsync(deviceId.Identifier, tokenProvider, cancellationToken);
        }
    }
}
