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
                    // ブラウザを開いて同意するを待つ
                    Application.OpenURL(authUrl);
                    accessCode = await GetAccessCodeAsync(listener);
                    if (!string.IsNullOrEmpty(accessCode)) {
                        getTokenButton.interactable = true;
                    }
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

        async UniTask WriteHtml(HttpListenerResponse res, string message) {
            var text = GetHtml(message);
            res.Headers.Add("HttpResponseStatus:OK");
            res.ContentLength64 = text.Length;
            res.ContentType = "text/html";
            await res.OutputStream.WriteAsync(System.Text.Encoding.UTF8.GetBytes(text), 0, text.Length);
            await res.OutputStream.FlushAsync();
        }

        async UniTask<string> GetAccessCodeAsync(HttpListener listener_) {
            var ret = "";
            var context = await listener_.GetContextAsync();
            var rawUrl = context.Request.RawUrl;
            var accepted = !rawUrl.Contains("error=access_denied");
            if (accepted) {
                ret = rawUrl.Split('=')[1];
            }
            // ブラウザにメッセージを表示
            var htmlMessage = accepted ? "thank you! Go back to unity" : "please retry and accept.";
            await WriteHtml(context.Response, htmlMessage);
            context.Response.Close();
            listener.Close();
            return ret;
        }

        static string GetHtml(string message) =>
            $"<!DOCTYPE html><html> <head><meta charset=\"utf-8\"></head><body>{message}</body></html>";
    }
}
