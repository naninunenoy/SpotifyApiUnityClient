using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace n5y.SpotifyApi.Ui.Core {
    public class Url2Sprite {
        string lastLoadedUrl = "";
        Sprite lastLoadedSprite = default;

        public async UniTask<Sprite> GetSpriteFromUrl(string url, CancellationToken cancellationToken) {
            // 同じURLの画像を何回も読みに行かないように1つだけキャッシュしておく
            if (url == lastLoadedUrl && lastLoadedSprite != null) {
                return lastLoadedSprite;
            }

            var tex = await Util.DownloadTextureAsync(url, cancellationToken);
            var sprite = Util.Texture2Sprite(tex);
            lastLoadedUrl = url;
            lastLoadedSprite = sprite;
            return sprite;
        }
    }
}
