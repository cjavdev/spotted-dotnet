using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<SimplifiedTrackObject, SimplifiedTrackObjectFromRaw>))]
public sealed record class SimplifiedTrackObject : JsonModel
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
    /// External URLs for this track.
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
    /// Part of the response when [Track Relinking](/documentation/web-api/concepts/track-relinking/)
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
    /// Part of the response when [Track Relinking](/documentation/web-api/concepts/track-relinking/)
    /// is applied and is only part of the response if the track linking, in fact,
    /// exists. The requested track has been replaced with a different track. The
    /// track in the `linked_from` object contains information about the originally
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
    /// A URL to a 30 second preview (MP3 format) of the track.
    /// </summary>
    [Obsolete("deprecated")]
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
    public string? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
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
        foreach (var item in this.Artists ?? [])
        {
            item.Validate();
        }
        _ = this.AvailableMarkets;
        _ = this.DiscNumber;
        _ = this.DurationMs;
        _ = this.Explicit;
        this.ExternalUrls?.Validate();
        _ = this.Href;
        _ = this.IsLocal;
        _ = this.IsPlayable;
        this.LinkedFrom?.Validate();
        _ = this.Name;
        _ = this.PreviewUrl;
        _ = this.Published;
        this.Restrictions?.Validate();
        _ = this.TrackNumber;
        _ = this.Type;
        _ = this.Uri;
    }

    public SimplifiedTrackObject() { }

    public SimplifiedTrackObject(SimplifiedTrackObject simplifiedTrackObject)
        : base(simplifiedTrackObject) { }

    public SimplifiedTrackObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SimplifiedTrackObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SimplifiedTrackObjectFromRaw.FromRawUnchecked"/>
    public static SimplifiedTrackObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SimplifiedTrackObjectFromRaw : IFromRawJson<SimplifiedTrackObject>
{
    /// <inheritdoc/>
    public SimplifiedTrackObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SimplifiedTrackObject.FromRawUnchecked(rawData);
}
