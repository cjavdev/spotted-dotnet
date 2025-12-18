using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Search;

[JsonConverter(typeof(JsonModelConverter<SearchQueryResponse, SearchQueryResponseFromRaw>))]
public sealed record class SearchQueryResponse : JsonModel
{
    public SearchQueryResponseAlbums? Albums
    {
        get
        {
            return JsonModel.GetNullableClass<SearchQueryResponseAlbums>(this.RawData, "albums");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "albums", value);
        }
    }

    public SearchQueryResponseArtists? Artists
    {
        get
        {
            return JsonModel.GetNullableClass<SearchQueryResponseArtists>(this.RawData, "artists");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "artists", value);
        }
    }

    public SearchQueryResponseAudiobooks? Audiobooks
    {
        get
        {
            return JsonModel.GetNullableClass<SearchQueryResponseAudiobooks>(
                this.RawData,
                "audiobooks"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "audiobooks", value);
        }
    }

    public SearchQueryResponseEpisodes? Episodes
    {
        get
        {
            return JsonModel.GetNullableClass<SearchQueryResponseEpisodes>(
                this.RawData,
                "episodes"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "episodes", value);
        }
    }

    public PagingPlaylistObject? Playlists
    {
        get { return JsonModel.GetNullableClass<PagingPlaylistObject>(this.RawData, "playlists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "playlists", value);
        }
    }

    public SearchQueryResponseShows? Shows
    {
        get { return JsonModel.GetNullableClass<SearchQueryResponseShows>(this.RawData, "shows"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "shows", value);
        }
    }

    public SearchQueryResponseTracks? Tracks
    {
        get
        {
            return JsonModel.GetNullableClass<SearchQueryResponseTracks>(this.RawData, "tracks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "tracks", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Albums?.Validate();
        this.Artists?.Validate();
        this.Audiobooks?.Validate();
        this.Episodes?.Validate();
        this.Playlists?.Validate();
        this.Shows?.Validate();
        this.Tracks?.Validate();
    }

    public SearchQueryResponse() { }

    public SearchQueryResponse(SearchQueryResponse searchQueryResponse)
        : base(searchQueryResponse) { }

    public SearchQueryResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchQueryResponseFromRaw.FromRawUnchecked"/>
    public static SearchQueryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchQueryResponseFromRaw : IFromRawJson<SearchQueryResponse>
{
    /// <inheritdoc/>
    public SearchQueryResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SearchQueryResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchQueryResponseAlbums, SearchQueryResponseAlbumsFromRaw>)
)]
public sealed record class SearchQueryResponseAlbums : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init { JsonModel.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { JsonModel.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "previous"); }
        init { JsonModel.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<Item>? Items
    {
        get { return JsonModel.GetNullableClass<List<Item>>(this.RawData, "items"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "items", value);
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
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public SearchQueryResponseAlbums() { }

    public SearchQueryResponseAlbums(SearchQueryResponseAlbums searchQueryResponseAlbums)
        : base(searchQueryResponseAlbums) { }

    public SearchQueryResponseAlbums(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryResponseAlbums(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchQueryResponseAlbumsFromRaw.FromRawUnchecked"/>
    public static SearchQueryResponseAlbums FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchQueryResponseAlbumsFromRaw : IFromRawJson<SearchQueryResponseAlbums>
{
    /// <inheritdoc/>
    public SearchQueryResponseAlbums FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchQueryResponseAlbums.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// album.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The type of the album.
    /// </summary>
    public required ApiEnum<string, global::Spotted.Models.Search.AlbumType> AlbumType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Spotted.Models.Search.AlbumType>
            >(this.RawData, "album_type");
        }
        init { JsonModel.Set(this._rawData, "album_type", value); }
    }

    /// <summary>
    /// The artists of the album. Each artist object includes a link in `href` to
    /// more detailed information about the artist.
    /// </summary>
    public required IReadOnlyList<SimplifiedArtistObject> Artists
    {
        get
        {
            return JsonModel.GetNotNullClass<List<SimplifiedArtistObject>>(this.RawData, "artists");
        }
        init { JsonModel.Set(this._rawData, "artists", value); }
    }

    /// <summary>
    /// The markets in which the album is available: [ISO 3166-1 alpha-2 country
    /// codes](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). _**NOTE**: an album
    /// is considered available in a market when at least 1 of its tracks is available
    /// in that market._
    /// </summary>
    public required IReadOnlyList<string> AvailableMarkets
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawData, "available_markets"); }
        init { JsonModel.Set(this._rawData, "available_markets", value); }
    }

    /// <summary>
    /// Known external URLs for this album.
    /// </summary>
    public required ExternalURLObject ExternalURLs
    {
        get { return JsonModel.GetNotNullClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init { JsonModel.Set(this._rawData, "external_urls", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the album.
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The cover art for the album in various sizes, widest first.
    /// </summary>
    public required IReadOnlyList<ImageObject> Images
    {
        get { return JsonModel.GetNotNullClass<List<ImageObject>>(this.RawData, "images"); }
        init { JsonModel.Set(this._rawData, "images", value); }
    }

    /// <summary>
    /// The name of the album. In case of an album takedown, the value may be an
    /// empty string.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The date the album was first released.
    /// </summary>
    public required string ReleaseDate
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "release_date"); }
        init { JsonModel.Set(this._rawData, "release_date", value); }
    }

    /// <summary>
    /// The precision with which `release_date` value is known.
    /// </summary>
    public required ApiEnum<
        string,
        global::Spotted.Models.Search.ReleaseDatePrecision
    > ReleaseDatePrecision
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Spotted.Models.Search.ReleaseDatePrecision>
            >(this.RawData, "release_date_precision");
        }
        init { JsonModel.Set(this._rawData, "release_date_precision", value); }
    }

    /// <summary>
    /// The number of tracks in the album.
    /// </summary>
    public required long TotalTracks
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total_tracks"); }
        init { JsonModel.Set(this._rawData, "total_tracks", value); }
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
    /// album.
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

    /// <summary>
    /// Included in the response when a content restriction is applied.
    /// </summary>
    public AlbumRestrictionObject? Restrictions
    {
        get
        {
            return JsonModel.GetNullableClass<AlbumRestrictionObject>(this.RawData, "restrictions");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AlbumType.Validate();
        foreach (var item in this.Artists)
        {
            item.Validate();
        }
        _ = this.AvailableMarkets;
        this.ExternalURLs.Validate();
        _ = this.Href;
        foreach (var item in this.Images)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.ReleaseDate;
        this.ReleaseDatePrecision.Validate();
        _ = this.TotalTracks;
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"album\""))
        )
        {
            throw new SpottedInvalidDataException("Invalid value given for constant");
        }
        _ = this.Uri;
        _ = this.Published;
        this.Restrictions?.Validate();
    }

    public Item()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"album\"");
    }

    public Item(Item item)
        : base(item) { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"album\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the album.
/// </summary>
[JsonConverter(typeof(global::Spotted.Models.Search.AlbumTypeConverter))]
public enum AlbumType
{
    Album,
    Single,
    Compilation,
}

sealed class AlbumTypeConverter : JsonConverter<global::Spotted.Models.Search.AlbumType>
{
    public override global::Spotted.Models.Search.AlbumType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "album" => global::Spotted.Models.Search.AlbumType.Album,
            "single" => global::Spotted.Models.Search.AlbumType.Single,
            "compilation" => global::Spotted.Models.Search.AlbumType.Compilation,
            _ => (global::Spotted.Models.Search.AlbumType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Search.AlbumType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Search.AlbumType.Album => "album",
                global::Spotted.Models.Search.AlbumType.Single => "single",
                global::Spotted.Models.Search.AlbumType.Compilation => "compilation",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The precision with which `release_date` value is known.
/// </summary>
[JsonConverter(typeof(global::Spotted.Models.Search.ReleaseDatePrecisionConverter))]
public enum ReleaseDatePrecision
{
    Year,
    Month,
    Day,
}

sealed class ReleaseDatePrecisionConverter
    : JsonConverter<global::Spotted.Models.Search.ReleaseDatePrecision>
{
    public override global::Spotted.Models.Search.ReleaseDatePrecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "year" => global::Spotted.Models.Search.ReleaseDatePrecision.Year,
            "month" => global::Spotted.Models.Search.ReleaseDatePrecision.Month,
            "day" => global::Spotted.Models.Search.ReleaseDatePrecision.Day,
            _ => (global::Spotted.Models.Search.ReleaseDatePrecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Search.ReleaseDatePrecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Search.ReleaseDatePrecision.Year => "year",
                global::Spotted.Models.Search.ReleaseDatePrecision.Month => "month",
                global::Spotted.Models.Search.ReleaseDatePrecision.Day => "day",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(
    typeof(JsonModelConverter<SearchQueryResponseArtists, SearchQueryResponseArtistsFromRaw>)
)]
public sealed record class SearchQueryResponseArtists : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init { JsonModel.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { JsonModel.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "previous"); }
        init { JsonModel.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<ArtistObject>? Items
    {
        get { return JsonModel.GetNullableClass<List<ArtistObject>>(this.RawData, "items"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "items", value);
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
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public SearchQueryResponseArtists() { }

    public SearchQueryResponseArtists(SearchQueryResponseArtists searchQueryResponseArtists)
        : base(searchQueryResponseArtists) { }

    public SearchQueryResponseArtists(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryResponseArtists(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchQueryResponseArtistsFromRaw.FromRawUnchecked"/>
    public static SearchQueryResponseArtists FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchQueryResponseArtistsFromRaw : IFromRawJson<SearchQueryResponseArtists>
{
    /// <inheritdoc/>
    public SearchQueryResponseArtists FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchQueryResponseArtists.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchQueryResponseAudiobooks, SearchQueryResponseAudiobooksFromRaw>)
)]
public sealed record class SearchQueryResponseAudiobooks : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init { JsonModel.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { JsonModel.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "previous"); }
        init { JsonModel.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<AudiobookBase>? Items
    {
        get { return JsonModel.GetNullableClass<List<AudiobookBase>>(this.RawData, "items"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "items", value);
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
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public SearchQueryResponseAudiobooks() { }

    public SearchQueryResponseAudiobooks(
        SearchQueryResponseAudiobooks searchQueryResponseAudiobooks
    )
        : base(searchQueryResponseAudiobooks) { }

    public SearchQueryResponseAudiobooks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryResponseAudiobooks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchQueryResponseAudiobooksFromRaw.FromRawUnchecked"/>
    public static SearchQueryResponseAudiobooks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchQueryResponseAudiobooksFromRaw : IFromRawJson<SearchQueryResponseAudiobooks>
{
    /// <inheritdoc/>
    public SearchQueryResponseAudiobooks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchQueryResponseAudiobooks.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchQueryResponseEpisodes, SearchQueryResponseEpisodesFromRaw>)
)]
public sealed record class SearchQueryResponseEpisodes : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init { JsonModel.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { JsonModel.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "previous"); }
        init { JsonModel.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<SimplifiedEpisodeObject>? Items
    {
        get
        {
            return JsonModel.GetNullableClass<List<SimplifiedEpisodeObject>>(this.RawData, "items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "items", value);
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
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public SearchQueryResponseEpisodes() { }

    public SearchQueryResponseEpisodes(SearchQueryResponseEpisodes searchQueryResponseEpisodes)
        : base(searchQueryResponseEpisodes) { }

    public SearchQueryResponseEpisodes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryResponseEpisodes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchQueryResponseEpisodesFromRaw.FromRawUnchecked"/>
    public static SearchQueryResponseEpisodes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchQueryResponseEpisodesFromRaw : IFromRawJson<SearchQueryResponseEpisodes>
{
    /// <inheritdoc/>
    public SearchQueryResponseEpisodes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchQueryResponseEpisodes.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchQueryResponseShows, SearchQueryResponseShowsFromRaw>)
)]
public sealed record class SearchQueryResponseShows : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init { JsonModel.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { JsonModel.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "previous"); }
        init { JsonModel.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<ShowBase>? Items
    {
        get { return JsonModel.GetNullableClass<List<ShowBase>>(this.RawData, "items"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "items", value);
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
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public SearchQueryResponseShows() { }

    public SearchQueryResponseShows(SearchQueryResponseShows searchQueryResponseShows)
        : base(searchQueryResponseShows) { }

    public SearchQueryResponseShows(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryResponseShows(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchQueryResponseShowsFromRaw.FromRawUnchecked"/>
    public static SearchQueryResponseShows FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchQueryResponseShowsFromRaw : IFromRawJson<SearchQueryResponseShows>
{
    /// <inheritdoc/>
    public SearchQueryResponseShows FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchQueryResponseShows.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<SearchQueryResponseTracks, SearchQueryResponseTracksFromRaw>)
)]
public sealed record class SearchQueryResponseTracks : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init { JsonModel.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { JsonModel.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "previous"); }
        init { JsonModel.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<TrackObject>? Items
    {
        get { return JsonModel.GetNullableClass<List<TrackObject>>(this.RawData, "items"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "items", value);
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
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public SearchQueryResponseTracks() { }

    public SearchQueryResponseTracks(SearchQueryResponseTracks searchQueryResponseTracks)
        : base(searchQueryResponseTracks) { }

    public SearchQueryResponseTracks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryResponseTracks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SearchQueryResponseTracksFromRaw.FromRawUnchecked"/>
    public static SearchQueryResponseTracks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SearchQueryResponseTracksFromRaw : IFromRawJson<SearchQueryResponseTracks>
{
    /// <inheritdoc/>
    public SearchQueryResponseTracks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SearchQueryResponseTracks.FromRawUnchecked(rawData);
}
