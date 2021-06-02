using System;
using System.Net;
using System.Threading;
using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Models;
using UnityEngine;

namespace n5y.SpotifyApi {
    public class TokenFactory : ITokenProvider, ITokenValidation {
        readonly string clientId;
        readonly string clientSecret;
        readonly string redirectUrl;

        string refreshToken;
        AccessTokenTuple accessToken;

        public TokenFactory(string clientId, string clientSecret, string redirectUrl) {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.redirectUrl = redirectUrl;
        }

        public async UniTask<ITokenProvider> AuthorizeAsync(CancellationToken cancellationToken) {
            var url = Api.GetAuthorizeUrl(clientId, redirectUrl, Scopes.All());
            var httpListener = new HttpListener();
            httpListener.Prefixes.Clear();
            httpListener.Prefixes.Add(redirectUrl);
            httpListener.Start();
            // ブラウザを開いて同意されるまで待つ
            Application.OpenURL(url);
            var context = await httpListener.GetContextAsync();
            var rawUrl = context.Request.RawUrl;
            var accepted = !rawUrl.Contains("error=access_denied");
            // codeを取得
            var code = "";
            if (accepted) {
                code = rawUrl.Split('=')[1];
            }
            // ブラウザにメッセージを表示
            var htmlMessage = accepted ? "thank you! Go back to unity" : "please retry and accept.";
            var hullHtml =  $"<!DOCTYPE html><html> <head><meta charset=\"utf-8\"></head><body>{htmlMessage}</body></html>";
            context.Response.Headers.Add("HttpResponseStatus:OK");
            context.Response.ContentLength64 = hullHtml.Length;
            context.Response.ContentType = "text/html";
            await context.Response.OutputStream.WriteAsync(System.Text.Encoding.UTF8.GetBytes(hullHtml), 0,
                hullHtml.Length, cancellationToken);
            await context.Response.OutputStream.FlushAsync(cancellationToken);
            // 解放
            context.Response.Close();
            httpListener.Close();
            // codeからtokenを取得
            var token = await Api.GetTokenAsync(code, redirectUrl, clientId, clientSecret, cancellationToken);
            if (token == null) return new EmptyTokenProvider();
            accessToken = new AccessTokenTuple(token.AccessToken, token.ExpiresIn, GetNowDateTime());
            refreshToken = token.RefreshToken;
            return this;
        }

        public async UniTask<ITokenProvider> AuthorizeByRefreshTokenAsync(string localRefreshToken, CancellationToken cancellationToken) {
            var token = await Api.RefreshTokenAsync(localRefreshToken, clientId, clientSecret, cancellationToken);
            if (token == null) return new EmptyTokenProvider();
            accessToken = new AccessTokenTuple(token.AccessToken, token.ExpiresIn, GetNowDateTime());
            refreshToken = token.RefreshToken;
            return this;
        }

        public string GetAuthorizationHeaderValue() => $"Bearer {accessToken.value}";
        public DateTime GetNowDateTime() => DateTime.Now;
        public string GetRefreshToken() => refreshToken;

        public async UniTask ValidateAsync(CancellationToken cancellationToken) {
            if (accessToken.IsExpired(GetNowDateTime())) {
                await AuthorizeByRefreshTokenAsync(GetRefreshToken(), cancellationToken);
            }
        }
    }

    readonly struct AccessTokenTuple {
        public readonly string value;
        public readonly int expiresIn;
        public readonly DateTime createdAt;

        public AccessTokenTuple(string value, int expiresIn, DateTime createdAt) {
            this.value = value;
            this.expiresIn = expiresIn;
            this.createdAt = createdAt;
        }

        public bool IsExpired(DateTime now) {
            return createdAt.AddSeconds(expiresIn).ToBinary() > now.ToBinary();
        }
    }
}
