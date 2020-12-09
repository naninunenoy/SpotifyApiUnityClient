namespace SpotifyApi.Models {
    public enum RepeatState {
        Track = 0,
        Context,
        Off
    }

    public static class RepeatStateEx {
        public static string Value(this RepeatState repeatState) {
            switch (repeatState) {
                case RepeatState.Track: return "track";
                case RepeatState.Context: return "context";
                case RepeatState.Off:
                default:
                    return "off";
            }
        }
    }
}
