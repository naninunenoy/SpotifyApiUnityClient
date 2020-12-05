using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpotifyApi {
    public static partial class Api {
        public static string GetAuthorizeUrl(string clientId, string redirectUrl) =>
            $"{Endpoints.Authorize}?client_id={clientId}&response_type=code&redirect_uri={redirectUrl}";
    }
}
