namespace n5y.SpotifyApi.Models {
    public static class Scopes {
        public static class SpotifyConnect {
            public const string UserReadPlayBackState = "user-read-playback-state";
            public const string UserModifyPlayBackState = "user-modify-playback-state";
            public const string UserReadCurrentlyPlaying = "user-read-currently-playing";
        }
        public static class Playback {
            public const string AppRemoteControl = "app-remote-control";
            public const string Streaming = "streaming";
        }
        public static class Library {
            public const string Read = "user-library-read";
        }

        public static string All() => $"{SpotifyConnect.UserReadPlayBackState} " +
                                      $"{SpotifyConnect.UserModifyPlayBackState} " +
                                      $"{SpotifyConnect.UserReadCurrentlyPlaying} " +
                                      $"{Playback.AppRemoteControl} " +
                                      $"{Playback.Streaming} " +
                                      $"{Library.Read}";
    }
}
