using System;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core {
    public class AuthorizeAgent : AgentBase {
        readonly IEnvironmentProvider environmentProvider;
        readonly IRefreshTokenStorage refreshTokenStorage;
        readonly TokenFactory tokenFactory;

        public AuthorizeAgent(IEnvironmentProvider environmentProvider, IRefreshTokenStorage refreshTokenStorage) {
            this.environmentProvider = environmentProvider;
            this.refreshTokenStorage = refreshTokenStorage;
            tokenFactory = new TokenFactory(environmentProvider, refreshTokenStorage);
        }

        public async UniTask<AuthorizeTuple> TryFirstAuthorize() {
            var refreshToken = "";
            try {
                refreshToken = await refreshTokenStorage.LoadAsync(agentCts.Token);
            } catch {
                throw new Exception("no refresh_token. Need to authenticate at the Spotify website.");
            }

            ITokenProvider tokenProvider;
            try {
                tokenProvider = await tokenFactory.AuthorizeByRefreshTokenAsync(refreshToken, agentCts.Token);
            } catch {
                throw new Exception("failed to authenticate by refresh_token. Please authenticate at the Spotify website again.");
            }

            return new AuthorizeTuple(tokenProvider, tokenFactory);
        }

        public async UniTask<AuthorizeTuple> TryAuthorize() {
            ITokenProvider tokenProvider;
            try {
                tokenProvider = await tokenFactory.AuthorizeAsync(agentCts.Token);
            } catch {
                var param =
                    $"ClientId={environmentProvider.ClientId}, ClientSecret={environmentProvider.ClientSecret}, RedirectUri={environmentProvider.RedirectUri}";
                throw new Exception($"failed to authenticate at the Spotify website. Please confirm parameters. {param}");
            }

            return new AuthorizeTuple(tokenProvider, tokenFactory);
        }
    }
    public class AuthorizeTuple {
        public ITokenProvider TokenProvider { private set; get; }
        public ITokenValidation TokenValidation { private set; get; }
        public AuthorizeTuple(ITokenProvider tokenProvider, ITokenValidation tokenValidation) {
            TokenProvider = tokenProvider;
            TokenValidation = tokenValidation;
        }
    }
}
