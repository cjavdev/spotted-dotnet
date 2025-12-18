using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Chapters;

[JsonConverter(
    typeof(JsonModelConverter<ChapterBulkRetrieveResponse, ChapterBulkRetrieveResponseFromRaw>)
)]
public sealed record class ChapterBulkRetrieveResponse : JsonModel
{
    public required IReadOnlyList<Chapter> Chapters
    {
        get { return JsonModel.GetNotNullClass<List<Chapter>>(this.RawData, "chapters"); }
        init { JsonModel.Set(this._rawData, "chapters", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Chapters)
        {
            item.Validate();
        }
    }

    public ChapterBulkRetrieveResponse() { }

    public ChapterBulkRetrieveResponse(ChapterBulkRetrieveResponse chapterBulkRetrieveResponse)
        : base(chapterBulkRetrieveResponse) { }

    public ChapterBulkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChapterBulkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChapterBulkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ChapterBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ChapterBulkRetrieveResponse(List<Chapter> chapters)
        : this()
    {
        this.Chapters = chapters;
    }
}

class ChapterBulkRetrieveResponseFromRaw : IFromRawJson<ChapterBulkRetrieveResponse>
{
    /// <inheritdoc/>
    public ChapterBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChapterBulkRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Chapter, ChapterFromRaw>))]
