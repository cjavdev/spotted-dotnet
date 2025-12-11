using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<PlaylistTrackObject, PlaylistTrackObjectFromRaw>))]
public sealed record class PlaylistTrackObject : ModelBase
{
    /// <summary>
    /// The date and time the track or episode was added. _**Note**: some very old
    /// playlists may return `null` in this field._
    /// </summary>
    public System::DateTimeOffset? AddedAt
    {
        get
        {
            return ModelBase.GetNullableStruct<System::DateTimeOffset>(this.RawData, "added_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "added_at", value);
        }
    }

    /// <summary>
    /// The Spotify user who added the track or episode. _**Note**: some very old
    /// playlists may return `null` in this field._
    /// </summary>
    public PlaylistUserObject? AddedBy
    {
        get { return ModelBase.GetNullableClass<PlaylistUserObject>(this.RawData, "added_by"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "added_by", value);
        }
    }

    /// <summary>
    /// Whether this track or episode is a [local file](/documentation/web-api/concepts/playlists/#local-files)
    /// or not.
    /// </summary>
    public bool? IsLocal
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "is_local"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "is_local", value);
        }
    }

    /// <summary>
    /// Information about the track or episode.
    /// </summary>
    public Track? Track
    {
        get { return ModelBase.GetNullableClass<Track>(this.RawData, "track"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "track", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddedAt;
        this.AddedBy?.Validate();
        _ = this.IsLocal;
        this.Track?.Validate();
    }

    public PlaylistTrackObject() { }

    public PlaylistTrackObject(PlaylistTrackObject playlistTrackObject)
        : base(playlistTrackObject) { }

    public PlaylistTrackObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistTrackObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaylistTrackObjectFromRaw.FromRawUnchecked"/>
    public static PlaylistTrackObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaylistTrackObjectFromRaw : IFromRaw<PlaylistTrackObject>
{
    /// <inheritdoc/>
    public PlaylistTrackObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlaylistTrackObject.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the track or episode.
/// </summary>
[JsonConverter(typeof(TrackConverter))]
public record class Track
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? ID
    {
        get { return Match<string?>(object1: (x) => x.ID, episodeObject: (x) => x.ID); }
    }

    public long? DurationMs
    {
        get
        {
            return Match<long?>(object1: (x) => x.DurationMs, episodeObject: (x) => x.DurationMs);
        }
    }

    public bool? Explicit
    {
        get { return Match<bool?>(object1: (x) => x.Explicit, episodeObject: (x) => x.Explicit); }
    }

    public ExternalURLObject? ExternalURLs
    {
        get
        {
            return Match<ExternalURLObject?>(
                object1: (x) => x.ExternalURLs,
                episodeObject: (x) => x.ExternalURLs
            );
        }
    }

    public string? Href
    {
        get { return Match<string?>(object1: (x) => x.Href, episodeObject: (x) => x.Href); }
    }

    public bool? IsPlayable
    {
        get
        {
            return Match<bool?>(object1: (x) => x.IsPlayable, episodeObject: (x) => x.IsPlayable);
        }
    }

    public string? Name
    {
        get { return Match<string?>(object1: (x) => x.Name, episodeObject: (x) => x.Name); }
    }

    public string? Uri
    {
        get { return Match<string?>(object1: (x) => x.Uri, episodeObject: (x) => x.Uri); }
    }

    public Track(TrackObject value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Track(EpisodeObject value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public Track(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TrackObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickObject(out var value)) {
    ///     // `value` is of type `TrackObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickObject([NotNullWhen(true)] out TrackObject? value)
    {
        value = this.Value as TrackObject;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="EpisodeObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickEpisodeObject(out var value)) {
    ///     // `value` is of type `EpisodeObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickEpisodeObject([NotNullWhen(true)] out EpisodeObject? value)
    {
        value = this.Value as EpisodeObject;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="SpottedInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (TrackObject value) => {...},
    ///     (EpisodeObject value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TrackObject> object1,
        System::Action<EpisodeObject> episodeObject
    )
    {
        switch (this.Value)
        {
            case TrackObject value:
                object1(value);
                break;
            case EpisodeObject value:
                episodeObject(value);
                break;
            default:
                throw new SpottedInvalidDataException("Data did not match any variant of Track");
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="SpottedInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (TrackObject value) => {...},
    ///     (EpisodeObject value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<TrackObject, T> object1,
        System::Func<EpisodeObject, T> episodeObject
    )
    {
        return this.Value switch
        {
            TrackObject value => object1(value),
            EpisodeObject value => episodeObject(value),
            _ => throw new SpottedInvalidDataException("Data did not match any variant of Track"),
        };
    }

    public static implicit operator Track(TrackObject value) => new(value);

    public static implicit operator Track(EpisodeObject value) => new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SpottedInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new SpottedInvalidDataException("Data did not match any variant of Track");
        }
        this.Switch((object1) => object1.Validate(), (episodeObject) => episodeObject.Validate());
    }

    public virtual bool Equals(Track? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class TrackConverter : JsonConverter<Track>
{
    public override Track? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "track":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TrackObject>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is SpottedInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "episode":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EpisodeObject>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is SpottedInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new Track(json);
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Track value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
