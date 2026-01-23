using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.AudioAnalysis;

[JsonConverter(
    typeof(JsonModelConverter<AudioAnalysisRetrieveResponse, AudioAnalysisRetrieveResponseFromRaw>)
)]
public sealed record class AudioAnalysisRetrieveResponse : JsonModel
{
    /// <summary>
    /// The time intervals of the bars throughout the track. A bar (or measure) is
    /// a segment of time defined as a given number of beats.
    /// </summary>
    public IReadOnlyList<TimeIntervalObject>? Bars
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TimeIntervalObject>>("bars");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TimeIntervalObject>?>(
                "bars",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The time intervals of beats throughout the track. A beat is the basic time
    /// unit of a piece of music; for example, each tick of a metronome. Beats are
    /// typically multiples of tatums.
    /// </summary>
    public IReadOnlyList<TimeIntervalObject>? Beats
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TimeIntervalObject>>("beats");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TimeIntervalObject>?>(
                "beats",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Meta? Meta
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>("meta");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("meta", value);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <summary>
    /// Sections are defined by large variations in rhythm or timbre, e.g. chorus,
    /// verse, bridge, guitar solo, etc. Each section contains its own descriptions
    /// of tempo, key, mode, time_signature, and loudness.
    /// </summary>
    public IReadOnlyList<Section>? Sections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Section>>("sections");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Section>?>(
                "sections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Each segment contains a roughly conisistent sound throughout its duration.
    /// </summary>
    public IReadOnlyList<Segment>? Segments
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Segment>>("segments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Segment>?>(
                "segments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A tatum represents the lowest regular pulse train that a listener intuitively
    /// infers from the timing of perceived musical events (segments).
    /// </summary>
    public IReadOnlyList<TimeIntervalObject>? Tatums
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TimeIntervalObject>>("tatums");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<TimeIntervalObject>?>(
                "tatums",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Track? Track
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Track>("track");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("track", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Bars ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Beats ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
        _ = this.Published;
        foreach (var item in this.Sections ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Segments ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Tatums ?? [])
        {
            item.Validate();
        }
        this.Track?.Validate();
    }

    public AudioAnalysisRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AudioAnalysisRetrieveResponse(
        AudioAnalysisRetrieveResponse audioAnalysisRetrieveResponse
    )
        : base(audioAnalysisRetrieveResponse) { }
#pragma warning restore CS8618

    public AudioAnalysisRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioAnalysisRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudioAnalysisRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AudioAnalysisRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudioAnalysisRetrieveResponseFromRaw : IFromRawJson<AudioAnalysisRetrieveResponse>
{
    /// <inheritdoc/>
    public AudioAnalysisRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudioAnalysisRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// The amount of time taken to analyze this track.
    /// </summary>
    public double? AnalysisTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("analysis_time");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("analysis_time", value);
        }
    }

    /// <summary>
    /// The version of the Analyzer used to analyze this track.
    /// </summary>
    public string? AnalyzerVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("analyzer_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("analyzer_version", value);
        }
    }

    /// <summary>
    /// A detailed status code for this track. If analysis data is missing, this code
    /// may explain why.
    /// </summary>
    public string? DetailedStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("detailed_status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("detailed_status", value);
        }
    }

    /// <summary>
    /// The method used to read the track's audio data.
    /// </summary>
    public string? InputProcess
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("input_process");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("input_process", value);
        }
    }

    /// <summary>
    /// The platform used to read the track's audio data.
    /// </summary>
    public string? Platform
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("platform");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("platform", value);
        }
    }

    /// <summary>
    /// The return code of the analyzer process. 0 if successful, 1 if any errors occurred.
    /// </summary>
    public long? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("status_code");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status_code", value);
        }
    }

    /// <summary>
    /// The Unix timestamp (in seconds) at which this track was analyzed.
    /// </summary>
    public long? Timestamp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("timestamp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AnalysisTime;
        _ = this.AnalyzerVersion;
        _ = this.DetailedStatus;
        _ = this.InputProcess;
        _ = this.Platform;
        _ = this.StatusCode;
        _ = this.Timestamp;
    }

    public Meta() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta(Meta meta)
        : base(meta) { }
