using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Editor {
    class SpotifyClientSettingsProvider {
        static SpotifyClientSettingsPrefs settings;
        static TextField clientIdTextField;
        static TextField clientSecretTextField;
        static TextField redirectUriTextField;
        static Toggle saveRefreshTokenToggle;

        [SettingsProvider]
        public static SettingsProvider Create() {
            // 入力欄作成
            settings = new SpotifyClientSettingsPrefs();
            settings.Load();
            clientIdTextField = new TextField("clientId");
            clientSecretTextField = new TextField("clientSecret");
            redirectUriTextField = new TextField("redirectUri");
            saveRefreshTokenToggle = new Toggle("save refresh_token to *unsecure* storage (save to `EditorPrefs`)");
            clientIdTextField.value = settings.clientId;
            clientSecretTextField.value = settings.clientSecret;
            redirectUriTextField.value = settings.redirectUri;
            saveRefreshTokenToggle.value = settings.refreshToken.isSave;
            // 既存の設定値
            var provider = new SettingsProvider("SpotifyClient/", SettingsScope.User) {
                // タイトル
                label = "SpotifyClient",
                // 初期化
                activateHandler = (searchContext, rootElement) => {
                    rootElement.Add(clientIdTextField);
                    rootElement.Add(clientSecretTextField);
                    rootElement.Add(redirectUriTextField);
                    rootElement.Add(saveRefreshTokenToggle);
                },
                // 終了
                deactivateHandler = () => {
                    settings.clientId = clientIdTextField.value;
                    settings.clientSecret = clientSecretTextField.value;
                    settings.redirectUri = redirectUriTextField.value;
                    settings.refreshToken.isSave = saveRefreshTokenToggle.value;
                    settings.Save();
                },
                // 検索時のキーワード
                keywords = new HashSet<string>(new[] {"Spotify"})
            };
            return provider;
        }
    }

    public class SpotifyClientSettingsPrefs : IEnvironmentProvider {
        const string keyPrefix = "SpotifyClientEditorSettings";
        public string clientId = "";
        public string clientSecret = "";
        public string redirectUri = "";
        public RefreshTokenSaveTuple refreshToken = new RefreshTokenSaveTuple();

        public void Save() {
            EditorPrefs.SetString($"{keyPrefix}_clientId", clientId);
            EditorPrefs.SetString($"{keyPrefix}_clientSecret", clientSecret);
            EditorPrefs.SetString($"{keyPrefix}_redirectUri", redirectUri);
            if (refreshToken.isSave) {
                EditorPrefs.SetString($"{keyPrefix}_refreshToken", EditorJsonUtility.ToJson(refreshToken));
            } else {
                var empty = new RefreshTokenSaveTuple { isSave = false, value = "" };
                EditorPrefs.SetString($"{keyPrefix}_refreshToken", EditorJsonUtility.ToJson(empty));
            }
        }

        public void Load() {
            clientId = EditorPrefs.GetString($"{keyPrefix}_clientId", "");
            clientSecret = EditorPrefs.GetString($"{keyPrefix}_clientSecret", "");
            redirectUri = EditorPrefs.GetString($"{keyPrefix}_redirectUri", "");
            var json =  EditorPrefs.GetString($"{keyPrefix}_refreshToken", "{}");
            EditorJsonUtility.FromJsonOverwrite(json, refreshToken);
        }

        string IEnvironmentProvider.ClientId => clientId;
        string IEnvironmentProvider.ClientSecret => clientSecret;
        string IEnvironmentProvider.RedirectUri => redirectUri;
    }

    [Serializable]
    public class RefreshTokenSaveTuple {
        public bool isSave = false;
        public string value = "";
    }
}
