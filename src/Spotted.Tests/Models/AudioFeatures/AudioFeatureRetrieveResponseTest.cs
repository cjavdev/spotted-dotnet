using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.AudioFeatures;

namespace Spotted.Tests.Models.AudioFeatures;

public class AudioFeatureRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudioFeatureRetrieveResponse
        {
            ID = "2takcwOaAZWiXQijPHIx7B",
            Acousticness = 0.00242f,
            AnalysisURL = "https://api.spotify.com/v1/audio-analysis/2takcwOaAZWiXQijPHIx7B\n",
            Danceability = 0.585f,
            DurationMs = 237040,
            Energy = 0.842f,
            Instrumentalness = 0.00686f,
            Key = 9,
            Liveness = 0.0866f,
            Loudness = -5.883f,
            Mode = 0,
            Speechiness = 0.0556f,
            Tempo = 118.211f,
            TimeSignature = 4,
            TrackHref = "https://api.spotify.com/v1/tracks/2takcwOaAZWiXQijPHIx7B\n",
            Type = Type.AudioFeatures,
            Uri = "spotify:track:2takcwOaAZWiXQijPHIx7B",
            Valence = 0.428f,
        };

        string expectedID = "2takcwOaAZWiXQijPHIx7B";
        float expectedAcousticness = 0.00242f;
        string expectedAnalysisURL =
            "https://api.spotify.com/v1/audio-analysis/2takcwOaAZWiXQijPHIx7B\n";
        float expectedDanceability = 0.585f;
        long expectedDurationMs = 237040;
        float expectedEnergy = 0.842f;
        float expectedInstrumentalness = 0.00686f;
        long expectedKey = 9;
        float expectedLiveness = 0.0866f;
        float expectedLoudness = -5.883f;
        long expectedMode = 0;
        float expectedSpeechiness = 0.0556f;
        float expectedTempo = 118.211f;
        long expectedTimeSignature = 4;
        string expectedTrackHref = "https://api.spotify.com/v1/tracks/2takcwOaAZWiXQijPHIx7B\n";
        ApiEnum<string, Type> expectedType = Type.AudioFeatures;
        string expectedUri = "spotify:track:2takcwOaAZWiXQijPHIx7B";
        float expectedValence = 0.428f;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAcousticness, model.Acousticness);
        Assert.Equal(expectedAnalysisURL, model.AnalysisURL);
        Assert.Equal(expectedDanceability, model.Danceability);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedEnergy, model.Energy);
        Assert.Equal(expectedInstrumentalness, model.Instrumentalness);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedLiveness, model.Liveness);
        Assert.Equal(expectedLoudness, model.Loudness);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedSpeechiness, model.Speechiness);
        Assert.Equal(expectedTempo, model.Tempo);
        Assert.Equal(expectedTimeSignature, model.TimeSignature);
        Assert.Equal(expectedTrackHref, model.TrackHref);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
        Assert.Equal(expectedValence, model.Valence);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudioFeatureRetrieveResponse
        {
            ID = "2takcwOaAZWiXQijPHIx7B",
            Acousticness = 0.00242f,
            AnalysisURL = "https://api.spotify.com/v1/audio-analysis/2takcwOaAZWiXQijPHIx7B\n",
            Danceability = 0.585f,
            DurationMs = 237040,
            Energy = 0.842f,
            Instrumentalness = 0.00686f,
            Key = 9,
            Liveness = 0.0866f,
            Loudness = -5.883f,
            Mode = 0,
            Speechiness = 0.0556f,
            Tempo = 118.211f,
            TimeSignature = 4,
            TrackHref = "https://api.spotify.com/v1/tracks/2takcwOaAZWiXQijPHIx7B\n",
            Type = Type.AudioFeatures,
            Uri = "spotify:track:2takcwOaAZWiXQijPHIx7B",
            Valence = 0.428f,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudioFeatureRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudioFeatureRetrieveResponse
        {
            ID = "2takcwOaAZWiXQijPHIx7B",
            Acousticness = 0.00242f,
            AnalysisURL = "https://api.spotify.com/v1/audio-analysis/2takcwOaAZWiXQijPHIx7B\n",
            Danceability = 0.585f,
            DurationMs = 237040,
            Energy = 0.842f,
            Instrumentalness = 0.00686f,
            Key = 9,
            Liveness = 0.0866f,
            Loudness = -5.883f,
            Mode = 0,
            Speechiness = 0.0556f,
            Tempo = 118.211f,
            TimeSignature = 4,
            TrackHref = "https://api.spotify.com/v1/tracks/2takcwOaAZWiXQijPHIx7B\n",
            Type = Type.AudioFeatures,
            Uri = "spotify:track:2takcwOaAZWiXQijPHIx7B",
            Valence = 0.428f,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudioFeatureRetrieveResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "2takcwOaAZWiXQijPHIx7B";
        float expectedAcousticness = 0.00242f;
        string expectedAnalysisURL =
            "https://api.spotify.com/v1/audio-analysis/2takcwOaAZWiXQijPHIx7B\n";
        float expectedDanceability = 0.585f;
        long expectedDurationMs = 237040;
        float expectedEnergy = 0.842f;
        float expectedInstrumentalness = 0.00686f;
        long expectedKey = 9;
        float expectedLiveness = 0.0866f;
        float expectedLoudness = -5.883f;
        long expectedMode = 0;
        float expectedSpeechiness = 0.0556f;
        float expectedTempo = 118.211f;
        long expectedTimeSignature = 4;
        string expectedTrackHref = "https://api.spotify.com/v1/tracks/2takcwOaAZWiXQijPHIx7B\n";
        ApiEnum<string, Type> expectedType = Type.AudioFeatures;
        string expectedUri = "spotify:track:2takcwOaAZWiXQijPHIx7B";
        float expectedValence = 0.428f;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAcousticness, deserialized.Acousticness);
        Assert.Equal(expectedAnalysisURL, deserialized.AnalysisURL);
        Assert.Equal(expectedDanceability, deserialized.Danceability);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedEnergy, deserialized.Energy);
        Assert.Equal(expectedInstrumentalness, deserialized.Instrumentalness);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedLiveness, deserialized.Liveness);
        Assert.Equal(expectedLoudness, deserialized.Loudness);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedSpeechiness, deserialized.Speechiness);
        Assert.Equal(expectedTempo, deserialized.Tempo);
        Assert.Equal(expectedTimeSignature, deserialized.TimeSignature);
        Assert.Equal(expectedTrackHref, deserialized.TrackHref);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.Equal(expectedValence, deserialized.Valence);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudioFeatureRetrieveResponse
        {
            ID = "2takcwOaAZWiXQijPHIx7B",
            Acousticness = 0.00242f,
            AnalysisURL = "https://api.spotify.com/v1/audio-analysis/2takcwOaAZWiXQijPHIx7B\n",
            Danceability = 0.585f,
            DurationMs = 237040,
            Energy = 0.842f,
            Instrumentalness = 0.00686f,
            Key = 9,
            Liveness = 0.0866f,
            Loudness = -5.883f,
            Mode = 0,
            Speechiness = 0.0556f,
            Tempo = 118.211f,
            TimeSignature = 4,
            TrackHref = "https://api.spotify.com/v1/tracks/2takcwOaAZWiXQijPHIx7B\n",
            Type = Type.AudioFeatures,
            Uri = "spotify:track:2takcwOaAZWiXQijPHIx7B",
            Valence = 0.428f,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AudioFeatureRetrieveResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Acousticness);
        Assert.False(model.RawData.ContainsKey("acousticness"));
        Assert.Null(model.AnalysisURL);
        Assert.False(model.RawData.ContainsKey("analysis_url"));
        Assert.Null(model.Danceability);
        Assert.False(model.RawData.ContainsKey("danceability"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.Energy);
        Assert.False(model.RawData.ContainsKey("energy"));
        Assert.Null(model.Instrumentalness);
        Assert.False(model.RawData.ContainsKey("instrumentalness"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.Liveness);
        Assert.False(model.RawData.ContainsKey("liveness"));
        Assert.Null(model.Loudness);
        Assert.False(model.RawData.ContainsKey("loudness"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Speechiness);
        Assert.False(model.RawData.ContainsKey("speechiness"));
        Assert.Null(model.Tempo);
        Assert.False(model.RawData.ContainsKey("tempo"));
        Assert.Null(model.TimeSignature);
        Assert.False(model.RawData.ContainsKey("time_signature"));
        Assert.Null(model.TrackHref);
        Assert.False(model.RawData.ContainsKey("track_href"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
        Assert.Null(model.Valence);
        Assert.False(model.RawData.ContainsKey("valence"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AudioFeatureRetrieveResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AudioFeatureRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Acousticness = null,
            AnalysisURL = null,
            Danceability = null,
            DurationMs = null,
            Energy = null,
            Instrumentalness = null,
            Key = null,
            Liveness = null,
            Loudness = null,
            Mode = null,
            Speechiness = null,
            Tempo = null,
            TimeSignature = null,
            TrackHref = null,
            Type = null,
            Uri = null,
            Valence = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Acousticness);
        Assert.False(model.RawData.ContainsKey("acousticness"));
        Assert.Null(model.AnalysisURL);
        Assert.False(model.RawData.ContainsKey("analysis_url"));
        Assert.Null(model.Danceability);
        Assert.False(model.RawData.ContainsKey("danceability"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.Energy);
        Assert.False(model.RawData.ContainsKey("energy"));
        Assert.Null(model.Instrumentalness);
        Assert.False(model.RawData.ContainsKey("instrumentalness"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.Liveness);
        Assert.False(model.RawData.ContainsKey("liveness"));
        Assert.Null(model.Loudness);
        Assert.False(model.RawData.ContainsKey("loudness"));
        Assert.Null(model.Mode);
        Assert.False(model.RawData.ContainsKey("mode"));
        Assert.Null(model.Speechiness);
        Assert.False(model.RawData.ContainsKey("speechiness"));
        Assert.Null(model.Tempo);
        Assert.False(model.RawData.ContainsKey("tempo"));
        Assert.Null(model.TimeSignature);
        Assert.False(model.RawData.ContainsKey("time_signature"));
        Assert.Null(model.TrackHref);
        Assert.False(model.RawData.ContainsKey("track_href"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
        Assert.Null(model.Valence);
        Assert.False(model.RawData.ContainsKey("valence"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AudioFeatureRetrieveResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Acousticness = null,
            AnalysisURL = null,
            Danceability = null,
            DurationMs = null,
            Energy = null,
            Instrumentalness = null,
            Key = null,
            Liveness = null,
            Loudness = null,
            Mode = null,
            Speechiness = null,
            Tempo = null,
            TimeSignature = null,
            TrackHref = null,
            Type = null,
            Uri = null,
            Valence = null,
        };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.AudioFeatures)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.AudioFeatures)]
    public void SerializationRoundtrip_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
