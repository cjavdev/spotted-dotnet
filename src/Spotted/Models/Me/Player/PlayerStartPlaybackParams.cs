using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

/// <summary>
/// Start a new context or resume current playback on the user's active device. This
/// API only works for users who have Spotify Premium. The order of execution is
/// not guaranteed when you use this API with other Player API endpoints.
/// </summary>
public sealed record class PlayerStartPlaybackParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The id of the device this command is targeting. If not supplied, the user's
    /// currently active device is the target.
    /// </summary>
    public string? DeviceID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "device_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "device_id", value);
        }
    }

    /// <summary>
    /// Optional. Spotify URI of the context to play. Valid contexts are albums,
    /// artists & playlists. `{context_uri:"spotify:album:1Je1IMUlBXcx1Fz0WE7oPT"}`
    /// </summary>
    public string? ContextUri
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "context_uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "context_uri", value);
        }
    }

    /// <summary>
    /// Optional. Indicates from where in the context playback should start. Only
    /// available when context_uri corresponds to an album or playlist object "position"
    /// is zero based and can’t be negative. Example: `"offset": {"position": 5}`
    /// "uri" is a string representing the uri of the item to start at. Example: `"offset":
    /// {"uri": "spotify:track:1301WleyT98MSxVHPZCA6M"}`
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Offset
    {
        get
        {
            return ModelBase.GetNullableClass<Dictionary<string, JsonElement>>(
                this.RawBodyData,
                "offset"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "offset", value);
        }
    }

    /// <summary>
    /// Indicates from what position to start playback. Must be a positive number.
    /// Passing in a position that is greater than the length of the track will cause
    /// the player to start playing the next song.
    /// </summary>
    public long? PositionMs
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawBodyData, "position_ms"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "position_ms", value);
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
    /// Optional. A JSON array of the Spotify track URIs to play. For example: `{"uris":
    /// ["spotify:track:4iV5W9uYEdYUVa79Axb7Rh", "spotify:track:1301WleyT98MSxVHPZCA6M"]}`
    /// </summary>
    public IReadOnlyList<string>? Uris
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawBodyData, "uris"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "uris", value);
        }
    }

    public PlayerStartPlaybackParams() { }

    public PlayerStartPlaybackParams(PlayerStartPlaybackParams playerStartPlaybackParams)
        : base(playerStartPlaybackParams)
    {
        this._rawBodyData = [.. playerStartPlaybackParams._rawBodyData];
    }

    public PlayerStartPlaybackParams(
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
    PlayerStartPlaybackParams(
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
    public static PlayerStartPlaybackParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/me/player/play")
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
