using System;
using System.Text;

namespace SpotifyApi {
    public static class SpotifyApiUtil {
        public static string ToBase64(string str) => Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
    }
}
