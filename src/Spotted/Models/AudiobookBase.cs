using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<AudiobookBase, AudiobookBaseFromRaw>))]
public sealed record class AudiobookBase : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// audiobook.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The author(s) for the audiobook.
    /// </summary>
    public required IReadOnlyList<AuthorObject> Authors
    {
        get { return JsonModel.GetNotNullClass<List<AuthorObject>>(this.RawData, "authors"); }
        init { JsonModel.Set(this._rawData, "authors", value); }
    }

    /// <summary>
    /// A list of the countries in which the audiobook can be played, identified by
    /// their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code.
    /// </summary>
    public required IReadOnlyList<string> AvailableMarkets
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "available_markets"); }
        init { JsonModel.Set(this._rawData, "available_markets", value); }
    }

    /// <summary>
    /// The copyright statements of the audiobook.
    /// </summary>
    public required IReadOnlyList<CopyrightObject> Copyrights
    {
        get { return JsonModel.GetNotNullClass<List<CopyrightObject>>(this.RawData, "copyrights"); }
        init { JsonModel.Set(this._rawData, "copyrights", value); }
    }

    /// <summary>
    /// A description of the audiobook. HTML tags are stripped away from this field,
    /// use `html_description` field in case HTML tags are needed.
    /// </summary>
    public required string Description
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Whether or not the audiobook has explicit content (true = yes it does; false
    /// = no it does not OR unknown).
    /// </summary>
    public required bool Explicit
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "explicit"); }
        init { JsonModel.Set(this._rawData, "explicit", value); }
    }

    /// <summary>
    /// External URLs for this audiobook.
    /// </summary>
    public required ExternalURLObject ExternalURLs
    {
        get { return JsonModel.GetNotNullClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init { JsonModel.Set(this._rawData, "external_urls", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the audiobook.
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// A description of the audiobook. This field may contain HTML tags.
    /// </summary>
    public required string HTMLDescription
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "html_description"); }
        init { JsonModel.Set(this._rawData, "html_description", value); }
    }

    /// <summary>
    /// The cover art for the audiobook in various sizes, widest first.
    /// </summary>
    public required IReadOnlyList<ImageObject> Images
    {
        get { return JsonModel.GetNotNullClass<List<ImageObject>>(this.RawData, "images"); }
        init { JsonModel.Set(this._rawData, "images", value); }
    }

    /// <summary>
    /// A list of the languages used in the audiobook, identified by their [ISO 639](https://en.wikipedia.org/wiki/ISO_639)
    /// code.
    /// </summary>
    public required IReadOnlyList<string> Languages
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "languages"); }
        init { JsonModel.Set(this._rawData, "languages", value); }
    }

    /// <summary>
    /// The media type of the audiobook.
    /// </summary>
    public required string MediaType
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "media_type"); }
        init { JsonModel.Set(this._rawData, "media_type", value); }
    }

    /// <summary>
    /// The name of the audiobook.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The narrator(s) for the audiobook.
    /// </summary>
    public required IReadOnlyList<NarratorObject> Narrators
    {
        get { return JsonModel.GetNotNullClass<List<NarratorObject>>(this.RawData, "narrators"); }
        init { JsonModel.Set(this._rawData, "narrators", value); }
    }

    /// <summary>
    /// The publisher of the audiobook.
    /// </summary>
    public required string Publisher
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "publisher"); }
        init { JsonModel.Set(this._rawData, "publisher", value); }
    }

    /// <summary>
    /// The number of chapters in this audiobook.
    /// </summary>
    public required long TotalChapters
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total_chapters"); }
        init { JsonModel.Set(this._rawData, "total_chapters", value); }
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
    /// audiobook.
    /// </summary>
    public required string Uri
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "uri"); }
        init { JsonModel.Set(this._rawData, "uri", value); }
    }

    /// <summary>
    /// The edition of the audiobook.
    /// </summary>
    public string? Edition
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "edition"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "edition", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Authors)
        {
            item.Validate();
        }
        _ = this.AvailableMarkets;
        foreach (var item in this.Copyrights)
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.Explicit;
        this.ExternalURLs.Validate();
        _ = this.Href;
        _ = this.HTMLDescription;
        foreach (var item in this.Images)
        {
            item.Validate();
        }
        _ = this.Languages;
        _ = this.MediaType;
        _ = this.Name;
        foreach (var item in this.Narrators)
        {
            item.Validate();
        }
        _ = this.Publisher;
        _ = this.TotalChapters;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"audiobook\"")
            )
        )
        {
            throw new SpottedInvalidDataException("Invalid value given for constant");
        }
        _ = this.Uri;
        _ = this.Edition;
        _ = this.Published;
    }

    public AudiobookBase()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"audiobook\"");
    }

    public AudiobookBase(AudiobookBase audiobookBase)
        : base(audiobookBase) { }

    public AudiobookBase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"audiobook\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudiobookBase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudiobookBaseFromRaw.FromRawUnchecked"/>
    public static AudiobookBase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudiobookBaseFromRaw : IFromRawJson<AudiobookBase>
{
    /// <inheritdoc/>
    public AudiobookBase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AudiobookBase.FromRawUnchecked(rawData);
}
