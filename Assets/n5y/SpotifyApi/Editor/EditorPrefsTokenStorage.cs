using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Editor {
    public class EditorPrefsTokenStorage : IRefreshTokenStorage {
        readonly SpotifyClientSettingsPrefs settings;
        string temporaryRefreshToken;

        public EditorPrefsTokenStorage(SpotifyClientSettingsPrefs settings) {
            this.settings = settings;
            temporaryRefreshToken = "";
        }

        UniTask<string> IRefreshTokenStorage.LoadAsync(CancellationToken cancellationToken) {
            settings.Load();
            if (string.IsNullOrEmpty(settings.refreshToken.value)) {
                return UniTask.FromResult(temporaryRefreshToken);
            }
            return UniTask.FromResult(settings.refreshToken.value);
        }

        UniTask IRefreshTokenStorage.SaveAsync(string refreshToken, CancellationToken cancellationToken) {
            temporaryRefreshToken = refreshToken;
            settings.Load();
            if (settings.refreshToken.isSave) {
                settings.refreshToken.value = refreshToken;
                settings.Save();
            }
            return UniTask.CompletedTask;
        }

        UniTask IRefreshTokenStorage.DeleteAsync(CancellationToken cancellationToken) {
            settings.Load();
            settings.refreshToken.value = "";
            temporaryRefreshToken = "";
            settings.Save();
            return UniTask.CompletedTask;
        }

        UniTask<bool> IRefreshTokenStorage.ContainsAsync(CancellationToken cancellationToken) {
            settings.Load();
            var current = settings.refreshToken;
            return UniTask.FromResult(!string.IsNullOrEmpty(current.value) ||
                                      !string.IsNullOrEmpty(temporaryRefreshToken));
        }
    }
}
