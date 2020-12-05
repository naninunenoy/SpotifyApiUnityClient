using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SpotifyApi.Models;
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
            var authUrl = Api.GetAuthorizeUrl(Environment.ClientId, Environment.RedirectUri);
            startAuthButton
                .OnClickAsObservable()
                .Subscribe(_ => {
                    attentionText.gameObject.SetActive(true);
                    Application.OpenURL(authUrl);
                })
                .AddTo(this);
            getTokenButton
                .OnClickAsObservable()
                .Subscribe(async _ => {
                    if (string.IsNullOrEmpty(accessCodeInput.text)) return;
                    var accessCode = accessCodeInput.text.Split('=')[1];
                    var token = await Api.GetTokenAsync(accessCode,
                        Environment.RedirectUri, Environment.ClientId, Environment.ClientSecret,
                        this.GetCancellationTokenOnDestroy());
                    Debug.Log(token.AccessToken);
                })
                .AddTo(this);
        }
    }
}
