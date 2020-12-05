using System;
using System.Text;

namespace SpotifyApi {
    public static class Util {
        public static string ToBase64(string str) => Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
    }
}