#pragma warning restore CS8618

    public Meta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Meta.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Section, SectionFromRaw>))]
public sealed record class Section : JsonModel
{
    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the section's "designation".
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// The duration (in seconds) of the section.
    /// </summary>
    public double? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    /// <summary>
    /// The estimated overall key of the section. The values in this field ranging
    /// from 0 to 11 mapping to pitches using standard Pitch Class notation (E.g.
    /// 0 = C, 1 = C♯/D♭, 2 = D, and so on). If no key was detected, the value is -1.
    /// </summary>
    public long? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the key. Songs with
    /// many key changes may correspond to low values in this field.
    /// </summary>
    public double? KeyConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("key_confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key_confidence", value);
        }
    }

    /// <summary>
    /// The overall loudness of the section in decibels (dB). Loudness values are
    /// useful for comparing relative loudness of sections within tracks.
    /// </summary>
    public double? Loudness
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("loudness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loudness", value);
        }
    }

    /// <summary>
    /// Indicates the modality (major or minor) of a section, the type of scale from
    /// which its melodic content is derived. This field will contain a 0 for "minor",
    /// a 1 for "major", or a -1 for no result. Note that the major key (e.g. C major)
    /// could more likely be confused with the minor key at 3 semitones lower (e.g.
    /// A minor) as both keys carry the same pitches.
    /// </summary>
    public ApiEnum<double, Mode>? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<double, Mode>>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the `mode`.
    /// </summary>
    public double? ModeConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("mode_confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode_confidence", value);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <summary>
    /// The starting point (in seconds) of the section.
    /// </summary>
    public double? Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start", value);
        }
    }

    /// <summary>
    /// The overall estimated tempo of the section in beats per minute (BPM). In musical
    /// terminology, tempo is the speed or pace of a given piece and derives directly
    /// from the average beat duration.
    /// </summary>
    public double? Tempo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tempo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tempo", value);
        }
    }

    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the tempo. Some tracks
    /// contain tempo changes or sounds which don't contain tempo (like pure speech)
    /// which would correspond to a low value in this field.
    /// </summary>
    public double? TempoConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tempo_confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tempo_confidence", value);
        }
    }

    /// <summary>
    /// An estimated time signature. The time signature (meter) is a notational convention
    /// to specify how many beats are in each bar (or measure). The time signature
    /// ranges from 3 to 7 indicating time signatures of "3/4", to "7/4".
    /// </summary>
    public long? TimeSignature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("time_signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time_signature", value);
        }
    }

    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the `time_signature`.
    /// Sections with time signature changes may correspond to low values in this field.
    /// </summary>
    public double? TimeSignatureConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("time_signature_confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time_signature_confidence", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Duration;
        _ = this.Key;
        _ = this.KeyConfidence;
        _ = this.Loudness;
        this.Mode?.Validate();
        _ = this.ModeConfidence;
        _ = this.Published;
        _ = this.Start;
        _ = this.Tempo;
        _ = this.TempoConfidence;
        _ = this.TimeSignature;
        _ = this.TimeSignatureConfidence;
    }

    public Section() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Section(Section section)
        : base(section) { }
