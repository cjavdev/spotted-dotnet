using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Playlists.Tracks;

/// <summary>
/// Remove one or more items from a user's playlist.
/// </summary>
public sealed record class TrackRemoveParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PlaylistID { get; init; }

    /// <summary>
    /// An array of objects containing [Spotify URIs](/documentation/web-api/concepts/spotify-uris-ids)
    /// of the tracks or episodes to remove. For example: `{ "tracks": [{ "uri":
    /// "spotify:track:4iV5W9uYEdYUVa79Axb7Rh" },{ "uri": "spotify:track:1301WleyT98MSxVHPZCA6M"
    /// }] }`. A maximum of 100 objects can be sent at once.
    /// </summary>
    public required IReadOnlyList<global::Spotted.Models.Playlists.Tracks.Track> Tracks
    {
        get
        {
            return ModelBase.GetNotNullClass<List<global::Spotted.Models.Playlists.Tracks.Track>>(
                this.RawBodyData,
                "tracks"
            );
        }
        init { ModelBase.Set(this._rawBodyData, "tracks", value); }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "published", value);
        }
    }

    /// <summary>
    /// The playlist's snapshot ID against which you want to make the changes. The
    /// API will validate that the specified items exist and in the specified positions
    /// and make the changes, even if more recent changes have been made to the playlist.
    /// </summary>
    public string? SnapshotID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "snapshot_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "snapshot_id", value);
        }
    }

    public TrackRemoveParams() { }

    public TrackRemoveParams(TrackRemoveParams trackRemoveParams)
        : base(trackRemoveParams)
    {
        this._rawBodyData = [.. trackRemoveParams._rawBodyData];
    }

    public TrackRemoveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackRemoveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static TrackRemoveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/playlists/{0}/tracks", this.PlaylistID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<global::Spotted.Models.Playlists.Tracks.Track, TrackFromRaw>))]
public sealed record class Track : ModelBase
{
    /// <summary>
    /// Spotify URI
    /// </summary>
    public string? Uri
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Uri;
    }

    public Track() { }

    public Track(global::Spotted.Models.Playlists.Tracks.Track track)
        : base(track) { }

    public Track(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Track(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackFromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Playlists.Tracks.Track FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackFromRaw : IFromRaw<global::Spotted.Models.Playlists.Tracks.Track>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Playlists.Tracks.Track FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Playlists.Tracks.Track.FromRawUnchecked(rawData);
}
