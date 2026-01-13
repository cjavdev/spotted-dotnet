using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<SimplifiedEpisodeObject, SimplifiedEpisodeObjectFromRaw>))]
public sealed record class SimplifiedEpisodeObject : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// episode.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// A URL to a 30 second preview (MP3 format) of the episode. `null` if not available.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required string? AudioPreviewUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("audio_preview_url");
        }
        init { this._rawData.Set("audio_preview_url", value); }
    }

    /// <summary>
    /// A description of the episode. HTML tags are stripped away from this field,
    /// use `html_description` field in case HTML tags are needed.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The episode length in milliseconds.
    /// </summary>
    public required long DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("duration_ms");
        }
        init { this._rawData.Set("duration_ms", value); }
    }

    /// <summary>
    /// Whether or not the episode has explicit content (true = yes it does; false
    /// = no it does not OR unknown).
    /// </summary>
    public required bool Explicit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("explicit");
        }
        init { this._rawData.Set("explicit", value); }
    }

    /// <summary>
    /// External URLs for this episode.
    /// </summary>
    public required ExternalUrlObject ExternalUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExternalUrlObject>("external_urls");
        }
        init { this._rawData.Set("external_urls", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the episode.
    /// </summary>
    public required string Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// A description of the episode. This field may contain HTML tags.
    /// </summary>
    public required string HtmlDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("html_description");
        }
        init { this._rawData.Set("html_description", value); }
    }

    /// <summary>
    /// The cover art for the episode in various sizes, widest first.
    /// </summary>
    public required IReadOnlyList<ImageObject> Images
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ImageObject>>("images");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImageObject>>(
                "images",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// True if the episode is hosted outside of Spotify's CDN.
    /// </summary>
    public required bool IsExternallyHosted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_externally_hosted");
        }
        init { this._rawData.Set("is_externally_hosted", value); }
    }

    /// <summary>
    /// True if the episode is playable in the given market. Otherwise false.
    /// </summary>
    public required bool IsPlayable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_playable");
        }
        init { this._rawData.Set("is_playable", value); }
    }

    /// <summary>
    /// A list of the languages used in the episode, identified by their [ISO 639-1](https://en.wikipedia.org/wiki/ISO_639)
    /// code.
    /// </summary>
    public required IReadOnlyList<string> Languages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("languages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "languages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The name of the episode.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The date the episode was first released, for example `"1981-12-15"`. Depending
    /// on the precision, it might be shown as `"1981"` or `"1981-12"`.
    /// </summary>
    public required string ReleaseDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("release_date");
        }
        init { this._rawData.Set("release_date", value); }
    }

    /// <summary>
    /// The precision with which `release_date` value is known.
    /// </summary>
    public required ApiEnum<
        string,
        SimplifiedEpisodeObjectReleaseDatePrecision
    > ReleaseDatePrecision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, SimplifiedEpisodeObjectReleaseDatePrecision>
            >("release_date_precision");
        }
        init { this._rawData.Set("release_date_precision", value); }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// episode.
    /// </summary>
    public required string Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("uri");
        }
        init { this._rawData.Set("uri", value); }
    }

    /// <summary>
    /// The language used in the episode, identified by a [ISO 639](https://en.wikipedia.org/wiki/ISO_639)
    /// code. This field is deprecated and might be removed in the future. Please
    /// use the `languages` field instead.
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? Language
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("language");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("language", value);
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
    /// Included in the response when a content restriction is applied.
    /// </summary>
    public EpisodeRestrictionObject? Restrictions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EpisodeRestrictionObject>("restrictions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("restrictions", value);
        }
    }

    /// <summary>
    /// The user's most recent position in the episode. Set if the supplied access
    /// token is a user token and has the scope 'user-read-playback-position'.
    /// </summary>
    public ResumePointObject? ResumePoint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ResumePointObject>("resume_point");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("resume_point", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AudioPreviewUrl;
        _ = this.Description;
        _ = this.DurationMs;
        _ = this.Explicit;
        this.ExternalUrls.Validate();
        _ = this.Href;
        _ = this.HtmlDescription;
        foreach (var item in this.Images)
        {
            item.Validate();
        }
        _ = this.IsExternallyHosted;
        _ = this.IsPlayable;
        _ = this.Languages;
        _ = this.Name;
        _ = this.ReleaseDate;
        this.ReleaseDatePrecision.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"episode\"")
            )
        )
        {
            throw new SpottedInvalidDataException("Invalid value given for constant");
        }
        _ = this.Uri;
        _ = this.Language;
        _ = this.Published;
        this.Restrictions?.Validate();
        this.ResumePoint?.Validate();
    }

    [System::Obsolete("Required properties are deprecated: audio_preview_url")]
    public SimplifiedEpisodeObject()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"episode\"");
    }

    [System::Obsolete("Required properties are deprecated: audio_preview_url")]
    public SimplifiedEpisodeObject(SimplifiedEpisodeObject simplifiedEpisodeObject)
        : base(simplifiedEpisodeObject) { }

    [System::Obsolete("Required properties are deprecated: audio_preview_url")]
    public SimplifiedEpisodeObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"episode\"");
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: audio_preview_url")]
    [SetsRequiredMembers]
    SimplifiedEpisodeObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SimplifiedEpisodeObjectFromRaw.FromRawUnchecked"/>
    public static SimplifiedEpisodeObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SimplifiedEpisodeObjectFromRaw : IFromRawJson<SimplifiedEpisodeObject>
{
    /// <inheritdoc/>
    public SimplifiedEpisodeObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SimplifiedEpisodeObject.FromRawUnchecked(rawData);
}

/// <summary>
/// The precision with which `release_date` value is known.
/// </summary>
[JsonConverter(typeof(SimplifiedEpisodeObjectReleaseDatePrecisionConverter))]
public enum SimplifiedEpisodeObjectReleaseDatePrecision
{
    Year,
    Month,
    Day,
}

sealed class SimplifiedEpisodeObjectReleaseDatePrecisionConverter
    : JsonConverter<SimplifiedEpisodeObjectReleaseDatePrecision>
{
    public override SimplifiedEpisodeObjectReleaseDatePrecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "year" => SimplifiedEpisodeObjectReleaseDatePrecision.Year,
            "month" => SimplifiedEpisodeObjectReleaseDatePrecision.Month,
            "day" => SimplifiedEpisodeObjectReleaseDatePrecision.Day,
            _ => (SimplifiedEpisodeObjectReleaseDatePrecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimplifiedEpisodeObjectReleaseDatePrecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SimplifiedEpisodeObjectReleaseDatePrecision.Year => "year",
                SimplifiedEpisodeObjectReleaseDatePrecision.Month => "month",
                SimplifiedEpisodeObjectReleaseDatePrecision.Day => "day",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