#pragma warning restore CS8618

    public Section(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Section(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SectionFromRaw.FromRawUnchecked"/>
    public static Section FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SectionFromRaw : IFromRawJson<Section>
{
    /// <inheritdoc/>
    public Section FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Section.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates the modality (major or minor) of a section, the type of scale from
/// which its melodic content is derived. This field will contain a 0 for "minor",
/// a 1 for "major", or a -1 for no result. Note that the major key (e.g. C major)
/// could more likely be confused with the minor key at 3 semitones lower (e.g. A
/// minor) as both keys carry the same pitches.
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    ModeNoResult,
    ModeMinor,
    ModeMajor,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<double>(ref reader, options) switch
        {
            -1 => Mode.ModeNoResult,
            0 => Mode.ModeMinor,
            1 => Mode.ModeMajor,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.ModeNoResult => -1,
                Mode.ModeMinor => 0,
                Mode.ModeMajor => 1,
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Segment, SegmentFromRaw>))]
public sealed record class Segment : JsonModel
{
    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the segmentation.
    /// Segments of the song which are difficult to logically segment (e.g: noise)
    /// may correspond to low values in this field.
    /// </summary>
    public double? Confidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("confidence", value);
        }
    }

    /// <summary>
    /// The duration (in seconds) of the segment.
    /// </summary>
    public double? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    /// <summary>
    /// The offset loudness of the segment in decibels (dB). This value should be
    /// equivalent to the loudness_start of the following segment.
    /// </summary>
    public double? LoudnessEnd
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("loudness_end");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loudness_end", value);
        }
    }

    /// <summary>
    /// The peak loudness of the segment in decibels (dB). Combined with `loudness_start`
    /// and `loudness_max_time`, these components can be used to describe the "attack"
    /// of the segment.
    /// </summary>
    public double? LoudnessMax
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("loudness_max");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loudness_max", value);
        }
    }

    /// <summary>
    /// The segment-relative offset of the segment peak loudness in seconds. Combined
    /// with `loudness_start` and `loudness_max`, these components can be used to
    /// desctibe the "attack" of the segment.
    /// </summary>
    public double? LoudnessMaxTime
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("loudness_max_time");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loudness_max_time", value);
        }
    }

    /// <summary>
    /// The onset loudness of the segment in decibels (dB). Combined with `loudness_max`
    /// and `loudness_max_time`, these components can be used to describe the "attack"
    /// of the segment.
    /// </summary>
    public double? LoudnessStart
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("loudness_start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loudness_start", value);
        }
    }

    /// <summary>
    /// Pitch content is given by a “chroma” vector, corresponding to the 12 pitch
    /// classes C, C#, D to B, with values ranging from 0 to 1 that describe the relative
    /// dominance of every pitch in the chromatic scale. For example a C Major chord
    /// would likely be represented by large values of C, E and G (i.e. classes 0,
    /// 4, and 7).
    ///
    /// <para>Vectors are normalized to 1 by their strongest dimension, therefore
    /// noisy sounds are likely represented by values that are all close to 1, while
    /// pure tones are described by one value at 1 (the pitch) and others near 0.
    /// As can be seen below, the 12 vector indices are a combination of low-power
    /// spectrum values at their respective pitch frequencies. ![pitch vector](/assets/audio/Pitch_vector.png) </para>
    /// </summary>
    public IReadOnlyList<double>? Pitches
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("pitches");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "pitches",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <summary>
    /// The starting point (in seconds) of the segment.
    /// </summary>
    public double? Start
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("start");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start", value);
        }
    }

    /// <summary>
    /// Timbre is the quality of a musical note or sound that distinguishes different
    /// types of musical instruments, or voices. It is a complex notion also referred
    /// to as sound color, texture, or tone quality, and is derived from the shape
    /// of a segment’s spectro-temporal surface, independently of pitch and loudness.
    /// The timbre feature is a vector that includes 12 unbounded values roughly
    /// centered around 0. Those values are high level abstractions of the spectral
    /// surface, ordered by degree of importance.
    ///
    /// <para>For completeness however, the first dimension represents the average
    /// loudness of the segment; second emphasizes brightness; third is more closely
    /// correlated to the flatness of a sound; fourth to sounds with a stronger attack;
    /// etc. See an image below representing the 12 basis functions (i.e. template
    /// segments). ![timbre basis functions](/assets/audio/Timbre_basis_functions.png)</para>
    ///
    /// <para>The actual timbre of the segment is best described as a linear combination
    /// of these 12 basis functions weighted by the coefficient values: timbre = c1
    /// x b1 + c2 x b2 + ... + c12 x b12, where c1 to c12 represent the 12 coefficients
    /// and b1 to b12 the 12 basis functions as displayed below. Timbre vectors are
    /// best used in comparison with each other. </para>
    /// </summary>
    public IReadOnlyList<double>? Timbre
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<double>>("timbre");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<double>?>(
                "timbre",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Confidence;
        _ = this.Duration;
        _ = this.LoudnessEnd;
        _ = this.LoudnessMax;
        _ = this.LoudnessMaxTime;
        _ = this.LoudnessStart;
        _ = this.Pitches;
        _ = this.Published;
        _ = this.Start;
        _ = this.Timbre;
    }

    public Segment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Segment(Segment segment)
        : base(segment) { }
