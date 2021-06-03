using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core.n5y.SpotifyApi.Ui.Core.Cqrs {
    public class SpotifyControlCommand : IMusicControlCommand {
        readonly ITokenProvider tokenProvider;
        readonly ITokenValidation tokenValidation;

        public SpotifyControlCommand(ITokenProvider tokenProvider, ITokenValidation tokenValidation) {
            this.tokenProvider = tokenProvider;
            this.tokenValidation = tokenValidation;
        }

        async UniTask IMusicControlCommand.ResumeAsync(CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            await Api.PutPlayAsync("", tokenProvider, cancellationToken);
        }

        async UniTask IMusicControlCommand.PauseAsync(CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            await Api.PutPauseAsync(tokenProvider, cancellationToken);
        }

        async UniTask IMusicControlCommand.GoNextAsync(CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            await Api.PostNextAsync(tokenProvider, cancellationToken);
        }

        async UniTask IMusicControlCommand.GoBackAsync(CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            await Api.PostPreviousAsync(tokenProvider, cancellationToken);
        }

        async UniTask IMusicControlCommand.SeekAsync(int milliSeconds, CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            await Api.PutSeekAsync(milliSeconds, tokenProvider, cancellationToken);
        }
    }
}
