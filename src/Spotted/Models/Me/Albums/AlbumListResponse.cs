using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Me.Albums;

[JsonConverter(typeof(JsonModelConverter<AlbumListResponse, AlbumListResponseFromRaw>))]
public sealed record class AlbumListResponse : JsonModel
{
    /// <summary>
    /// The date and time the album was saved Timestamps are returned in ISO 8601
    /// format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.
    /// If the time is imprecise (for example, the date/time of an album release),
    /// an additional field indicates the precision; see for example, release_date
    /// in an album object.
    /// </summary>
    public System::DateTimeOffset? AddedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>("added_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("added_at", value);
        }
    }

    /// <summary>
    /// Information about the album.
    /// </summary>
    public Album? Album
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Album>("album");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("album", value);
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
        _ = this.AddedAt;
        this.Album?.Validate();
        _ = this.Published;
    }

    public AlbumListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlbumListResponse(AlbumListResponse albumListResponse)
        : base(albumListResponse) { }
#pragma warning restore CS8618

    public AlbumListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumListResponseFromRaw.FromRawUnchecked"/>
    public static AlbumListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumListResponseFromRaw : IFromRawJson<AlbumListResponse>
{
    /// <inheritdoc/>
    public AlbumListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AlbumListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the album.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Album, AlbumFromRaw>))]
public sealed record class Album : JsonModel
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
    public required ApiEnum<string, AlbumType> AlbumType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AlbumType>>("album_type");
        }
        init { this._rawData.Set("album_type", value); }
    }

    /// <summary>
    /// The markets in which the album is available: [ISO 3166-1 alpha-2 country
    /// codes](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). _**NOTE**: an album
    /// is considered available in a market when at least 1 of its tracks is available
    /// in that market._
    /// </summary>
    [System::Obsolete("deprecated")]
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
    public required ApiEnum<string, ReleaseDatePrecision> ReleaseDatePrecision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ReleaseDatePrecision>>(
                "release_date_precision"
            );
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
    [System::Obsolete("deprecated")]
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
    [System::Obsolete("deprecated")]
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
    [System::Obsolete("deprecated")]
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
    public AlbumTracks? Tracks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AlbumTracks>("tracks");
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

    [System::Obsolete("Required properties are deprecated: available_markets")]
    public Album()
    {
        this.Type = JsonSerializer.SerializeToElement("album");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    [System::Obsolete("Required properties are deprecated: available_markets")]
    public Album(Album album)
        : base(album) { }
#pragma warning restore CS8618

    [System::Obsolete("Required properties are deprecated: available_markets")]
    public Album(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("album");
    }

#pragma warning disable CS8618
    [System::Obsolete("Required properties are deprecated: available_markets")]
    [SetsRequiredMembers]
    Album(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumFromRaw.FromRawUnchecked"/>
    public static Album FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumFromRaw : IFromRawJson<Album>
{
    /// <inheritdoc/>
    public Album FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Album.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the album.
/// </summary>
[JsonConverter(typeof(AlbumTypeConverter))]
public enum AlbumType
{
    Album,
    Single,
    Compilation,
}

sealed class AlbumTypeConverter : JsonConverter<AlbumType>
{
    public override AlbumType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "album" => AlbumType.Album,
            "single" => AlbumType.Single,
            "compilation" => AlbumType.Compilation,
            _ => (AlbumType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlbumType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlbumType.Album => "album",
                AlbumType.Single => "single",
                AlbumType.Compilation => "compilation",
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
[JsonConverter(typeof(ReleaseDatePrecisionConverter))]
public enum ReleaseDatePrecision
{
    Year,
    Month,
    Day,
}

sealed class ReleaseDatePrecisionConverter : JsonConverter<ReleaseDatePrecision>
{
    public override ReleaseDatePrecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "year" => ReleaseDatePrecision.Year,
            "month" => ReleaseDatePrecision.Month,
            "day" => ReleaseDatePrecision.Day,
            _ => (ReleaseDatePrecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReleaseDatePrecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ReleaseDatePrecision.Year => "year",
                ReleaseDatePrecision.Month => "month",
                ReleaseDatePrecision.Day => "day",
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
[JsonConverter(typeof(JsonModelConverter<AlbumTracks, AlbumTracksFromRaw>))]
public sealed record class AlbumTracks : JsonModel
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

    public AlbumTracks() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlbumTracks(AlbumTracks albumTracks)
        : base(albumTracks) { }
#pragma warning restore CS8618

    public AlbumTracks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumTracks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumTracksFromRaw.FromRawUnchecked"/>
    public static AlbumTracks FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumTracksFromRaw : IFromRawJson<AlbumTracks>
{
    /// <inheritdoc/>
    public AlbumTracks FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AlbumTracks.FromRawUnchecked(rawData);
}