public sealed record class Chapter : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// chapter.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// A URL to a 30 second preview (MP3 format) of the chapter. `null` if not available.
    /// </summary>
    [System::Obsolete("deprecated")]
    public required string? AudioPreviewURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "audio_preview_url"); }
        init { JsonModel.Set(this._rawData, "audio_preview_url", value); }
    }

    /// <summary>
    /// The audiobook for which the chapter belongs.
    /// </summary>
    public required AudiobookBase Audiobook
    {
        get { return JsonModel.GetNotNullClass<AudiobookBase>(this.RawData, "audiobook"); }
        init { JsonModel.Set(this._rawData, "audiobook", value); }
    }

    /// <summary>
    /// The number of the chapter
    /// </summary>
    public required long ChapterNumber
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "chapter_number"); }
        init { JsonModel.Set(this._rawData, "chapter_number", value); }
    }

    /// <summary>
    /// A description of the chapter. HTML tags are stripped away from this field,
    /// use `html_description` field in case HTML tags are needed.
    /// </summary>
    public required string Description
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// The chapter length in milliseconds.
    /// </summary>
    public required long DurationMs
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "duration_ms"); }
        init { JsonModel.Set(this._rawData, "duration_ms", value); }
    }

    /// <summary>
    /// Whether or not the chapter has explicit content (true = yes it does; false
    /// = no it does not OR unknown).
    /// </summary>
    public required bool Explicit
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "explicit"); }
        init { JsonModel.Set(this._rawData, "explicit", value); }
    }

    /// <summary>
    /// External URLs for this chapter.
    /// </summary>
    public required ExternalURLObject ExternalURLs
    {
        get { return JsonModel.GetNotNullClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init { JsonModel.Set(this._rawData, "external_urls", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the chapter.
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// A description of the chapter. This field may contain HTML tags.
    /// </summary>
    public required string HTMLDescription
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "html_description"); }
        init { JsonModel.Set(this._rawData, "html_description", value); }
    }

    /// <summary>
    /// The cover art for the chapter in various sizes, widest first.
    /// </summary>
    public required IReadOnlyList<ImageObject> Images
    {
        get { return JsonModel.GetNotNullClass<List<ImageObject>>(this.RawData, "images"); }
        init { JsonModel.Set(this._rawData, "images", value); }
    }

    /// <summary>
    /// True if the chapter is playable in the given market. Otherwise false.
    /// </summary>
    public required bool IsPlayable
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "is_playable"); }
        init { JsonModel.Set(this._rawData, "is_playable", value); }
    }

    /// <summary>
    /// A list of the languages used in the chapter, identified by their [ISO 639-1](https://en.wikipedia.org/wiki/ISO_639)
    /// code.
    /// </summary>
    public required IReadOnlyList<string> Languages
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "languages"); }
        init { JsonModel.Set(this._rawData, "languages", value); }
    }

    /// <summary>
    /// The name of the chapter.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The date the chapter was first released, for example `"1981-12-15"`. Depending
    /// on the precision, it might be shown as `"1981"` or `"1981-12"`.
    /// </summary>
    public required string ReleaseDate
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "release_date"); }
        init { JsonModel.Set(this._rawData, "release_date", value); }
    }

    /// <summary>
    /// The precision with which `release_date` value is known.
    /// </summary>
    public required ApiEnum<string, ChapterReleaseDatePrecision> ReleaseDatePrecision
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, ChapterReleaseDatePrecision>>(
                this.RawData,
                "release_date_precision"
            );
        }
        init { JsonModel.Set(this._rawData, "release_date_precision", value); }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// chapter.
    /// </summary>
    public required string Uri
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "uri"); }
        init { JsonModel.Set(this._rawData, "uri", value); }
    }

    /// <summary>
    /// A list of the countries in which the chapter can be played, identified by
    /// their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code.
    /// </summary>
    public IReadOnlyList<string>? AvailableMarkets
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "available_markets"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "available_markets", value);
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
    /// Included in the response when a content restriction is applied.
    /// </summary>
    public ChapterRestrictionObject? Restrictions
    {
        get
        {
            return JsonModel.GetNullableClass<ChapterRestrictionObject>(
                this.RawData,
                "restrictions"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "restrictions", value);
        }
    }

    /// <summary>
    /// The user's most recent position in the chapter. Set if the supplied access
    /// token is a user token and has the scope 'user-read-playback-position'.
    /// </summary>
    public ResumePointObject? ResumePoint
    {
        get { return JsonModel.GetNullableClass<ResumePointObject>(this.RawData, "resume_point"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "resume_point", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AudioPreviewURL;
        this.Audiobook.Validate();
        _ = this.ChapterNumber;
        _ = this.Description;
        _ = this.DurationMs;
        _ = this.Explicit;
        this.ExternalURLs.Validate();
        _ = this.Href;
        _ = this.HTMLDescription;
        foreach (var item in this.Images)
        {
            item.Validate();
        }
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
        _ = this.AvailableMarkets;
        _ = this.Published;
        this.Restrictions?.Validate();
        this.ResumePoint?.Validate();
    }

    [System::Obsolete("Required properties are deprecated: audio_preview_url")]
    public Chapter()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"episode\"");
    }

    [System::Obsolete("Required properties are deprecated: audio_preview_url")]
    public Chapter(Chapter chapter)
        : base(chapter) { }

    [System::Obsolete("Required properties are deprecated: audio_preview_url")]
    public Chapter(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"episode\"");
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: audio_preview_url")]
    [SetsRequiredMembers]
    Chapter(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChapterFromRaw.FromRawUnchecked"/>
    public static Chapter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChapterFromRaw : IFromRawJson<Chapter>
{
    /// <inheritdoc/>
    public Chapter FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Chapter.FromRawUnchecked(rawData);
}

/// <summary>
/// The precision with which `release_date` value is known.
/// </summary>
[JsonConverter(typeof(ChapterReleaseDatePrecisionConverter))]
public enum ChapterReleaseDatePrecision
{
    Year,
    Month,
    Day,
}

sealed class ChapterReleaseDatePrecisionConverter : JsonConverter<ChapterReleaseDatePrecision>
{
    public override ChapterReleaseDatePrecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "year" => ChapterReleaseDatePrecision.Year,
            "month" => ChapterReleaseDatePrecision.Month,
            "day" => ChapterReleaseDatePrecision.Day,
            _ => (ChapterReleaseDatePrecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChapterReleaseDatePrecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChapterReleaseDatePrecision.Year => "year",
                ChapterReleaseDatePrecision.Month => "month",
                ChapterReleaseDatePrecision.Day => "day",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
