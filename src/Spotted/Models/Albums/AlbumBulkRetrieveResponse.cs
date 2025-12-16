using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Albums;

[JsonConverter(typeof(ModelConverter<AlbumBulkRetrieveResponse, AlbumBulkRetrieveResponseFromRaw>))]
public sealed record class AlbumBulkRetrieveResponse : ModelBase
{
    public required IReadOnlyList<global::Spotted.Models.Albums.Album> Albums
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Spotted.Models.Albums.Album>>(
                this.RawData,
                "albums"
            );
        }
        init { ModelBase.Set(this._rawData, "albums", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Albums)
        {
            item.Validate();
        }
    }

    public AlbumBulkRetrieveResponse() { }

    public AlbumBulkRetrieveResponse(AlbumBulkRetrieveResponse albumBulkRetrieveResponse)
        : base(albumBulkRetrieveResponse) { }

    public AlbumBulkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumBulkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumBulkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AlbumBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AlbumBulkRetrieveResponse(List<global::Spotted.Models.Albums.Album> albums)
        : this()
    {
        this.Albums = albums;
    }
}

class AlbumBulkRetrieveResponseFromRaw : IFromRaw<AlbumBulkRetrieveResponse>
{
    /// <inheritdoc/>
    public AlbumBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AlbumBulkRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Spotted.Models.Albums.Album,
        global::Spotted.Models.Albums.AlbumFromRaw
    >)
)]
public sealed record class Album : ModelBase
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// album.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The type of the album.
    /// </summary>
    public required ApiEnum<string, AlbumAlbumType> AlbumType
    {
        get
        {
            return ModelBase.GetNotNullClass<ApiEnum<string, AlbumAlbumType>>(
                this.RawData,
                "album_type"
            );
        }
        init { ModelBase.Set(this._rawData, "album_type", value); }
    }

    /// <summary>
    /// The markets in which the album is available: [ISO 3166-1 alpha-2 country
    /// codes](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). _**NOTE**: an album
    /// is considered available in a market when at least 1 of its tracks is available
    /// in that market._
    /// </summary>
    public required IReadOnlyList<string> AvailableMarkets
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "available_markets"); }
        init { ModelBase.Set(this._rawData, "available_markets", value); }
    }

    /// <summary>
    /// Known external URLs for this album.
    /// </summary>
    public required ExternalURLObject ExternalURLs
    {
        get { return ModelBase.GetNotNullClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init { ModelBase.Set(this._rawData, "external_urls", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the album.
    /// </summary>
    public required string Href
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The cover art for the album in various sizes, widest first.
    /// </summary>
    public required IReadOnlyList<ImageObject> Images
    {
        get { return ModelBase.GetNotNullClass<List<ImageObject>>(this.RawData, "images"); }
        init { ModelBase.Set(this._rawData, "images", value); }
    }

    /// <summary>
    /// The name of the album. In case of an album takedown, the value may be an
    /// empty string.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The date the album was first released.
    /// </summary>
    public required string ReleaseDate
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "release_date"); }
        init { ModelBase.Set(this._rawData, "release_date", value); }
    }

    /// <summary>
    /// The precision with which `release_date` value is known.
    /// </summary>
    public required ApiEnum<
        string,
        global::Spotted.Models.Albums.AlbumReleaseDatePrecision
    > ReleaseDatePrecision
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Spotted.Models.Albums.AlbumReleaseDatePrecision>
            >(this.RawData, "release_date_precision");
        }
        init { ModelBase.Set(this._rawData, "release_date_precision", value); }
    }

    /// <summary>
    /// The number of tracks in the album.
    /// </summary>
    public required long TotalTracks
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "total_tracks"); }
        init { ModelBase.Set(this._rawData, "total_tracks", value); }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// album.
    /// </summary>
    public required string Uri
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "uri"); }
        init { ModelBase.Set(this._rawData, "uri", value); }
    }

    /// <summary>
    /// The artists of the album. Each artist object includes a link in `href` to
    /// more detailed information about the artist.
    /// </summary>
    public IReadOnlyList<SimplifiedArtistObject>? Artists
    {
        get
        {
            return ModelBase.GetNullableClass<List<SimplifiedArtistObject>>(
                this.RawData,
                "artists"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "artists", value);
        }
    }

    /// <summary>
    /// The copyright statements of the album.
    /// </summary>
    public IReadOnlyList<CopyrightObject>? Copyrights
    {
        get
        {
            return ModelBase.GetNullableClass<List<CopyrightObject>>(this.RawData, "copyrights");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "copyrights", value);
        }
    }

    /// <summary>
    /// Known external IDs for the album.
    /// </summary>
    public ExternalIDObject? ExternalIDs
    {
        get { return ModelBase.GetNullableClass<ExternalIDObject>(this.RawData, "external_ids"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "external_ids", value);
        }
    }

    /// <summary>
    /// **Deprecated** The array is always empty.
    /// </summary>
    [System::Obsolete("deprecated")]
    public IReadOnlyList<string>? Genres
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "genres"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "genres", value);
        }
    }

    /// <summary>
    /// The label associated with the album.
    /// </summary>
    public string? Label
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "label"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "label", value);
        }
    }

    /// <summary>
    /// The popularity of the album. The value will be between 0 and 100, with 100
    /// being the most popular.
    /// </summary>
    public long? Popularity
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "popularity"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "popularity", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// Included in the response when a content restriction is applied.
    /// </summary>
    public AlbumRestrictionObject? Restrictions
    {
        get
        {
            return ModelBase.GetNullableClass<AlbumRestrictionObject>(this.RawData, "restrictions");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "restrictions", value);
        }
    }

    /// <summary>
    /// The tracks of the album.
    /// </summary>
    public AlbumTracks? Tracks
    {
        get { return ModelBase.GetNullableClass<AlbumTracks>(this.RawData, "tracks"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "tracks", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AlbumType.Validate();
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
        foreach (var item in this.Artists ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Copyrights ?? [])
        {
            item.Validate();
        }
        this.ExternalIDs?.Validate();
        _ = this.Genres;
        _ = this.Label;
        _ = this.Popularity;
        _ = this.Published;
        this.Restrictions?.Validate();
        this.Tracks?.Validate();
    }

    public Album()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"album\"");
    }

    public Album(global::Spotted.Models.Albums.Album album)
        : base(album) { }

    public Album(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"album\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Album(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Spotted.Models.Albums.AlbumFromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Albums.Album FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumFromRaw : IFromRaw<global::Spotted.Models.Albums.Album>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Albums.Album FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Albums.Album.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the album.
/// </summary>
[JsonConverter(typeof(AlbumAlbumTypeConverter))]
public enum AlbumAlbumType
{
    Album,
    Single,
    Compilation,
}

sealed class AlbumAlbumTypeConverter : JsonConverter<AlbumAlbumType>
{
    public override AlbumAlbumType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "album" => AlbumAlbumType.Album,
            "single" => AlbumAlbumType.Single,
            "compilation" => AlbumAlbumType.Compilation,
            _ => (AlbumAlbumType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlbumAlbumType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlbumAlbumType.Album => "album",
                AlbumAlbumType.Single => "single",
                AlbumAlbumType.Compilation => "compilation",
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
[JsonConverter(typeof(global::Spotted.Models.Albums.AlbumReleaseDatePrecisionConverter))]
public enum AlbumReleaseDatePrecision
{
    Year,
    Month,
    Day,
}

sealed class AlbumReleaseDatePrecisionConverter
    : JsonConverter<global::Spotted.Models.Albums.AlbumReleaseDatePrecision>
{
    public override global::Spotted.Models.Albums.AlbumReleaseDatePrecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "year" => global::Spotted.Models.Albums.AlbumReleaseDatePrecision.Year,
            "month" => global::Spotted.Models.Albums.AlbumReleaseDatePrecision.Month,
            "day" => global::Spotted.Models.Albums.AlbumReleaseDatePrecision.Day,
            _ => (global::Spotted.Models.Albums.AlbumReleaseDatePrecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Albums.AlbumReleaseDatePrecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Albums.AlbumReleaseDatePrecision.Year => "year",
                global::Spotted.Models.Albums.AlbumReleaseDatePrecision.Month => "month",
                global::Spotted.Models.Albums.AlbumReleaseDatePrecision.Day => "day",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The tracks of the album.
/// </summary>
[JsonConverter(typeof(ModelConverter<AlbumTracks, AlbumTracksFromRaw>))]
public sealed record class AlbumTracks : ModelBase
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { ModelBase.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "next"); }
        init { ModelBase.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { ModelBase.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "previous"); }
        init { ModelBase.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "total"); }
        init { ModelBase.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<SimplifiedTrackObject>? Items
    {
        get
        {
            return ModelBase.GetNullableClass<List<SimplifiedTrackObject>>(this.RawData, "items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "items", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
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

    public AlbumTracks() { }

    public AlbumTracks(AlbumTracks albumTracks)
        : base(albumTracks) { }

    public AlbumTracks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumTracks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumTracksFromRaw.FromRawUnchecked"/>
    public static AlbumTracks FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumTracksFromRaw : IFromRaw<AlbumTracks>
{
    /// <inheritdoc/>
    public AlbumTracks FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AlbumTracks.FromRawUnchecked(rawData);
}
