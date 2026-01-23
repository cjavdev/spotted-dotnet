using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

/// <summary>
/// Toggle shuffle on or off for user’s playback. This API only works for users who
/// have Spotify Premium. The order of execution is not guaranteed when you use this
/// API with other Player API endpoints.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlayerToggleShuffleParams : ParamsBase
{
    /// <summary>
    /// **true** : Shuffle user's playback.<br/> **false** : Do not shuffle user's
    /// playback.
    /// </summary>
    public required bool State
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<bool>("state");
        }
        init { this._rawQueryData.Set("state", value); }
    }

    /// <summary>
    /// The id of the device this command is targeting. If not supplied, the user's
    /// currently active device is the target.
    /// </summary>
    public string? DeviceID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("device_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("device_id", value);
        }
    }

    public PlayerToggleShuffleParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlayerToggleShuffleParams(PlayerToggleShuffleParams playerToggleShuffleParams)
        : base(playerToggleShuffleParams) { }
#pragma warning restore CS8618

    public PlayerToggleShuffleParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerToggleShuffleParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PlayerToggleShuffleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PlayerToggleShuffleParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/me/player/shuffle")
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

    public override int GetHashCode()
    {
        return 0;
    }
}
