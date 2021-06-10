using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Editor {
    public class EditorPrefsTokenStorage : IRefreshTokenStorage {
        readonly SpotifyClientSettingsPrefs settings;

        public EditorPrefsTokenStorage(SpotifyClientSettingsPrefs settings) {
            this.settings = settings;
        }

        UniTask<string> IRefreshTokenStorage.LoadAsync(CancellationToken cancellationToken) {
            settings.Load();
            return UniTask.FromResult(settings.refreshToken.value);
        }

        UniTask IRefreshTokenStorage.SaveAsync(string refreshToken, CancellationToken cancellationToken) {
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
            settings.Save();
            return UniTask.CompletedTask;
        }

        UniTask<bool> IRefreshTokenStorage.ContainsAsync(CancellationToken cancellationToken) {
            settings.Load();
            var current = settings.refreshToken;
            return UniTask.FromResult(current.isSave && !string.IsNullOrEmpty(current.value));
        }
    }
}
