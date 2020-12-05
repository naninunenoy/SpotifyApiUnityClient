using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using System.Net;

namespace SpotifyApi.Example {
    public class ExampleSceneEntry : MonoBehaviour {
        [SerializeField] Button startAuthButton = default;
        [SerializeField] Text attentionText = default;
        [SerializeField] Button getTokenButton = default;
        [SerializeField] Text helloText = default;
        HttpListener listener;

        void Start() {
            var accessCode = "";
            var authUrl = Api.GetAuthorizeUrl(Environment.ClientId, Environment.RedirectUri);
            startAuthButton
                .OnClickAsObservable()
                .Subscribe(async _ => {
                    // Spotify認可のサイトからlocalhostにリダイレクトされるので、サーバを建てて待つ
                    listener = new HttpListener();
                    listener.Prefixes.Clear();
                    listener.Prefixes.Add(Environment.RedirectUri);
                    listener.Start();

                    attentionText.gameObject.SetActive(true);
                    Application.OpenURL(authUrl);

                    // ブラウザから同意するを待つ
                    var context = await listener.GetContextAsync();
                    var rawUrl = context.Request.RawUrl;
                    if (!rawUrl.Contains("error=access_denied")) {
                        accessCode = rawUrl.Split('=')[1];
                        getTokenButton.interactable = true;
                    }
                    listener.Close();
                })
                .AddTo(this);
            getTokenButton
                .OnClickAsObservable()
                .Subscribe(async _ => {
                    var token = await Api.GetTokenAsync(accessCode,
                        Environment.RedirectUri, Environment.ClientId, Environment.ClientSecret,
                        this.GetCancellationTokenOnDestroy());
                    TokenHolder.Instance.SetToken(token);
                    // 自分の情報取得
                    var me = await Api.GetMe(TokenHolder.Instance, this.GetCancellationTokenOnDestroy());
                    helloText.text = $"こんにちは\n{me.DisplayName}さん！";
                    helloText.gameObject.SetActive(true);
                })
                .AddTo(this);
        }

        void OnDestroy() {
            if (listener?.IsListening == true) {
                listener.Close();
            }
        }
    }
}
