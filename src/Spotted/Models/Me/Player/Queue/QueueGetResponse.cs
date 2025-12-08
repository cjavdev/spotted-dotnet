using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Me.Player.Queue;

[JsonConverter(typeof(ModelConverter<QueueGetResponse, QueueGetResponseFromRaw>))]
public sealed record class QueueGetResponse : ModelBase
{
    /// <summary>
    /// The currently playing track or episode. Can be `null`.
    /// </summary>
    public CurrentlyPlaying? CurrentlyPlaying
    {
        get
        {
            return ModelBase.GetNullableClass<CurrentlyPlaying>(this.RawData, "currently_playing");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "currently_playing", value);
        }
    }

    /// <summary>
    /// The tracks or episodes in the queue. Can be empty.
    /// </summary>
    public IReadOnlyList<QueueGetResponseQueue>? Queue
    {
        get
        {
            return ModelBase.GetNullableClass<List<QueueGetResponseQueue>>(this.RawData, "queue");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "queue", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CurrentlyPlaying?.Validate();
        foreach (var item in this.Queue ?? [])
        {
            item.Validate();
        }
    }

    public QueueGetResponse() { }

    public QueueGetResponse(QueueGetResponse queueGetResponse)
        : base(queueGetResponse) { }

    public QueueGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    QueueGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="QueueGetResponseFromRaw.FromRawUnchecked"/>
    public static QueueGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class QueueGetResponseFromRaw : IFromRaw<QueueGetResponse>
{
    /// <inheritdoc/>
    public QueueGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        QueueGetResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The currently playing track or episode. Can be `null`.
/// </summary>
[JsonConverter(typeof(CurrentlyPlayingConverter))]
public record class CurrentlyPlaying
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public string? Uri
    {
        get { return Match<string?>(trackObject: (x) => x.Uri, episodeObject: (x) => x.Uri); }
    }

    public CurrentlyPlaying(TrackObject value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public CurrentlyPlaying(EpisodeObject value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public CurrentlyPlaying(JsonElement json)
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
                    "Data did not match any variant of CurrentlyPlaying"
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
                "Data did not match any variant of CurrentlyPlaying"
            ),
        };
    }

    public static implicit operator CurrentlyPlaying(TrackObject value) => new(value);

    public static implicit operator CurrentlyPlaying(EpisodeObject value) => new(value);

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
                "Data did not match any variant of CurrentlyPlaying"
            );
        }
    }

    public virtual bool Equals(CurrentlyPlaying? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class CurrentlyPlayingConverter : JsonConverter<CurrentlyPlaying>
{
    public override CurrentlyPlaying? Read(
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
                return new CurrentlyPlaying(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        CurrentlyPlaying value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

[JsonConverter(typeof(QueueGetResponseQueueConverter))]
public record class QueueGetResponseQueue
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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

    public string? Uri
    {
        get { return Match<string?>(trackObject: (x) => x.Uri, episodeObject: (x) => x.Uri); }
    }

    public QueueGetResponseQueue(TrackObject value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public QueueGetResponseQueue(EpisodeObject value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public QueueGetResponseQueue(JsonElement json)
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
                    "Data did not match any variant of QueueGetResponseQueue"
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
                "Data did not match any variant of QueueGetResponseQueue"
            ),
        };
    }

    public static implicit operator QueueGetResponseQueue(TrackObject value) => new(value);

    public static implicit operator QueueGetResponseQueue(EpisodeObject value) => new(value);

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
                "Data did not match any variant of QueueGetResponseQueue"
            );
        }
    }

    public virtual bool Equals(QueueGetResponseQueue? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class QueueGetResponseQueueConverter : JsonConverter<QueueGetResponseQueue>
{
    public override QueueGetResponseQueue? Read(
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
                return new QueueGetResponseQueue(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        QueueGetResponseQueue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
