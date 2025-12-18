using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Audiobooks;

/// <summary>
/// Get Spotify catalog information about an audiobook's chapters. Audiobooks are
/// only available within the US, UK, Canada, Ireland, New Zealand and Australia
/// markets.
/// </summary>
public sealed record class AudiobookListChaptersParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// The maximum number of items to return. Default: 20. Minimum: 1. Maximum:
    /// 50.
    /// </summary>
    public long? Limit
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "limit", value);
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

    /// <summary>
    /// The index of the first item to return. Default: 0 (the first item). Use with
    /// limit to get the next set of items.
    /// </summary>
    public long? Offset
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "offset"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "offset", value);
        }
    }

    public AudiobookListChaptersParams() { }

    public AudiobookListChaptersParams(AudiobookListChaptersParams audiobookListChaptersParams)
        : base(audiobookListChaptersParams) { }

    public AudiobookListChaptersParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudiobookListChaptersParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static AudiobookListChaptersParams FromRawUnchecked(
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
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/audiobooks/{0}/chapters", this.ID)
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
