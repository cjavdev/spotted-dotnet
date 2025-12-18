using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

/// <summary>
/// Get the object currently being played on the user's Spotify account.
/// </summary>
public sealed record class PlayerGetCurrentlyPlayingParams : ParamsBase
{
    /// <summary>
    /// A comma-separated list of item types that your client supports besides the
    /// default `track` type. Valid types are: `track` and `episode`.<br/> _**Note**:
    /// This parameter was introduced to allow existing clients to maintain their
    /// current behaviour and might be deprecated in the future._<br/> In addition
    /// to providing this parameter, make sure that your client properly handles cases
    /// of new types in the future by checking against the `type` field of each object.
    /// </summary>
    public string? AdditionalTypes
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "additional_types"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "additional_types", value);
        }
    }

    /// <summary>
    /// An [ISO 3166-1 alpha-2 country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2).
    ///   If a country code is specified, only content that is available in that market
    /// will be returned.<br/>   If a valid user access token is specified in the
    /// request header, the country associated with   the user account will take
    /// priority over this parameter.<br/>   _**Note**: If neither market or user
    /// country are provided, the content is considered unavailable for the client._<br/>
    ///   Users can view the country that is associated with their account in the
    /// [account settings](https://www.spotify.com/account/overview/).
    /// </summary>
    public string? Market
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "market"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "market", value);
        }
    }

    public PlayerGetCurrentlyPlayingParams() { }

    public PlayerGetCurrentlyPlayingParams(
        PlayerGetCurrentlyPlayingParams playerGetCurrentlyPlayingParams
    )
        : base(playerGetCurrentlyPlayingParams) { }

    public PlayerGetCurrentlyPlayingParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerGetCurrentlyPlayingParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static PlayerGetCurrentlyPlayingParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/') + "/me/player/currently-playing"
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