#pragma warning restore CS8618

    public Segment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Segment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SegmentFromRaw.FromRawUnchecked"/>
    public static Segment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SegmentFromRaw : IFromRawJson<Segment>
{
    /// <inheritdoc/>
    public Segment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Segment.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Track, TrackFromRaw>))]
public sealed record class Track : JsonModel
{
    /// <summary>
    /// The number of channels used for analysis. If 1, all channels are summed together
    /// to mono before analysis.
    /// </summary>
    public long? AnalysisChannels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("analysis_channels");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("analysis_channels", value);
        }
    }

    /// <summary>
    /// The sample rate used to decode and analyze this track. May differ from the
    /// actual sample rate of this track available on Spotify.
    /// </summary>
    public long? AnalysisSampleRate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("analysis_sample_rate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("analysis_sample_rate", value);
        }
    }

    /// <summary>
    /// A version number for the Echo Nest Musical Fingerprint format used in the
    /// codestring field.
    /// </summary>
    public double? CodeVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("code_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("code_version", value);
        }
    }

    /// <summary>
    /// An [Echo Nest Musical Fingerprint (ENMFP)](https://academiccommons.columbia.edu/doi/10.7916/D8Q248M4)
    /// codestring for this track.
    /// </summary>
    public string? Codestring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("codestring");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("codestring", value);
        }
    }

    /// <summary>
    /// Length of the track in seconds.
    /// </summary>
    public double? Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("duration");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration", value);
        }
    }

    /// <summary>
    /// A version number for the EchoPrint format used in the echoprintstring field.
    /// </summary>
    public double? EchoprintVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("echoprint_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("echoprint_version", value);
        }
    }

    /// <summary>
    /// An [EchoPrint](https://github.com/spotify/echoprint-codegen) codestring for
    /// this track.
    /// </summary>
    public string? Echoprintstring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("echoprintstring");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("echoprintstring", value);
        }
    }

    /// <summary>
    /// The time, in seconds, at which the track's fade-in period ends. If the track
    /// has no fade-in, this will be 0.0.
    /// </summary>
    public double? EndOfFadeIn
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("end_of_fade_in");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("end_of_fade_in", value);
        }
    }

    /// <summary>
    /// The key the track is in. Integers map to pitches using standard [Pitch Class
    /// notation](https://en.wikipedia.org/wiki/Pitch_class). E.g. 0 = C, 1 = C♯/D♭,
    /// 2 = D, and so on. If no key was detected, the value is -1.
    /// </summary>
    public long? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("key");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key", value);
        }
    }

    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the `key`.
    /// </summary>
    public double? KeyConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("key_confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("key_confidence", value);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("loudness");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("loudness", value);
        }
    }

    /// <summary>
    /// Mode indicates the modality (major or minor) of a track, the type of scale
    /// from which its melodic content is derived. Major is represented by 1 and minor
    /// is 0.
    /// </summary>
    public long? Mode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("mode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode", value);
        }
    }

    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the `mode`.
    /// </summary>
    public double? ModeConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("mode_confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mode_confidence", value);
        }
    }

    /// <summary>
    /// The exact number of audio samples analyzed from this track. See also `analysis_sample_rate`.
    /// </summary>
    public long? NumSamples
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("num_samples");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("num_samples", value);
        }
    }

    /// <summary>
    /// An offset to the start of the region of the track that was analyzed. (As the
    /// entire track is analyzed, this should always be 0.)
    /// </summary>
    public long? OffsetSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("offset_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("offset_seconds", value);
        }
    }

    /// <summary>
    /// A version number for the Rhythmstring used in the rhythmstring field.
    /// </summary>
    public double? RhythmVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("rhythm_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rhythm_version", value);
        }
    }

    /// <summary>
    /// A Rhythmstring for this track. The format of this string is similar to the Synchstring.
    /// </summary>
    public string? Rhythmstring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rhythmstring");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("rhythmstring", value);
        }
    }

    /// <summary>
    /// This field will always contain the empty string.
    /// </summary>
    public string? SampleMd5
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("sample_md5");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sample_md5", value);
        }
    }

    /// <summary>
    /// The time, in seconds, at which the track's fade-out period starts. If the
    /// track has no fade-out, this should match the track's length.
    /// </summary>
    public double? StartOfFadeOut
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("start_of_fade_out");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("start_of_fade_out", value);
        }
    }

    /// <summary>
    /// A version number for the Synchstring used in the synchstring field.
    /// </summary>
    public double? SynchVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("synch_version");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("synch_version", value);
        }
    }

    /// <summary>
    /// A [Synchstring](https://github.com/echonest/synchdata) for this track.
    /// </summary>
    public string? Synchstring
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("synchstring");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("synchstring", value);
        }
    }

    /// <summary>
    /// The overall estimated tempo of a track in beats per minute (BPM). In musical
    /// terminology, tempo is the speed or pace of a given piece and derives directly
    /// from the average beat duration.
    /// </summary>
    public float? Tempo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>("tempo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tempo", value);
        }
    }

    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the `tempo`.
    /// </summary>
    public double? TempoConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("tempo_confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tempo_confidence", value);
        }
    }

    /// <summary>
    /// An estimated time signature. The time signature (meter) is a notational convention
    /// to specify how many beats are in each bar (or measure). The time signature
    /// ranges from 3 to 7 indicating time signatures of "3/4", to "7/4".
    /// </summary>
    public long? TimeSignature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("time_signature");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time_signature", value);
        }
    }

    /// <summary>
    /// The confidence, from 0.0 to 1.0, of the reliability of the `time_signature`.
    /// </summary>
    public double? TimeSignatureConfidence
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("time_signature_confidence");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("time_signature_confidence", value);
        }
    }

    /// <summary>
    /// The length of the region of the track was analyzed, if a subset of the track
    /// was analyzed. (As the entire track is analyzed, this should always be 0.)
    /// </summary>
    public long? WindowSeconds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("window_seconds");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("window_seconds", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AnalysisChannels;
        _ = this.AnalysisSampleRate;
        _ = this.CodeVersion;
        _ = this.Codestring;
        _ = this.Duration;
        _ = this.EchoprintVersion;
        _ = this.Echoprintstring;
        _ = this.EndOfFadeIn;
        _ = this.Key;
        _ = this.KeyConfidence;
        _ = this.Loudness;
        _ = this.Mode;
        _ = this.ModeConfidence;
        _ = this.NumSamples;
        _ = this.OffsetSeconds;
        _ = this.RhythmVersion;
        _ = this.Rhythmstring;
        _ = this.SampleMd5;
        _ = this.StartOfFadeOut;
        _ = this.SynchVersion;
        _ = this.Synchstring;
        _ = this.Tempo;
        _ = this.TempoConfidence;
        _ = this.TimeSignature;
        _ = this.TimeSignatureConfidence;
        _ = this.WindowSeconds;
    }

    public Track() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Track(Track track)
        : base(track) { }
#pragma warning restore CS8618

    public Track(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Track(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackFromRaw.FromRawUnchecked"/>
    public static Track FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackFromRaw : IFromRawJson<Track>
{
    /// <inheritdoc/>
    public Track FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Track.FromRawUnchecked(rawData);
}
