using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.AudioFeatures;

[JsonConverter(
    typeof(ModelConverter<
        AudioFeatureBulkRetrieveResponse,
        AudioFeatureBulkRetrieveResponseFromRaw
    >)
)]
public sealed record class AudioFeatureBulkRetrieveResponse : ModelBase
{
    public required IReadOnlyList<AudioFeature> AudioFeatures
    {
        get
        {
            return ModelBase.GetNotNullClass<List<AudioFeature>>(this.RawData, "audio_features");
        }
        init { ModelBase.Set(this._rawData, "audio_features", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AudioFeatures)
        {
            item.Validate();
        }
    }

    public AudioFeatureBulkRetrieveResponse() { }

    public AudioFeatureBulkRetrieveResponse(
        AudioFeatureBulkRetrieveResponse audioFeatureBulkRetrieveResponse
    )
        : base(audioFeatureBulkRetrieveResponse) { }

    public AudioFeatureBulkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioFeatureBulkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudioFeatureBulkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AudioFeatureBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AudioFeatureBulkRetrieveResponse(List<AudioFeature> audioFeatures)
        : this()
    {
        this.AudioFeatures = audioFeatures;
    }
}

class AudioFeatureBulkRetrieveResponseFromRaw : IFromRaw<AudioFeatureBulkRetrieveResponse>
{
    /// <inheritdoc/>
    public AudioFeatureBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudioFeatureBulkRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<AudioFeature, AudioFeatureFromRaw>))]
