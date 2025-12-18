using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Me.Player;

[JsonConverter(typeof(JsonModelConverter<PlayerGetStateResponse, PlayerGetStateResponseFromRaw>))]
public sealed record class PlayerGetStateResponse : JsonModel
{
    /// <summary>
    /// Allows to update the user interface based on which playback actions are available
    /// within the current context.
    /// </summary>
    public PlayerGetStateResponseActions? Actions
    {
        get
        {
            return JsonModel.GetNullableClass<PlayerGetStateResponseActions>(
                this.RawData,
                "actions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "actions", value);
        }
    }

    /// <summary>
    /// A Context Object. Can be `null`.
    /// </summary>
    public ContextObject? Context
    {
        get { return JsonModel.GetNullableClass<ContextObject>(this.RawData, "context"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "context", value);
        }
    }

    /// <summary>
    /// The object type of the currently playing item. Can be one of `track`, `episode`,
    /// `ad` or `unknown`.
    /// </summary>
    public string? CurrentlyPlayingType
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "currently_playing_type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "currently_playing_type", value);
        }
    }

    /// <summary>
    /// The device that is currently active.
    /// </summary>
    public DeviceObject? Device
    {
        get { return JsonModel.GetNullableClass<DeviceObject>(this.RawData, "device"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "device", value);
        }
    }

    /// <summary>
    /// If something is currently playing, return `true`.
    /// </summary>
    public bool? IsPlaying
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "is_playing"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "is_playing", value);
        }
    }

    /// <summary>
    /// The currently playing track or episode. Can be `null`.
    /// </summary>
    public PlayerGetStateResponseItem? Item
    {
        get { return JsonModel.GetNullableClass<PlayerGetStateResponseItem>(this.RawData, "item"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "item", value);
        }
    }

    /// <summary>
    /// Progress into the currently playing track or episode. Can be `null`.
    /// </summary>
    public long? ProgressMs
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "progress_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "progress_ms", value);
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
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// off, track, context
    /// </summary>
    public string? RepeatState
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "repeat_state"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "repeat_state", value);
        }
    }

    /// <summary>
    /// If shuffle is on or off.
    /// </summary>
    public bool? ShuffleState
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "shuffle_state"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "shuffle_state", value);
        }
    }

    /// <summary>
    /// Unix Millisecond Timestamp when playback state was last changed (play, pause,
    /// skip, scrub, new song, etc.).
    /// </summary>
    public long? Timestamp
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "timestamp"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Actions?.Validate();
        this.Context?.Validate();
        _ = this.CurrentlyPlayingType;
        this.Device?.Validate();
        _ = this.IsPlaying;
        this.Item?.Validate();
        _ = this.ProgressMs;
        _ = this.Published;
        _ = this.RepeatState;
        _ = this.ShuffleState;
        _ = this.Timestamp;
    }

    public PlayerGetStateResponse() { }

    public PlayerGetStateResponse(PlayerGetStateResponse playerGetStateResponse)
        : base(playerGetStateResponse) { }

    public PlayerGetStateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerGetStateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlayerGetStateResponseFromRaw.FromRawUnchecked"/>
    public static PlayerGetStateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlayerGetStateResponseFromRaw : IFromRawJson<PlayerGetStateResponse>
{
    /// <inheritdoc/>
    public PlayerGetStateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlayerGetStateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Allows to update the user interface based on which playback actions are available
/// within the current context.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PlayerGetStateResponseActions, PlayerGetStateResponseActionsFromRaw>)
)]
public sealed record class PlayerGetStateResponseActions : JsonModel
{
    /// <summary>
    /// Interrupting playback. Optional field.
    /// </summary>
    public bool? InterruptingPlayback
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "interrupting_playback"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "interrupting_playback", value);
        }
    }

    /// <summary>
    /// Pausing. Optional field.
    /// </summary>
    public bool? Pausing
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "pausing"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "pausing", value);
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
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// Resuming. Optional field.
    /// </summary>
    public bool? Resuming
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "resuming"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "resuming", value);
        }
    }

    /// <summary>
    /// Seeking playback location. Optional field.
    /// </summary>
    public bool? Seeking
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "seeking"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "seeking", value);
        }
    }

    /// <summary>
    /// Skipping to the next context. Optional field.
    /// </summary>
    public bool? SkippingNext
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "skipping_next"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "skipping_next", value);
        }
    }

    /// <summary>
    /// Skipping to the previous context. Optional field.
    /// </summary>
    public bool? SkippingPrev
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "skipping_prev"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "skipping_prev", value);
        }
    }

    /// <summary>
    /// Toggling repeat context flag. Optional field.
    /// </summary>
    public bool? TogglingRepeatContext
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "toggling_repeat_context"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "toggling_repeat_context", value);
        }
    }

    /// <summary>
    /// Toggling repeat track flag. Optional field.
    /// </summary>
    public bool? TogglingRepeatTrack
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "toggling_repeat_track"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "toggling_repeat_track", value);
        }
    }

    /// <summary>
    /// Toggling shuffle flag. Optional field.
    /// </summary>
    public bool? TogglingShuffle
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "toggling_shuffle"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "toggling_shuffle", value);
        }
    }

    /// <summary>
    /// Transfering playback between devices. Optional field.
    /// </summary>
    public bool? TransferringPlayback
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "transferring_playback"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "transferring_playback", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InterruptingPlayback;
        _ = this.Pausing;
        _ = this.Published;
        _ = this.Resuming;
        _ = this.Seeking;
        _ = this.SkippingNext;
        _ = this.SkippingPrev;
        _ = this.TogglingRepeatContext;
        _ = this.TogglingRepeatTrack;
        _ = this.TogglingShuffle;
        _ = this.TransferringPlayback;
    }

    public PlayerGetStateResponseActions() { }

    public PlayerGetStateResponseActions(
        PlayerGetStateResponseActions playerGetStateResponseActions
    )
        : base(playerGetStateResponseActions) { }

    public PlayerGetStateResponseActions(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerGetStateResponseActions(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlayerGetStateResponseActionsFromRaw.FromRawUnchecked"/>
    public static PlayerGetStateResponseActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlayerGetStateResponseActionsFromRaw : IFromRawJson<PlayerGetStateResponseActions>
{
    /// <inheritdoc/>
    public PlayerGetStateResponseActions FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlayerGetStateResponseActions.FromRawUnchecked(rawData);
}

/// <summary>
/// The currently playing track or episode. Can be `null`.
/// </summary>
[JsonConverter(typeof(PlayerGetStateResponseItemConverter))]
public record class PlayerGetStateResponseItem
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get { return this._element ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public string? ID
    {
        get { return Match<string?>(trackObject: (x) => x.ID, episodeObject: (x) => x.ID); }
    }

    public long? DurationMs
    {
        get
        {
            return Match<long?>(
                trackObject: (x) => x.DurationMs,
                episodeObject: (x) => x.DurationMs
            );
        }
    }

    public bool? Explicit
    {
        get
        {
            return Match<bool?>(trackObject: (x) => x.Explicit, episodeObject: (x) => x.Explicit);
        }
    }

    public ExternalURLObject? ExternalURLs
    {
        get
        {
            return Match<ExternalURLObject?>(
                trackObject: (x) => x.ExternalURLs,
                episodeObject: (x) => x.ExternalURLs
            );
        }
    }

    public string? Href
    {
        get { return Match<string?>(trackObject: (x) => x.Href, episodeObject: (x) => x.Href); }
    }

    public bool? IsPlayable
    {
        get
        {
            return Match<bool?>(
                trackObject: (x) => x.IsPlayable,
                episodeObject: (x) => x.IsPlayable
            );
        }
    }

    public string? Name
    {
        get { return Match<string?>(trackObject: (x) => x.Name, episodeObject: (x) => x.Name); }
    }

    public bool? Published
    {
        get
        {
            return Match<bool?>(trackObject: (x) => x.Published, episodeObject: (x) => x.Published);
        }
    }

    public string? Uri
    {
        get { return Match<string?>(trackObject: (x) => x.Uri, episodeObject: (x) => x.Uri); }
    }

    public PlayerGetStateResponseItem(TrackObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PlayerGetStateResponseItem(EpisodeObject value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public PlayerGetStateResponseItem(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TrackObject"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTrackObject(out var value)) {
    ///     // `value` is of type `TrackObject`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTrackObject([NotNullWhen(true)] out TrackObject? value)
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
        System::Action<TrackObject> trackObject,
        System::Action<EpisodeObject> episodeObject
    )
    {
        switch (this.Value)
        {
            case TrackObject value:
                trackObject(value);
                break;
            case EpisodeObject value:
                episodeObject(value);
                break;
            default:
                throw new SpottedInvalidDataException(
                    "Data did not match any variant of PlayerGetStateResponseItem"
                );
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
        System::Func<TrackObject, T> trackObject,
        System::Func<EpisodeObject, T> episodeObject
    )
    {
        return this.Value switch
        {
            TrackObject value => trackObject(value),
            EpisodeObject value => episodeObject(value),
            _ => throw new SpottedInvalidDataException(
                "Data did not match any variant of PlayerGetStateResponseItem"
            ),
        };
    }

    public static implicit operator PlayerGetStateResponseItem(TrackObject value) => new(value);

    public static implicit operator PlayerGetStateResponseItem(EpisodeObject value) => new(value);

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
            throw new SpottedInvalidDataException(
                "Data did not match any variant of PlayerGetStateResponseItem"
            );
        }
        this.Switch(
            (trackObject) => trackObject.Validate(),
            (episodeObject) => episodeObject.Validate()
        );
    }

    public virtual bool Equals(PlayerGetStateResponseItem? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class PlayerGetStateResponseItemConverter : JsonConverter<PlayerGetStateResponseItem>
{
    public override PlayerGetStateResponseItem? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<TrackObject>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is SpottedInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "episode":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<EpisodeObject>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is SpottedInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new PlayerGetStateResponseItem(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlayerGetStateResponseItem value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
