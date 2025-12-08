using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

/// <summary>
/// Set the repeat mode for the user's playback. This API only works for users who
/// have Spotify Premium. The order of execution is not guaranteed when you use this
/// API with other Player API endpoints.
/// </summary>
public sealed record class PlayerSetRepeatModeParams : ParamsBase
{
    /// <summary>
    /// **track**, **context** or **off**.<br/> **track** will repeat the current
    /// track.<br/> **context** will repeat the current context.<br/> **off** will
    /// turn repeat off.
    /// </summary>
    public required string State
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawQueryData, "state"); }
        init { ModelBase.Set(this._rawQueryData, "state", value); }
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

    public PlayerSetRepeatModeParams() { }

    public PlayerSetRepeatModeParams(PlayerSetRepeatModeParams playerSetRepeatModeParams)
        : base(playerSetRepeatModeParams) { }

    public PlayerSetRepeatModeParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerSetRepeatModeParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static PlayerSetRepeatModeParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/me/player/repeat")
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