public sealed record class AudioFeature : ModelBase
{
    /// <summary>
    /// The Spotify ID for the track.
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// A confidence measure from 0.0 to 1.0 of whether the track is acoustic. 1.0
    /// represents high confidence the track is acoustic.
    /// </summary>
    public float? Acousticness
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "acousticness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "acousticness", value);
        }
    }

    /// <summary>
    /// A URL to access the full audio analysis of this track. An access token is
    /// required to access this data.
    /// </summary>
    public string? AnalysisURL
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "analysis_url"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "analysis_url", value);
        }
    }

    /// <summary>
    /// Danceability describes how suitable a track is for dancing based on a combination
    /// of musical elements including tempo, rhythm stability, beat strength, and
    /// overall regularity. A value of 0.0 is least danceable and 1.0 is most danceable.
    /// </summary>
    public float? Danceability
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "danceability"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "danceability", value);
        }
    }

    /// <summary>
    /// The duration of the track in milliseconds.
    /// </summary>
    public long? DurationMs
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "duration_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "duration_ms", value);
        }
    }

    /// <summary>
    /// Energy is a measure from 0.0 to 1.0 and represents a perceptual measure of
    /// intensity and activity. Typically, energetic tracks feel fast, loud, and
    /// noisy. For example, death metal has high energy, while a Bach prelude scores
    /// low on the scale. Perceptual features contributing to this attribute include
    /// dynamic range, perceived loudness, timbre, onset rate, and general entropy.
    /// </summary>
    public float? Energy
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "energy"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "energy", value);
        }
    }

    /// <summary>
    /// Predicts whether a track contains no vocals. "Ooh" and "aah" sounds are treated
    /// as instrumental in this context. Rap or spoken word tracks are clearly "vocal".
    /// The closer the instrumentalness value is to 1.0, the greater likelihood the
    /// track contains no vocal content. Values above 0.5 are intended to represent
    /// instrumental tracks, but confidence is higher as the value approaches 1.0.
    /// </summary>
    public float? Instrumentalness
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "instrumentalness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "instrumentalness", value);
        }
    }

    /// <summary>
    /// The key the track is in. Integers map to pitches using standard [Pitch Class
    /// notation](https://en.wikipedia.org/wiki/Pitch_class). E.g. 0 = C, 1 = C♯/D♭,
    /// 2 = D, and so on. If no key was detected, the value is -1.
    /// </summary>
    public long? Key
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "key"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "key", value);
        }
    }

    /// <summary>
    /// Detects the presence of an audience in the recording. Higher liveness values
    /// represent an increased probability that the track was performed live. A value
    /// above 0.8 provides strong likelihood that the track is live.
    /// </summary>
    public float? Liveness
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "liveness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "liveness", value);
        }
    }

    /// <summary>
    /// The overall loudness of a track in decibels (dB). Loudness values are averaged
    /// across the entire track and are useful for comparing relative loudness of
    /// tracks. Loudness is the quality of a sound that is the primary psychological
    /// correlate of physical strength (amplitude). Values typically range between
    /// -60 and 0 db.
    /// </summary>
    public float? Loudness
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "loudness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "loudness", value);
        }
    }

    /// <summary>
    /// Mode indicates the modality (major or minor) of a track, the type of scale
    /// from which its melodic content is derived. Major is represented by 1 and minor
    /// is 0.
    /// </summary>
    public long? Mode
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "mode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "mode", value);
        }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// Speechiness detects the presence of spoken words in a track. The more exclusively
    /// speech-like the recording (e.g. talk show, audio book, poetry), the closer
    /// to 1.0 the attribute value. Values above 0.66 describe tracks that are probably
    /// made entirely of spoken words. Values between 0.33 and 0.66 describe tracks
    /// that may contain both music and speech, either in sections or layered, including
    /// such cases as rap music. Values below 0.33 most likely represent music and
    /// other non-speech-like tracks.
    /// </summary>
    public float? Speechiness
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "speechiness"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "speechiness", value);
        }
    }

    /// <summary>
    /// The overall estimated tempo of a track in beats per minute (BPM). In musical
    /// terminology, tempo is the speed or pace of a given piece and derives directly
    /// from the average beat duration.
    /// </summary>
    public float? Tempo
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "tempo"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "tempo", value);
        }
    }

    /// <summary>
    /// An estimated time signature. The time signature (meter) is a notational convention
    /// to specify how many beats are in each bar (or measure). The time signature
    /// ranges from 3 to 7 indicating time signatures of "3/4", to "7/4".
    /// </summary>
    public long? TimeSignature
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "time_signature"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "time_signature", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the track.
    /// </summary>
    public string? TrackHref
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "track_href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "track_href", value);
        }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public ApiEnum<string, AudioFeatureType>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, AudioFeatureType>>(
                this.RawData,
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// The Spotify URI for the track.
    /// </summary>
    public string? Uri
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "uri", value);
        }
    }

    /// <summary>
    /// A measure from 0.0 to 1.0 describing the musical positiveness conveyed by
    /// a track. Tracks with high valence sound more positive (e.g. happy, cheerful,
    /// euphoric), while tracks with low valence sound more negative (e.g. sad, depressed,
    /// angry).
    /// </summary>
    public float? Valence
    {
        get { return ModelBase.GetNullableStruct<float>(this.RawData, "valence"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "valence", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Acousticness;
        _ = this.AnalysisURL;
        _ = this.Danceability;
        _ = this.DurationMs;
        _ = this.Energy;
        _ = this.Instrumentalness;
        _ = this.Key;
        _ = this.Liveness;
        _ = this.Loudness;
        _ = this.Mode;
        _ = this.Published;
        _ = this.Speechiness;
        _ = this.Tempo;
        _ = this.TimeSignature;
        _ = this.TrackHref;
        this.Type?.Validate();
        _ = this.Uri;
        _ = this.Valence;
    }

    public AudioFeature() { }

    public AudioFeature(AudioFeature audioFeature)
        : base(audioFeature) { }

    public AudioFeature(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioFeature(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudioFeatureFromRaw.FromRawUnchecked"/>
    public static AudioFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudioFeatureFromRaw : IFromRaw<AudioFeature>
{
    /// <inheritdoc/>
    public AudioFeature FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AudioFeature.FromRawUnchecked(rawData);
}

/// <summary>
/// The object type.
/// </summary>
[JsonConverter(typeof(AudioFeatureTypeConverter))]
public enum AudioFeatureType
{
    AudioFeatures,
}

sealed class AudioFeatureTypeConverter : JsonConverter<AudioFeatureType>
{
    public override AudioFeatureType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "audio_features" => AudioFeatureType.AudioFeatures,
            _ => (AudioFeatureType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AudioFeatureType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AudioFeatureType.AudioFeatures => "audio_features",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
