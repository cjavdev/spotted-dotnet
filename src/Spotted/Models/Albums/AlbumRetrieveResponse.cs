using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Albums;

[JsonConverter(typeof(JsonModelConverter<AlbumRetrieveResponse, AlbumRetrieveResponseFromRaw>))]
public sealed record class AlbumRetrieveResponse : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// album.
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
    /// The type of the album.
    /// </summary>
    public required ApiEnum<string, global::Spotted.Models.Albums.AlbumType> AlbumType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Spotted.Models.Albums.AlbumType>
            >("album_type");
        }
        init { this._rawData.Set("album_type", value); }
    }

    /// <summary>
    /// The markets in which the album is available: [ISO 3166-1 alpha-2 country
    /// codes](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). _**NOTE**: an album
    /// is considered available in a market when at least 1 of its tracks is available
    /// in that market._
    /// </summary>
    public required IReadOnlyList<string> AvailableMarkets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("available_markets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "available_markets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Known external URLs for this album.
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
    /// A link to the Web API endpoint providing full details of the album.
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
    /// The cover art for the album in various sizes, widest first.
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
    /// The name of the album. In case of an album takedown, the value may be an
    /// empty string.
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
    /// The date the album was first released.
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
        global::Spotted.Models.Albums.ReleaseDatePrecision
    > ReleaseDatePrecision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Spotted.Models.Albums.ReleaseDatePrecision>
            >("release_date_precision");
        }
        init { this._rawData.Set("release_date_precision", value); }
    }

    /// <summary>
    /// The number of tracks in the album.
    /// </summary>
    public required long TotalTracks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_tracks");
        }
        init { this._rawData.Set("total_tracks", value); }
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
    /// album.
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
    /// The artists of the album. Each artist object includes a link in `href` to
    /// more detailed information about the artist.
    /// </summary>
    public IReadOnlyList<SimplifiedArtistObject>? Artists
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimplifiedArtistObject>>(
                "artists"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SimplifiedArtistObject>?>(
                "artists",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The copyright statements of the album.
    /// </summary>
    public IReadOnlyList<CopyrightObject>? Copyrights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CopyrightObject>>("copyrights");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<CopyrightObject>?>(
                "copyrights",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Known external IDs for the album.
    /// </summary>
    public ExternalIDObject? ExternalIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalIDObject>("external_ids");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("external_ids", value);
        }
    }

    /// <summary>
    /// **Deprecated** The array is always empty.
    /// </summary>
    [System::Obsolete("deprecated")]
    public IReadOnlyList<string>? Genres
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("genres");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "genres",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The label associated with the album.
    /// </summary>
    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    /// <summary>
    /// The popularity of the album. The value will be between 0 and 100, with 100
    /// being the most popular.
    /// </summary>
    public long? Popularity
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("popularity");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("popularity", value);
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
    public AlbumRestrictionObject? Restrictions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AlbumRestrictionObject>("restrictions");
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
    /// The tracks of the album.
    /// </summary>
    public AlbumRetrieveResponseTracks? Tracks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AlbumRetrieveResponseTracks>("tracks");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tracks", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.AlbumType.Validate();
        _ = this.AvailableMarkets;
        this.ExternalUrls.Validate();
        _ = this.Href;
        foreach (var item in this.Images)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.ReleaseDate;
        this.ReleaseDatePrecision.Validate();
        _ = this.TotalTracks;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("album")))
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
        this.ExternalIds?.Validate();
        _ = this.Genres;
        _ = this.Label;
        _ = this.Popularity;
        _ = this.Published;
        this.Restrictions?.Validate();
        this.Tracks?.Validate();
    }

    public AlbumRetrieveResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("album");
    }

    public AlbumRetrieveResponse(AlbumRetrieveResponse albumRetrieveResponse)
        : base(albumRetrieveResponse) { }

    public AlbumRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("album");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AlbumRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumRetrieveResponseFromRaw : IFromRawJson<AlbumRetrieveResponse>
{
    /// <inheritdoc/>
    public AlbumRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AlbumRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the album.
/// </summary>
[JsonConverter(typeof(global::Spotted.Models.Albums.AlbumTypeConverter))]
public enum AlbumType
{
    Album,
    Single,
    Compilation,
}

sealed class AlbumTypeConverter : JsonConverter<global::Spotted.Models.Albums.AlbumType>
{
    public override global::Spotted.Models.Albums.AlbumType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "album" => global::Spotted.Models.Albums.AlbumType.Album,
            "single" => global::Spotted.Models.Albums.AlbumType.Single,
            "compilation" => global::Spotted.Models.Albums.AlbumType.Compilation,
            _ => (global::Spotted.Models.Albums.AlbumType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Albums.AlbumType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Albums.AlbumType.Album => "album",
                global::Spotted.Models.Albums.AlbumType.Single => "single",
                global::Spotted.Models.Albums.AlbumType.Compilation => "compilation",
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
[JsonConverter(typeof(global::Spotted.Models.Albums.ReleaseDatePrecisionConverter))]
public enum ReleaseDatePrecision
{
    Year,
    Month,
    Day,
}

sealed class ReleaseDatePrecisionConverter
    : JsonConverter<global::Spotted.Models.Albums.ReleaseDatePrecision>
{
    public override global::Spotted.Models.Albums.ReleaseDatePrecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "year" => global::Spotted.Models.Albums.ReleaseDatePrecision.Year,
            "month" => global::Spotted.Models.Albums.ReleaseDatePrecision.Month,
            "day" => global::Spotted.Models.Albums.ReleaseDatePrecision.Day,
            _ => (global::Spotted.Models.Albums.ReleaseDatePrecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Albums.ReleaseDatePrecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Albums.ReleaseDatePrecision.Year => "year",
                global::Spotted.Models.Albums.ReleaseDatePrecision.Month => "month",
                global::Spotted.Models.Albums.ReleaseDatePrecision.Day => "day",
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
[JsonConverter(
    typeof(JsonModelConverter<AlbumRetrieveResponseTracks, AlbumRetrieveResponseTracksFromRaw>)
)]
public sealed record class AlbumRetrieveResponseTracks : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
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
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("offset");
        }
        init { this._rawData.Set("offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previous");
        }
        init { this._rawData.Set("previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    public IReadOnlyList<SimplifiedTrackObject>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimplifiedTrackObject>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SimplifiedTrackObject>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public AlbumRetrieveResponseTracks() { }

    public AlbumRetrieveResponseTracks(AlbumRetrieveResponseTracks albumRetrieveResponseTracks)
        : base(albumRetrieveResponseTracks) { }

    public AlbumRetrieveResponseTracks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumRetrieveResponseTracks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumRetrieveResponseTracksFromRaw.FromRawUnchecked"/>
    public static AlbumRetrieveResponseTracks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumRetrieveResponseTracksFromRaw : IFromRawJson<AlbumRetrieveResponseTracks>
{
    /// <inheritdoc/>
    public AlbumRetrieveResponseTracks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AlbumRetrieveResponseTracks.FromRawUnchecked(rawData);
}
