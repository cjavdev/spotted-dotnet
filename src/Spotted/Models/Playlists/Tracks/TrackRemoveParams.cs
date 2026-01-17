using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
    readonly JsonDictionary _rawBodyData = new();
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
    public required IReadOnlyList<Track> Tracks
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Track>>("tracks");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Track>>(
                "tracks",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("published", value);
        }
    }

    /// <summary>
    /// The playlist's snapshot ID against which you want to make the changes. The
    /// API will validate that the specified items exist and in the specified positions
    /// and make the changes, even if more recent changes have been made to the playlist.
    /// </summary>
    public string? SnapshotID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("snapshot_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("snapshot_id", value);
        }
    }

    public TrackRemoveParams() { }

    public TrackRemoveParams(TrackRemoveParams trackRemoveParams)
        : base(trackRemoveParams)
    {
        this.PlaylistID = trackRemoveParams.PlaylistID;

        this._rawBodyData = new(trackRemoveParams._rawBodyData);
    }

    public TrackRemoveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackRemoveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
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

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
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

[JsonConverter(typeof(JsonModelConverter<Track, TrackFromRaw>))]
public sealed record class Track : JsonModel
{
    /// <summary>
    /// Spotify URI
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
        _ = this.Uri;
    }

    public Track() { }

    public Track(Track track)
        : base(track) { }

    public Track(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Track(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackFromRaw.FromRawUnchecked"/>
    public static Track FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackFromRaw : IFromRawJson<Track>
{
    /// <inheritdoc/>
    public Track FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Track.FromRawUnchecked(rawData);
}
