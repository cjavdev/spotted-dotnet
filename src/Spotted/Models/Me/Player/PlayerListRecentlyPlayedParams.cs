using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

/// <summary>
/// Get tracks from the current user's recently played tracks. _**Note**: Currently
/// doesn't support podcast episodes._
/// </summary>
public sealed record class PlayerListRecentlyPlayedParams : ParamsBase
{
    /// <summary>
    /// A Unix timestamp in milliseconds. Returns all items after (but not including)
    /// this cursor position. If `after` is specified, `before` must not be specified.
    /// </summary>
    public long? After
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "after"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "after", value);
        }
    }

    /// <summary>
    /// A Unix timestamp in milliseconds. Returns all items before (but not including)
    /// this cursor position. If `before` is specified, `after` must not be specified.
    /// </summary>
    public long? Before
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "before"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "before", value);
        }
    }

    /// <summary>
    /// The maximum number of items to return. Default: 20. Minimum: 1. Maximum:
    /// 50.
    /// </summary>
    public long? Limit
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "limit", value);
        }
    }

    public PlayerListRecentlyPlayedParams() { }

    public PlayerListRecentlyPlayedParams(
        PlayerListRecentlyPlayedParams playerListRecentlyPlayedParams
    )
        : base(playerListRecentlyPlayedParams) { }

    public PlayerListRecentlyPlayedParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerListRecentlyPlayedParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static PlayerListRecentlyPlayedParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/me/player/recently-played"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
