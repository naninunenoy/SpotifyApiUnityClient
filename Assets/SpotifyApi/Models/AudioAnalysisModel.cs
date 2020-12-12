using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class AudioAnalysisModel {
        [JsonProperty("bars")] public AudioAnalysisBars[] Bars { private set; get; }
        [JsonProperty("beats")] public AudioAnalysisBeats[] Beats { private set; get; }
        [JsonProperty("sections")] public AudioAnalysisSections[] Sections { private set; get; }
        [JsonProperty("segments")] public AudioAnalysisSegments[] Segments { private set; get; }
        [JsonProperty("tatums")] public AudioAnalysisTatums[] Tatums { private set; get; }
        [JsonProperty("track")] public AudioAnalysisTrack Track { private set; get; }
    }
    [JsonObject]
    public class AudioAnalysisBars {
        [JsonProperty("start")] public float Start { private set; get; }
        [JsonProperty("duration")] public float Duration { private set; get; }
        [JsonProperty("confidence")] public float Confidence { private set; get; }
    }
    [JsonObject]
    public class AudioAnalysisBeats {
        [JsonProperty("start")] public float Start { private set; get; }
        [JsonProperty("duration")] public float Duration { private set; get; }
        [JsonProperty("confidence")] public float Confidence { private set; get; }
    }
    [JsonObject]
    public class AudioAnalysisSections {
        [JsonProperty("start")] public float Start { private set; get; }
        [JsonProperty("duration")] public float Duration { private set; get; }
        [JsonProperty("confidence")] public float Confidence { private set; get; }
        [JsonProperty("loudness_start")] public float LoudnessStart { private set; get; }
        [JsonProperty("loudness")] public float Loudness { private set; get; }
        [JsonProperty("tempo")] public float Tempo { private set; get; }
        [JsonProperty("tempo_confidence")] public float TempoConfidence { private set; get; }
        [JsonProperty("key")] public int Key { private set; get; }
        [JsonProperty("key_confidence")] public float KeyConfidence { private set; get; }
        [JsonProperty("mode")] public int Mode { private set; get; }
        [JsonProperty("mode_confidence")] public float ModeConfidence { private set; get; }
        [JsonProperty("time_signature")] public int TimeSignature { private set; get; }
        [JsonProperty("time_signature_confidence")] public float TimeSignatureConfidence { private set; get; }
    }
    [JsonObject]
    public class AudioAnalysisSegments {
        [JsonProperty("start")] public float Start { private set; get; }
        [JsonProperty("duration")] public float Duration { private set; get; }
        [JsonProperty("confidence")] public float Confidence { private set; get; }
        [JsonProperty("loudness_start")] public float LoudnessStart { private set; get; }
        [JsonProperty("loudness_max_time")] public float LoudnessMaxTime { private set; get; }
        [JsonProperty("loudness_max")] public float LoudnessMax { private set; get; }
        [JsonProperty("loudness_end")] public float LoudnessEnd { private set; get; }
        [JsonProperty("pitches")] public float[] Pitches { private set; get; }
        [JsonProperty("timbre")] public float[] Timbre { private set; get; }
    }
    [JsonObject]
    public class AudioAnalysisTatums {
        [JsonProperty("start")] public float Start { private set; get; }
        [JsonProperty("duration")] public float Duration { private set; get; }
        [JsonProperty("confidence")] public float Confidence { private set; get; }

    }
    [JsonObject]
    public class AudioAnalysisTrack {
        [JsonProperty("duration")] public float Duration { private set; get; }
        [JsonProperty("sample_md5")] public string SampleMd5 { private set; get; }
        [JsonProperty("offset_seconds")] public int OffsetSeconds { private set; get; }
        [JsonProperty("window_seconds")] public int WindowSeconds { private set; get; }
        [JsonProperty("analysis_sample_rate")] public int AnalysisSampleRate { private set; get; }
        [JsonProperty("analysis_channels")] public int AnalysisChannels { private set; get; }
        [JsonProperty("end_of_fade_in")] public float EndOfFadeIn { private set; get; }
        [JsonProperty("start_of_fade_out")] public float StartOfFadeOut { private set; get; }
        [JsonProperty("loudness")] public float Loudness { private set; get; }
        [JsonProperty("tempo")] public float Tempo { private set; get; }
        [JsonProperty("tempo_confidence")] public float TempoConfidence { private set; get; }
        [JsonProperty("time_signature")] public int TimeSignature { private set; get; }
        [JsonProperty("time_signature_confidence")] public int TimeSignatureConfidence { private set; get; }
        [JsonProperty("key")] public int Key { private set; get; }
        [JsonProperty("key_confidence")] public float KeyConfidence { private set; get; }
        [JsonProperty("mode")] public int Mode { private set; get; }
        [JsonProperty("mode_confidence")] public float ModeConfidence { private set; get; }
        [JsonProperty("codestring")] public string Codestring { private set; get; }
        [JsonProperty("code_version")] public float CodeVersion { private set; get; }
        [JsonProperty("echoprintstring")] public string Echoprintstring { private set; get; }
        [JsonProperty("echoprint_version")] public float EchoprintVersion { private set; get; }
        [JsonProperty("synchstring")] public string Synchstring { private set; get; }
        [JsonProperty("synch_version")] public float SynchVersion { private set; get; }
        [JsonProperty("rhythmstring")] public string Rhythmstring { private set; get; }
        [JsonProperty("rhythm_version")] public float RhythmVersion { private set; get; }
    }
}
