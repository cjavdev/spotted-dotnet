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

[JsonConverter(typeof(JsonModelConverter<TrackObject, TrackObjectFromRaw>))]
public sealed record class TrackObject : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// track.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The album on which the track appears. The album object includes a link in
    /// `href` to full information about the album.
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
    /// The artists who performed the track. Each artist object includes a link in
    /// `href` to more detailed information about the artist.
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
    /// A list of the countries in which the track can be played, identified by their
    /// [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code.
    /// </summary>
    public IReadOnlyList<string>? AvailableMarkets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("available_markets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "available_markets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The disc number (usually `1` unless the album consists of more than one disc).
    /// </summary>
    public long? DiscNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("disc_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("disc_number", value);
        }
    }

    /// <summary>
    /// The track length in milliseconds.
    /// </summary>
    public long? DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("duration_ms");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("duration_ms", value);
        }
    }

    /// <summary>
    /// Whether or not the track has explicit lyrics ( `true` = yes it does; `false`
    /// = no it does not OR unknown).
    /// </summary>
    public bool? Explicit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("explicit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("explicit", value);
        }
    }

    /// <summary>
    /// Known external IDs for the track.
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
    /// Known external URLs for this track.
    /// </summary>
    public ExternalUrlObject? ExternalUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalUrlObject>("external_urls");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("external_urls", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the track.
    /// </summary>
    public string? Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("href");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("href", value);
        }
    }

    /// <summary>
    /// Whether or not the track is from a local file.
    /// </summary>
    public bool? IsLocal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_local");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_local", value);
        }
    }

    /// <summary>
    /// Part of the response when [Track Relinking](/documentation/web-api/concepts/track-relinking)
    /// is applied. If `true`, the track is playable in the given market. Otherwise
    /// `false`.
    /// </summary>
    public bool? IsPlayable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("is_playable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("is_playable", value);
        }
    }

    /// <summary>
    /// Part of the response when [Track Relinking](/documentation/web-api/concepts/track-relinking)
    /// is applied, and the requested track has been replaced with different track.
    /// The track in the `linked_from` object contains information about the originally
    /// requested track.
    /// </summary>
    public LinkedTrackObject? LinkedFrom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LinkedTrackObject>("linked_from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("linked_from", value);
        }
    }

    /// <summary>
    /// The name of the track.
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The popularity of the track. The value will be between 0 and 100, with 100
    /// being the most popular.<br/>The popularity of a track is a value between 0
    /// and 100, with 100 being the most popular. The popularity is calculated by
    /// algorithm and is based, in the most part, on the total number of plays the
    /// track has had and how recent those plays are.<br/>Generally speaking, songs
    /// that are being played a lot now will have a higher popularity than songs that
    /// were played a lot in the past. Duplicate tracks (e.g. the same track from
    /// a single and an album) are rated independently. Artist and album popularity
    /// is derived mathematically from track popularity. _**Note**: the popularity
    /// value may lag actual popularity by a few days: the value is not updated in
    /// real time._
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
    /// A link to a 30 second preview (MP3 format) of the track. Can be `null`
    /// </summary>
    [System::Obsolete("deprecated")]
    public string? PreviewUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("preview_url");
        }
        init { this._rawData.Set("preview_url", value); }
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
    public TrackRestrictionObject? Restrictions
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrackRestrictionObject>("restrictions");
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
    /// The number of the track. If an album has several discs, the track number
    /// is the number on the specified disc.
    /// </summary>
    public long? TrackNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("track_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("track_number", value);
        }
    }

    /// <summary>
    /// The object type: "track".
    /// </summary>
    public ApiEnum<string, TrackObjectType>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, TrackObjectType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// track.
    /// </summary>
    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Album?.Validate();
        foreach (var item in this.Artists ?? [])
        {
            item.Validate();
        }
        _ = this.AvailableMarkets;
        _ = this.DiscNumber;
        _ = this.DurationMs;
        _ = this.Explicit;
        this.ExternalIds?.Validate();
        this.ExternalUrls?.Validate();
        _ = this.Href;
        _ = this.IsLocal;
        _ = this.IsPlayable;
        this.LinkedFrom?.Validate();
        _ = this.Name;
        _ = this.Popularity;
        _ = this.PreviewUrl;
        _ = this.Published;
        this.Restrictions?.Validate();
        _ = this.TrackNumber;
        this.Type?.Validate();
        _ = this.Uri;
    }

    public TrackObject() { }

    public TrackObject(TrackObject trackObject)
        : base(trackObject) { }

    public TrackObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackObjectFromRaw.FromRawUnchecked"/>
    public static TrackObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackObjectFromRaw : IFromRawJson<TrackObject>
{
    /// <inheritdoc/>
    public TrackObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrackObject.FromRawUnchecked(rawData);
}

/// <summary>
/// The album on which the track appears. The album object includes a link in `href`
/// to full information about the album.
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
    /// The artists of the album. Each artist object includes a link in `href` to
    /// more detailed information about the artist.
    /// </summary>
    public required IReadOnlyList<SimplifiedArtistObject> Artists
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SimplifiedArtistObject>>(
                "artists"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<SimplifiedArtistObject>>(
                "artists",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
    public required ApiEnum<string, AlbumReleaseDatePrecision> ReleaseDatePrecision
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AlbumReleaseDatePrecision>>(
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

    public Album()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"album\"");
    }

    public Album(Album album)
        : base(album) { }

    public Album(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"album\"");
    }

#pragma warning disable CS8618
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
[JsonConverter(typeof(AlbumReleaseDatePrecisionConverter))]
public enum AlbumReleaseDatePrecision
{
    Year,
    Month,
    Day,
}

sealed class AlbumReleaseDatePrecisionConverter : JsonConverter<AlbumReleaseDatePrecision>
{
    public override AlbumReleaseDatePrecision Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "year" => AlbumReleaseDatePrecision.Year,
            "month" => AlbumReleaseDatePrecision.Month,
            "day" => AlbumReleaseDatePrecision.Day,
            _ => (AlbumReleaseDatePrecision)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AlbumReleaseDatePrecision value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                AlbumReleaseDatePrecision.Year => "year",
                AlbumReleaseDatePrecision.Month => "month",
                AlbumReleaseDatePrecision.Day => "day",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// The object type: "track".
/// </summary>
[JsonConverter(typeof(TrackObjectTypeConverter))]
public enum TrackObjectType
{
    Track,
}

sealed class TrackObjectTypeConverter : JsonConverter<TrackObjectType>
{
    public override TrackObjectType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "track" => TrackObjectType.Track,
            _ => (TrackObjectType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TrackObjectType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TrackObjectType.Track => "track",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
