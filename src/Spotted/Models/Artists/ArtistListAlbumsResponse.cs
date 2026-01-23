using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Artists;

[JsonConverter(
    typeof(JsonModelConverter<ArtistListAlbumsResponse, ArtistListAlbumsResponseFromRaw>)
)]
public sealed record class ArtistListAlbumsResponse : JsonModel
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
    /// This field describes the relationship between the artist and the album.
    /// </summary>
    public required ApiEnum<string, AlbumGroup> AlbumGroup
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AlbumGroup>>("album_group");
        }
        init { this._rawData.Set("album_group", value); }
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
        this.AlbumGroup.Validate();
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("album")))
        {
            throw new SpottedInvalidDataException("Invalid value given for constant");
        }
        _ = this.Uri;
        _ = this.Published;
        this.Restrictions?.Validate();
    }

    public ArtistListAlbumsResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("album");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtistListAlbumsResponse(ArtistListAlbumsResponse artistListAlbumsResponse)
        : base(artistListAlbumsResponse) { }
#pragma warning restore CS8618

    public ArtistListAlbumsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("album");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtistListAlbumsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtistListAlbumsResponseFromRaw.FromRawUnchecked"/>
    public static ArtistListAlbumsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArtistListAlbumsResponseFromRaw : IFromRawJson<ArtistListAlbumsResponse>
{
    /// <inheritdoc/>
    public ArtistListAlbumsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ArtistListAlbumsResponse.FromRawUnchecked(rawData);
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
