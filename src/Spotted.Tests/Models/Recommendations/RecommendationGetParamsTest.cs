using Spotted.Models.Recommendations;

namespace Spotted.Tests.Models.Recommendations;

public class RecommendationGetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RecommendationGetParams
        {
            Limit = 10,
            Market = "ES",
            MaxAcousticness = 0,
            MaxDanceability = 0,
            MaxDurationMs = 0,
            MaxEnergy = 0,
            MaxInstrumentalness = 0,
            MaxKey = 0,
            MaxLiveness = 0,
            MaxLoudness = 0,
            MaxMode = 0,
            MaxPopularity = 0,
            MaxSpeechiness = 0,
            MaxTempo = 0,
            MaxTimeSignature = 0,
            MaxValence = 0,
            MinAcousticness = 0,
            MinDanceability = 0,
            MinDurationMs = 0,
            MinEnergy = 0,
            MinInstrumentalness = 0,
            MinKey = 0,
            MinLiveness = 0,
            MinLoudness = 0,
            MinMode = 0,
            MinPopularity = 0,
            MinSpeechiness = 0,
            MinTempo = 0,
            MinTimeSignature = 11,
            MinValence = 0,
            SeedArtists = "4NHQUGzhtTLFvgF5SZesLK",
            SeedGenres = "classical,country",
            SeedTracks = "0c6xIDDpzE81m2q797ordA",
            TargetAcousticness = 0,
            TargetDanceability = 0,
            TargetDurationMs = 0,
            TargetEnergy = 0,
            TargetInstrumentalness = 0,
            TargetKey = 0,
            TargetLiveness = 0,
            TargetLoudness = 0,
            TargetMode = 0,
            TargetPopularity = 0,
            TargetSpeechiness = 0,
            TargetTempo = 0,
            TargetTimeSignature = 0,
            TargetValence = 0,
        };

        long expectedLimit = 10;
        string expectedMarket = "ES";
        double expectedMaxAcousticness = 0;
        double expectedMaxDanceability = 0;
        long expectedMaxDurationMs = 0;
        double expectedMaxEnergy = 0;
        double expectedMaxInstrumentalness = 0;
        long expectedMaxKey = 0;
        double expectedMaxLiveness = 0;
        double expectedMaxLoudness = 0;
        long expectedMaxMode = 0;
        long expectedMaxPopularity = 0;
        double expectedMaxSpeechiness = 0;
        double expectedMaxTempo = 0;
        long expectedMaxTimeSignature = 0;
        double expectedMaxValence = 0;
        double expectedMinAcousticness = 0;
        double expectedMinDanceability = 0;
        long expectedMinDurationMs = 0;
        double expectedMinEnergy = 0;
        double expectedMinInstrumentalness = 0;
        long expectedMinKey = 0;
        double expectedMinLiveness = 0;
        double expectedMinLoudness = 0;
        long expectedMinMode = 0;
        long expectedMinPopularity = 0;
        double expectedMinSpeechiness = 0;
        double expectedMinTempo = 0;
        long expectedMinTimeSignature = 11;
        double expectedMinValence = 0;
        string expectedSeedArtists = "4NHQUGzhtTLFvgF5SZesLK";
        string expectedSeedGenres = "classical,country";
        string expectedSeedTracks = "0c6xIDDpzE81m2q797ordA";
        double expectedTargetAcousticness = 0;
        double expectedTargetDanceability = 0;
        long expectedTargetDurationMs = 0;
        double expectedTargetEnergy = 0;
        double expectedTargetInstrumentalness = 0;
        long expectedTargetKey = 0;
        double expectedTargetLiveness = 0;
        double expectedTargetLoudness = 0;
        long expectedTargetMode = 0;
        long expectedTargetPopularity = 0;
        double expectedTargetSpeechiness = 0;
        double expectedTargetTempo = 0;
        long expectedTargetTimeSignature = 0;
        double expectedTargetValence = 0;

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMarket, parameters.Market);
        Assert.Equal(expectedMaxAcousticness, parameters.MaxAcousticness);
        Assert.Equal(expectedMaxDanceability, parameters.MaxDanceability);
        Assert.Equal(expectedMaxDurationMs, parameters.MaxDurationMs);
        Assert.Equal(expectedMaxEnergy, parameters.MaxEnergy);
        Assert.Equal(expectedMaxInstrumentalness, parameters.MaxInstrumentalness);
        Assert.Equal(expectedMaxKey, parameters.MaxKey);
        Assert.Equal(expectedMaxLiveness, parameters.MaxLiveness);
        Assert.Equal(expectedMaxLoudness, parameters.MaxLoudness);
        Assert.Equal(expectedMaxMode, parameters.MaxMode);
        Assert.Equal(expectedMaxPopularity, parameters.MaxPopularity);
        Assert.Equal(expectedMaxSpeechiness, parameters.MaxSpeechiness);
        Assert.Equal(expectedMaxTempo, parameters.MaxTempo);
        Assert.Equal(expectedMaxTimeSignature, parameters.MaxTimeSignature);
        Assert.Equal(expectedMaxValence, parameters.MaxValence);
        Assert.Equal(expectedMinAcousticness, parameters.MinAcousticness);
        Assert.Equal(expectedMinDanceability, parameters.MinDanceability);
        Assert.Equal(expectedMinDurationMs, parameters.MinDurationMs);
        Assert.Equal(expectedMinEnergy, parameters.MinEnergy);
        Assert.Equal(expectedMinInstrumentalness, parameters.MinInstrumentalness);
        Assert.Equal(expectedMinKey, parameters.MinKey);
        Assert.Equal(expectedMinLiveness, parameters.MinLiveness);
        Assert.Equal(expectedMinLoudness, parameters.MinLoudness);
        Assert.Equal(expectedMinMode, parameters.MinMode);
        Assert.Equal(expectedMinPopularity, parameters.MinPopularity);
        Assert.Equal(expectedMinSpeechiness, parameters.MinSpeechiness);
        Assert.Equal(expectedMinTempo, parameters.MinTempo);
        Assert.Equal(expectedMinTimeSignature, parameters.MinTimeSignature);
        Assert.Equal(expectedMinValence, parameters.MinValence);
        Assert.Equal(expectedSeedArtists, parameters.SeedArtists);
        Assert.Equal(expectedSeedGenres, parameters.SeedGenres);
        Assert.Equal(expectedSeedTracks, parameters.SeedTracks);
        Assert.Equal(expectedTargetAcousticness, parameters.TargetAcousticness);
        Assert.Equal(expectedTargetDanceability, parameters.TargetDanceability);
        Assert.Equal(expectedTargetDurationMs, parameters.TargetDurationMs);
        Assert.Equal(expectedTargetEnergy, parameters.TargetEnergy);
        Assert.Equal(expectedTargetInstrumentalness, parameters.TargetInstrumentalness);
        Assert.Equal(expectedTargetKey, parameters.TargetKey);
        Assert.Equal(expectedTargetLiveness, parameters.TargetLiveness);
        Assert.Equal(expectedTargetLoudness, parameters.TargetLoudness);
        Assert.Equal(expectedTargetMode, parameters.TargetMode);
        Assert.Equal(expectedTargetPopularity, parameters.TargetPopularity);
        Assert.Equal(expectedTargetSpeechiness, parameters.TargetSpeechiness);
        Assert.Equal(expectedTargetTempo, parameters.TargetTempo);
        Assert.Equal(expectedTargetTimeSignature, parameters.TargetTimeSignature);
        Assert.Equal(expectedTargetValence, parameters.TargetValence);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RecommendationGetParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.MaxAcousticness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_acousticness"));
        Assert.Null(parameters.MaxDanceability);
        Assert.False(parameters.RawQueryData.ContainsKey("max_danceability"));
        Assert.Null(parameters.MaxDurationMs);
        Assert.False(parameters.RawQueryData.ContainsKey("max_duration_ms"));
        Assert.Null(parameters.MaxEnergy);
        Assert.False(parameters.RawQueryData.ContainsKey("max_energy"));
        Assert.Null(parameters.MaxInstrumentalness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_instrumentalness"));
        Assert.Null(parameters.MaxKey);
        Assert.False(parameters.RawQueryData.ContainsKey("max_key"));
        Assert.Null(parameters.MaxLiveness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_liveness"));
        Assert.Null(parameters.MaxLoudness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_loudness"));
        Assert.Null(parameters.MaxMode);
        Assert.False(parameters.RawQueryData.ContainsKey("max_mode"));
        Assert.Null(parameters.MaxPopularity);
        Assert.False(parameters.RawQueryData.ContainsKey("max_popularity"));
        Assert.Null(parameters.MaxSpeechiness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_speechiness"));
        Assert.Null(parameters.MaxTempo);
        Assert.False(parameters.RawQueryData.ContainsKey("max_tempo"));
        Assert.Null(parameters.MaxTimeSignature);
        Assert.False(parameters.RawQueryData.ContainsKey("max_time_signature"));
        Assert.Null(parameters.MaxValence);
        Assert.False(parameters.RawQueryData.ContainsKey("max_valence"));
        Assert.Null(parameters.MinAcousticness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_acousticness"));
        Assert.Null(parameters.MinDanceability);
        Assert.False(parameters.RawQueryData.ContainsKey("min_danceability"));
        Assert.Null(parameters.MinDurationMs);
        Assert.False(parameters.RawQueryData.ContainsKey("min_duration_ms"));
        Assert.Null(parameters.MinEnergy);
        Assert.False(parameters.RawQueryData.ContainsKey("min_energy"));
        Assert.Null(parameters.MinInstrumentalness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_instrumentalness"));
        Assert.Null(parameters.MinKey);
        Assert.False(parameters.RawQueryData.ContainsKey("min_key"));
        Assert.Null(parameters.MinLiveness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_liveness"));
        Assert.Null(parameters.MinLoudness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_loudness"));
        Assert.Null(parameters.MinMode);
        Assert.False(parameters.RawQueryData.ContainsKey("min_mode"));
        Assert.Null(parameters.MinPopularity);
        Assert.False(parameters.RawQueryData.ContainsKey("min_popularity"));
        Assert.Null(parameters.MinSpeechiness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_speechiness"));
        Assert.Null(parameters.MinTempo);
        Assert.False(parameters.RawQueryData.ContainsKey("min_tempo"));
        Assert.Null(parameters.MinTimeSignature);
        Assert.False(parameters.RawQueryData.ContainsKey("min_time_signature"));
        Assert.Null(parameters.MinValence);
        Assert.False(parameters.RawQueryData.ContainsKey("min_valence"));
        Assert.Null(parameters.SeedArtists);
        Assert.False(parameters.RawQueryData.ContainsKey("seed_artists"));
        Assert.Null(parameters.SeedGenres);
        Assert.False(parameters.RawQueryData.ContainsKey("seed_genres"));
        Assert.Null(parameters.SeedTracks);
        Assert.False(parameters.RawQueryData.ContainsKey("seed_tracks"));
        Assert.Null(parameters.TargetAcousticness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_acousticness"));
        Assert.Null(parameters.TargetDanceability);
        Assert.False(parameters.RawQueryData.ContainsKey("target_danceability"));
        Assert.Null(parameters.TargetDurationMs);
        Assert.False(parameters.RawQueryData.ContainsKey("target_duration_ms"));
        Assert.Null(parameters.TargetEnergy);
        Assert.False(parameters.RawQueryData.ContainsKey("target_energy"));
        Assert.Null(parameters.TargetInstrumentalness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_instrumentalness"));
        Assert.Null(parameters.TargetKey);
        Assert.False(parameters.RawQueryData.ContainsKey("target_key"));
        Assert.Null(parameters.TargetLiveness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_liveness"));
        Assert.Null(parameters.TargetLoudness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_loudness"));
        Assert.Null(parameters.TargetMode);
        Assert.False(parameters.RawQueryData.ContainsKey("target_mode"));
        Assert.Null(parameters.TargetPopularity);
        Assert.False(parameters.RawQueryData.ContainsKey("target_popularity"));
        Assert.Null(parameters.TargetSpeechiness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_speechiness"));
        Assert.Null(parameters.TargetTempo);
        Assert.False(parameters.RawQueryData.ContainsKey("target_tempo"));
        Assert.Null(parameters.TargetTimeSignature);
        Assert.False(parameters.RawQueryData.ContainsKey("target_time_signature"));
        Assert.Null(parameters.TargetValence);
        Assert.False(parameters.RawQueryData.ContainsKey("target_valence"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RecommendationGetParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Market = null,
            MaxAcousticness = null,
            MaxDanceability = null,
            MaxDurationMs = null,
            MaxEnergy = null,
            MaxInstrumentalness = null,
            MaxKey = null,
            MaxLiveness = null,
            MaxLoudness = null,
            MaxMode = null,
            MaxPopularity = null,
            MaxSpeechiness = null,
            MaxTempo = null,
            MaxTimeSignature = null,
            MaxValence = null,
            MinAcousticness = null,
            MinDanceability = null,
            MinDurationMs = null,
            MinEnergy = null,
            MinInstrumentalness = null,
            MinKey = null,
            MinLiveness = null,
            MinLoudness = null,
            MinMode = null,
            MinPopularity = null,
            MinSpeechiness = null,
            MinTempo = null,
            MinTimeSignature = null,
            MinValence = null,
            SeedArtists = null,
            SeedGenres = null,
            SeedTracks = null,
            TargetAcousticness = null,
            TargetDanceability = null,
            TargetDurationMs = null,
            TargetEnergy = null,
            TargetInstrumentalness = null,
            TargetKey = null,
            TargetLiveness = null,
            TargetLoudness = null,
            TargetMode = null,
            TargetPopularity = null,
            TargetSpeechiness = null,
            TargetTempo = null,
            TargetTimeSignature = null,
            TargetValence = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.MaxAcousticness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_acousticness"));
        Assert.Null(parameters.MaxDanceability);
        Assert.False(parameters.RawQueryData.ContainsKey("max_danceability"));
        Assert.Null(parameters.MaxDurationMs);
        Assert.False(parameters.RawQueryData.ContainsKey("max_duration_ms"));
        Assert.Null(parameters.MaxEnergy);
        Assert.False(parameters.RawQueryData.ContainsKey("max_energy"));
        Assert.Null(parameters.MaxInstrumentalness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_instrumentalness"));
        Assert.Null(parameters.MaxKey);
        Assert.False(parameters.RawQueryData.ContainsKey("max_key"));
        Assert.Null(parameters.MaxLiveness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_liveness"));
        Assert.Null(parameters.MaxLoudness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_loudness"));
        Assert.Null(parameters.MaxMode);
        Assert.False(parameters.RawQueryData.ContainsKey("max_mode"));
        Assert.Null(parameters.MaxPopularity);
        Assert.False(parameters.RawQueryData.ContainsKey("max_popularity"));
        Assert.Null(parameters.MaxSpeechiness);
        Assert.False(parameters.RawQueryData.ContainsKey("max_speechiness"));
        Assert.Null(parameters.MaxTempo);
        Assert.False(parameters.RawQueryData.ContainsKey("max_tempo"));
        Assert.Null(parameters.MaxTimeSignature);
        Assert.False(parameters.RawQueryData.ContainsKey("max_time_signature"));
        Assert.Null(parameters.MaxValence);
        Assert.False(parameters.RawQueryData.ContainsKey("max_valence"));
        Assert.Null(parameters.MinAcousticness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_acousticness"));
        Assert.Null(parameters.MinDanceability);
        Assert.False(parameters.RawQueryData.ContainsKey("min_danceability"));
        Assert.Null(parameters.MinDurationMs);
        Assert.False(parameters.RawQueryData.ContainsKey("min_duration_ms"));
        Assert.Null(parameters.MinEnergy);
        Assert.False(parameters.RawQueryData.ContainsKey("min_energy"));
        Assert.Null(parameters.MinInstrumentalness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_instrumentalness"));
        Assert.Null(parameters.MinKey);
        Assert.False(parameters.RawQueryData.ContainsKey("min_key"));
        Assert.Null(parameters.MinLiveness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_liveness"));
        Assert.Null(parameters.MinLoudness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_loudness"));
        Assert.Null(parameters.MinMode);
        Assert.False(parameters.RawQueryData.ContainsKey("min_mode"));
        Assert.Null(parameters.MinPopularity);
        Assert.False(parameters.RawQueryData.ContainsKey("min_popularity"));
        Assert.Null(parameters.MinSpeechiness);
        Assert.False(parameters.RawQueryData.ContainsKey("min_speechiness"));
        Assert.Null(parameters.MinTempo);
        Assert.False(parameters.RawQueryData.ContainsKey("min_tempo"));
        Assert.Null(parameters.MinTimeSignature);
        Assert.False(parameters.RawQueryData.ContainsKey("min_time_signature"));
        Assert.Null(parameters.MinValence);
        Assert.False(parameters.RawQueryData.ContainsKey("min_valence"));
        Assert.Null(parameters.SeedArtists);
        Assert.False(parameters.RawQueryData.ContainsKey("seed_artists"));
        Assert.Null(parameters.SeedGenres);
        Assert.False(parameters.RawQueryData.ContainsKey("seed_genres"));
        Assert.Null(parameters.SeedTracks);
        Assert.False(parameters.RawQueryData.ContainsKey("seed_tracks"));
        Assert.Null(parameters.TargetAcousticness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_acousticness"));
        Assert.Null(parameters.TargetDanceability);
        Assert.False(parameters.RawQueryData.ContainsKey("target_danceability"));
        Assert.Null(parameters.TargetDurationMs);
        Assert.False(parameters.RawQueryData.ContainsKey("target_duration_ms"));
        Assert.Null(parameters.TargetEnergy);
        Assert.False(parameters.RawQueryData.ContainsKey("target_energy"));
        Assert.Null(parameters.TargetInstrumentalness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_instrumentalness"));
        Assert.Null(parameters.TargetKey);
        Assert.False(parameters.RawQueryData.ContainsKey("target_key"));
        Assert.Null(parameters.TargetLiveness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_liveness"));
        Assert.Null(parameters.TargetLoudness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_loudness"));
        Assert.Null(parameters.TargetMode);
        Assert.False(parameters.RawQueryData.ContainsKey("target_mode"));
        Assert.Null(parameters.TargetPopularity);
        Assert.False(parameters.RawQueryData.ContainsKey("target_popularity"));
        Assert.Null(parameters.TargetSpeechiness);
        Assert.False(parameters.RawQueryData.ContainsKey("target_speechiness"));
        Assert.Null(parameters.TargetTempo);
        Assert.False(parameters.RawQueryData.ContainsKey("target_tempo"));
        Assert.Null(parameters.TargetTimeSignature);
        Assert.False(parameters.RawQueryData.ContainsKey("target_time_signature"));
        Assert.Null(parameters.TargetValence);
        Assert.False(parameters.RawQueryData.ContainsKey("target_valence"));
    }
}
