using System;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace SpotifyApi {
    public static class Util {
        public static string ToBase64(string str) => Convert.ToBase64String(Encoding.UTF8.GetBytes(str));

        public static async UniTask<Texture2D> DownloadTextureAsync(string imageUrl, CancellationToken cancellationToken) {
            var r = UnityWebRequestTexture.GetTexture(imageUrl);
            cancellationToken.ThrowIfCancellationRequested();
            await r.SendWebRequest();
            return DownloadHandlerTexture.GetContent(r);
        }
        public static Sprite Texture2Sprite(Texture2D texture) {
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}
