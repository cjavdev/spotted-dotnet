using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Albums;

/// <summary>
/// Get Spotify catalog information for multiple albums identified by their Spotify
/// IDs.
/// </summary>
public sealed record class AlbumBulkRetrieveParams : ParamsBase
{
    /// <summary>
    /// A comma-separated list of the [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids)
    /// for the albums. Maximum: 20 IDs.
    /// </summary>
    public required string IDs
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawQueryData, "ids"); }
        init { ModelBase.Set(this._rawQueryData, "ids", value); }
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
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "market"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "market", value);
        }
    }

    public AlbumBulkRetrieveParams() { }

    public AlbumBulkRetrieveParams(AlbumBulkRetrieveParams albumBulkRetrieveParams)
        : base(albumBulkRetrieveParams) { }

    public AlbumBulkRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumBulkRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static AlbumBulkRetrieveParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/albums")
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
