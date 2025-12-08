using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

/// <summary>
/// Seeks to the given position in the user’s currently playing track. This API only
/// works for users who have Spotify Premium. The order of execution is not guaranteed
/// when you use this API with other Player API endpoints.
/// </summary>
public sealed record class PlayerSeekToPositionParams : ParamsBase
{
    /// <summary>
    /// The position in milliseconds to seek to. Must be a positive number. Passing
    /// in a position that is greater than the length of the track will cause the
    /// player to start playing the next song.
    /// </summary>
    public required long PositionMs
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawQueryData, "position_ms"); }
        init { ModelBase.Set(this._rawQueryData, "position_ms", value); }
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

    public PlayerSeekToPositionParams() { }

    public PlayerSeekToPositionParams(PlayerSeekToPositionParams playerSeekToPositionParams)
        : base(playerSeekToPositionParams) { }

    public PlayerSeekToPositionParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerSeekToPositionParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static PlayerSeekToPositionParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/me/player/seek")
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
