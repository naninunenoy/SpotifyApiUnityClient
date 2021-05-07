using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Editor {
    class SpotifyClientSettingsProvider {
        private static SpotifyClientSettingsPrefs settings;
        static TextField clientIdTextField;
        static TextField clientSecretTextField;
        static TextField redirectUriTextField;

        [SettingsProvider]
        public static SettingsProvider Create() {
            // 入力欄作成
            settings = new SpotifyClientSettingsPrefs();
            settings.Load();
            clientIdTextField = new TextField("clientId");
            clientSecretTextField = new TextField("clientSecret");
            redirectUriTextField = new TextField("redirectUri");
            clientIdTextField.value = settings.clientId;
            clientSecretTextField.value = settings.clientSecret;
            redirectUriTextField.value = settings.redirectUri;
            // 既存の設定値
            var provider = new SettingsProvider("SpotifyClient/", SettingsScope.User) {
                // タイトル
                label = "SpotifyClient",
                // 初期化
                activateHandler = (searchContext, rootElement) => {
                    rootElement.Add(clientIdTextField);
                    rootElement.Add(clientSecretTextField);
                    rootElement.Add(redirectUriTextField);
                },
                // 終了
                deactivateHandler = () => {
                    settings.clientId = clientIdTextField.value;
                    settings.clientSecret = clientSecretTextField.value;
                    settings.redirectUri =redirectUriTextField.value;
                    settings.Save();
                },
                // 検索時のキーワード
                keywords = new HashSet<string>(new[] {"Spotify"})
            };
            return provider;
        }
    }

    public class SpotifyClientSettingsPrefs {
        private const string keyPrefix = "SpotifyClientEditorSettings";
        public string clientId = "";
        public string clientSecret = "";
        public string redirectUri = "";

        public void Save() {
            EditorPrefs.SetString($"{keyPrefix}_clientId", clientId);
            EditorPrefs.SetString($"{keyPrefix}_clientSecret", clientSecret);
            EditorPrefs.SetString($"{keyPrefix}_redirectUri", redirectUri);
        }

        public void Load() {
            clientId = EditorPrefs.GetString($"{keyPrefix}_clientId", "");
            clientSecret = EditorPrefs.GetString($"{keyPrefix}_clientSecret", "");
            redirectUri = EditorPrefs.GetString($"{keyPrefix}_redirectUri", "");
        }
    }
}
