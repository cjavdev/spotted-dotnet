using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<ShowBase, ShowBaseFromRaw>))]
public sealed record class ShowBase : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// show.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// A list of the countries in which the show can be played, identified by their
    /// [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code.
    /// </summary>
    public required IReadOnlyList<string> AvailableMarkets
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "available_markets"); }
        init { JsonModel.Set(this._rawData, "available_markets", value); }
    }

    /// <summary>
    /// The copyright statements of the show.
    /// </summary>
    public required IReadOnlyList<CopyrightObject> Copyrights
    {
        get { return JsonModel.GetNotNullClass<List<CopyrightObject>>(this.RawData, "copyrights"); }
        init { JsonModel.Set(this._rawData, "copyrights", value); }
    }

    /// <summary>
    /// A description of the show. HTML tags are stripped away from this field, use
    /// `html_description` field in case HTML tags are needed.
    /// </summary>
    public required string Description
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Whether or not the show has explicit content (true = yes it does; false =
    /// no it does not OR unknown).
    /// </summary>
    public required bool Explicit
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "explicit"); }
        init { JsonModel.Set(this._rawData, "explicit", value); }
    }

    /// <summary>
    /// External URLs for this show.
    /// </summary>
    public required ExternalURLObject ExternalURLs
    {
        get { return JsonModel.GetNotNullClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init { JsonModel.Set(this._rawData, "external_urls", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the show.
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// A description of the show. This field may contain HTML tags.
    /// </summary>
    public required string HTMLDescription
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "html_description"); }
        init { JsonModel.Set(this._rawData, "html_description", value); }
    }

    /// <summary>
    /// The cover art for the show in various sizes, widest first.
    /// </summary>
    public required IReadOnlyList<ImageObject> Images
    {
        get { return JsonModel.GetNotNullClass<List<ImageObject>>(this.RawData, "images"); }
        init { JsonModel.Set(this._rawData, "images", value); }
    }

    /// <summary>
    /// True if all of the shows episodes are hosted outside of Spotify's CDN. This
    /// field might be `null` in some cases.
    /// </summary>
    public required bool IsExternallyHosted
    {
        get { return JsonModel.GetNotNullStruct<bool>(this.RawData, "is_externally_hosted"); }
        init { JsonModel.Set(this._rawData, "is_externally_hosted", value); }
    }

    /// <summary>
    /// A list of the languages used in the show, identified by their [ISO 639](https://en.wikipedia.org/wiki/ISO_639)
    /// code.
    /// </summary>
    public required IReadOnlyList<string> Languages
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "languages"); }
        init { JsonModel.Set(this._rawData, "languages", value); }
    }

    /// <summary>
    /// The media type of the show.
    /// </summary>
    public required string MediaType
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "media_type"); }
        init { JsonModel.Set(this._rawData, "media_type", value); }
    }

    /// <summary>
    /// The name of the episode.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The publisher of the show.
    /// </summary>
    public required string Publisher
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "publisher"); }
        init { JsonModel.Set(this._rawData, "publisher", value); }
    }

    /// <summary>
    /// The total number of episodes in the show.
    /// </summary>
    public required long TotalEpisodes
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total_episodes"); }
        init { JsonModel.Set(this._rawData, "total_episodes", value); }
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
    /// show.
    /// </summary>
    public required string Uri
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "uri"); }
        init { JsonModel.Set(this._rawData, "uri", value); }
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
        _ = this.IsExternallyHosted;
        _ = this.Languages;
        _ = this.MediaType;
        _ = this.Name;
        _ = this.Publisher;
        _ = this.TotalEpisodes;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"show\"")))
        {
            throw new SpottedInvalidDataException("Invalid value given for constant");
        }
        _ = this.Uri;
        _ = this.Published;
    }

    public ShowBase()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"show\"");
    }

    public ShowBase(ShowBase showBase)
        : base(showBase) { }

    public ShowBase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"show\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShowBase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShowBaseFromRaw.FromRawUnchecked"/>
    public static ShowBase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShowBaseFromRaw : IFromRawJson<ShowBase>
{
    /// <inheritdoc/>
    public ShowBase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ShowBase.FromRawUnchecked(rawData);
}
