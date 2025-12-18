using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.AudioFeatures;

/// <summary>
/// Get audio features for multiple tracks based on their Spotify IDs.
/// </summary>
[Obsolete("deprecated")]
public sealed record class AudioFeatureBulkRetrieveParams : ParamsBase
{
    /// <summary>
    /// A comma-separated list of the [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids)
    /// for the tracks. Maximum: 100 IDs.
    /// </summary>
    public required string IDs
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawQueryData, "ids"); }
        init { JsonModel.Set(this._rawQueryData, "ids", value); }
    }

    public AudioFeatureBulkRetrieveParams() { }

    public AudioFeatureBulkRetrieveParams(
        AudioFeatureBulkRetrieveParams audioFeatureBulkRetrieveParams
    )
        : base(audioFeatureBulkRetrieveParams) { }

    public AudioFeatureBulkRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudioFeatureBulkRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static AudioFeatureBulkRetrieveParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/audio-features")
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
