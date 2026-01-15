using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Top;

/// <summary>
/// Get the current user's top tracks based on calculated affinity.
/// </summary>
public sealed record class TopListTopTracksParams : ParamsBase
{
    /// <summary>
    /// The maximum number of items to return. Default: 20. Minimum: 1. Maximum:
    /// 50.
    /// </summary>
    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// The index of the first item to return. Default: 0 (the first item). Use with
    /// limit to get the next set of items.
    /// </summary>
    public long? Offset
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("offset");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("offset", value);
        }
    }

    /// <summary>
    /// Over what time frame the affinities are computed. Valid values: `long_term`
    /// (calculated from ~1 year of data and including all new data as it becomes
    /// available), `medium_term` (approximately last 6 months), `short_term` (approximately
    /// last 4 weeks). Default: `medium_term`
    /// </summary>
    public string? TimeRange
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("time_range");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("time_range", value);
        }
    }

    public TopListTopTracksParams() { }

    public TopListTopTracksParams(TopListTopTracksParams topListTopTracksParams)
        : base(topListTopTracksParams) { }

    public TopListTopTracksParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopListTopTracksParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static TopListTopTracksParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/me/top/tracks")
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
