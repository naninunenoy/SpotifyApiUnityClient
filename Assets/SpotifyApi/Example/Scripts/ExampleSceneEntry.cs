using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SpotifyApi.Example {
    public class ExampleSceneEntry : MonoBehaviour {
        [SerializeField] Button startAuthButton = default;
        [SerializeField] Text attentionText = default;
        [SerializeField] InputField accessCodeInput = default;
        [SerializeField] Button getTokenButton = default;
        [SerializeField] Text helloText = default;

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
                    // token取得
                    if (string.IsNullOrEmpty(accessCodeInput.text)) return;
                    var accessCode = accessCodeInput.text.Split('=')[1];
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
    }
}
