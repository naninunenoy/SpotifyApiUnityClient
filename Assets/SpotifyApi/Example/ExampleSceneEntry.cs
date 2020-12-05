using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SpotifyApi.Model;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace SpotifyApi.Example {
    public class ExampleSceneEntry : MonoBehaviour {
        [SerializeField] Button startAuthButton = default;
        [SerializeField] Text attentionText = default;
        [SerializeField] InputField accessCodeInput = default;
        [SerializeField] Button getTokenButton = default;

        void Start() {
            var authUrl = $"{Endpoints.Authorize}?" +
                          $"client_id={Environment.ClientId}" +
                          "&response_type=code" +
                          $"&redirect_uri={Environment.RedirectUri}";
            startAuthButton
                .OnClickAsObservable()
                .Subscribe(_ => {
                    attentionText.gameObject.SetActive(true);
                    Application.OpenURL(authUrl);
                })
                .AddTo(this);
            getTokenButton
                .OnClickAsObservable()
                .Subscribe(_ => {
                    if (string.IsNullOrEmpty(accessCodeInput.text)) return;
                    var accessCode = accessCodeInput.text.Split('=')[1];
                    GetTokenAsync(accessCode).Forget();
                })
                .AddTo(this);
        }

        async UniTaskVoid GetTokenAsync(string accessCode) {
            var getTokenForm = new WWWForm();
            {
                getTokenForm.AddField("grant_type", "authorization_code");
                getTokenForm.AddField("code", accessCode);
                getTokenForm.AddField("redirect_uri", Environment.RedirectUri);
            }
            using (var req = UnityWebRequest.Post(Endpoints.ApiToken, getTokenForm)) {
                var raw = $"{Environment.ClientId}:{Environment.ClientSecret}";
                req.SetRequestHeader("Authorization", $"Basic {Util.ToBase64(raw)}");
                await req.SendWebRequest().WithCancellation(this.GetCancellationTokenOnDestroy());
                var token = JsonUtility.FromJson<TokenModel>(req.downloadHandler.text);
                Debug.Log(token.AccessToken);
            }
        }
    }
}
