using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

/// <summary>
/// Set the volume for the user’s current playback device. This API only works for
/// users who have Spotify Premium. The order of execution is not guaranteed when
/// you use this API with other Player API endpoints.
/// </summary>
public sealed record class PlayerSetVolumeParams : ParamsBase
{
    /// <summary>
    /// The volume to set. Must be a value from 0 to 100 inclusive.
    /// </summary>
    public required long VolumePercent
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawQueryData, "volume_percent"); }
        init { JsonModel.Set(this._rawQueryData, "volume_percent", value); }
    }

    /// <summary>
    /// The id of the device this command is targeting. If not supplied, the user's
    /// currently active device is the target.
    /// </summary>
    public string? DeviceID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "device_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "device_id", value);
        }
    }

    public PlayerSetVolumeParams() { }

    public PlayerSetVolumeParams(PlayerSetVolumeParams playerSetVolumeParams)
        : base(playerSetVolumeParams) { }

    public PlayerSetVolumeParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerSetVolumeParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PlayerSetVolumeParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/me/player/volume")
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
