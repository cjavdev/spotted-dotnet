using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Artists;

[JsonConverter(
    typeof(JsonModelConverter<ArtistListAlbumsPageResponse, ArtistListAlbumsPageResponseFromRaw>)
)]
public sealed record class ArtistListAlbumsPageResponse : JsonModel
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

    public ArtistListAlbumsPageResponse() { }

    public ArtistListAlbumsPageResponse(ArtistListAlbumsPageResponse artistListAlbumsPageResponse)
        : base(artistListAlbumsPageResponse) { }

    public ArtistListAlbumsPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtistListAlbumsPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtistListAlbumsPageResponseFromRaw.FromRawUnchecked"/>
    public static ArtistListAlbumsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArtistListAlbumsPageResponseFromRaw : IFromRawJson<ArtistListAlbumsPageResponse>
{
    /// <inheritdoc/>
    public ArtistListAlbumsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ArtistListAlbumsPageResponse.FromRawUnchecked(rawData);
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
    /// This field describes the relationship between the artist and the album.
    /// </summary>
    public required ApiEnum<string, AlbumGroup> AlbumGroup
    {
        get
        {
            return JsonModel.GetNotNullClass<ApiEnum<string, AlbumGroup>>(
                this.RawData,
                "album_group"
            );
        }
        init { JsonModel.Set(this._rawData, "album_group", value); }
    }

    /// <summary>
    /// The type of the album.
    /// </summary>
    public required ApiEnum<string, global::Spotted.Models.Artists.AlbumType> AlbumType
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Spotted.Models.Artists.AlbumType>
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
        global::Spotted.Models.Artists.ReleaseDatePrecision
    > ReleaseDatePrecision
    {
        get
        {
            return JsonModel.GetNotNullClass<
                ApiEnum<string, global::Spotted.Models.Artists.ReleaseDatePrecision>
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
        this.AlbumGroup.Validate();
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
/// This field describes the relationship between the artist and the album.
/// </summary>
[JsonConverter(typeof(AlbumGroupConverter))]
public enum AlbumGroup
{
    Album,
    Single,
    Compilation,
    AppearsOn,
}

sealed class AlbumGroupConverter : JsonConverter<AlbumGroup>
{
    public override AlbumGroup Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "album" => AlbumGroup.Album,
            "single" => AlbumGroup.Single,
            "compilation" => AlbumGroup.Compilation,
            "appears_on" => AlbumGroup.AppearsOn,
            _ => (AlbumGroup)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlbumGroup value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlbumGroup.Album => "album",
                AlbumGroup.Single => "single",
                AlbumGroup.Compilation => "compilation",
                AlbumGroup.AppearsOn => "appears_on",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The type of the album.
/// </summary>
[JsonConverter(typeof(global::Spotted.Models.Artists.AlbumTypeConverter))]
public enum AlbumType
{
    Album,
    Single,
    Compilation,
}

sealed class AlbumTypeConverter : JsonConverter<global::Spotted.Models.Artists.AlbumType>
{
    public override global::Spotted.Models.Artists.AlbumType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "album" => global::Spotted.Models.Artists.AlbumType.Album,
            "single" => global::Spotted.Models.Artists.AlbumType.Single,
            "compilation" => global::Spotted.Models.Artists.AlbumType.Compilation,
            _ => (global::Spotted.Models.Artists.AlbumType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Artists.AlbumType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Artists.AlbumType.Album => "album",
                global::Spotted.Models.Artists.AlbumType.Single => "single",
                global::Spotted.Models.Artists.AlbumType.Compilation => "compilation",
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
[JsonConverter(typeof(global::Spotted.Models.Artists.ReleaseDatePrecisionConverter))]
public enum ReleaseDatePrecision
{
    Year,
    Month,
    Day,
}

sealed class ReleaseDatePrecisionConverter
    : JsonConverter<global::Spotted.Models.Artists.ReleaseDatePrecision>
{
    public override global::Spotted.Models.Artists.ReleaseDatePrecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "year" => global::Spotted.Models.Artists.ReleaseDatePrecision.Year,
            "month" => global::Spotted.Models.Artists.ReleaseDatePrecision.Month,
            "day" => global::Spotted.Models.Artists.ReleaseDatePrecision.Day,
            _ => (global::Spotted.Models.Artists.ReleaseDatePrecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Artists.ReleaseDatePrecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Artists.ReleaseDatePrecision.Year => "year",
                global::Spotted.Models.Artists.ReleaseDatePrecision.Month => "month",
                global::Spotted.Models.Artists.ReleaseDatePrecision.Day => "day",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
