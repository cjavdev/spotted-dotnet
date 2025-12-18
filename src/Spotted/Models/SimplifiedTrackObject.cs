using System;
using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
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
            return JsonModel.GetNullableClass<List<SimplifiedArtistObject>>(
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

            JsonModel.Set(this._rawData, "artists", value);
        }
    }

    /// <summary>
    /// A list of the countries in which the track can be played, identified by their
    /// [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code.
    /// </summary>
    public IReadOnlyList<string>? AvailableMarkets
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "available_markets"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "available_markets", value);
        }
    }

    /// <summary>
    /// The disc number (usually `1` unless the album consists of more than one disc).
    /// </summary>
    public long? DiscNumber
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "disc_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "disc_number", value);
        }
    }

    /// <summary>
    /// The track length in milliseconds.
    /// </summary>
    public long? DurationMs
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "duration_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "duration_ms", value);
        }
    }

    /// <summary>
    /// Whether or not the track has explicit lyrics ( `true` = yes it does; `false`
    /// = no it does not OR unknown).
    /// </summary>
    public bool? Explicit
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "explicit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "explicit", value);
        }
    }

    /// <summary>
    /// External URLs for this track.
    /// </summary>
    public ExternalURLObject? ExternalURLs
    {
        get { return JsonModel.GetNullableClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "external_urls", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the track.
    /// </summary>
    public string? Href
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "href", value);
        }
    }

    /// <summary>
    /// Whether or not the track is from a local file.
    /// </summary>
    public bool? IsLocal
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "is_local"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "is_local", value);
        }
    }

    /// <summary>
    /// Part of the response when [Track Relinking](/documentation/web-api/concepts/track-relinking/)
    /// is applied. If `true`, the track is playable in the given market. Otherwise
    /// `false`.
    /// </summary>
    public bool? IsPlayable
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "is_playable"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "is_playable", value);
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
        get { return JsonModel.GetNullableClass<LinkedTrackObject>(this.RawData, "linked_from"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "linked_from", value);
        }
    }

    /// <summary>
    /// The name of the track.
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// A URL to a 30 second preview (MP3 format) of the track.
    /// </summary>
    [Obsolete("deprecated")]
    public string? PreviewURL
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "preview_url"); }
        init { JsonModel.Set(this._rawData, "preview_url", value); }
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
    public TrackRestrictionObject? Restrictions
    {
        get
        {
            return JsonModel.GetNullableClass<TrackRestrictionObject>(this.RawData, "restrictions");
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

    /// <summary>
    /// The number of the track. If an album has several discs, the track number
    /// is the number on the specified disc.
    /// </summary>
    public long? TrackNumber
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "track_number"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "track_number", value);
        }
    }

    /// <summary>
    /// The object type: "track".
    /// </summary>
    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// track.
    /// </summary>
    public string? Uri
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "uri", value);
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
        this.ExternalURLs?.Validate();
        _ = this.Href;
        _ = this.IsLocal;
        _ = this.IsPlayable;
        this.LinkedFrom?.Validate();
        _ = this.Name;
        _ = this.PreviewURL;
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SimplifiedTrackObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
