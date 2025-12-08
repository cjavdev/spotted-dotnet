using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Playlists.Tracks;

/// <summary>
/// Get full details of the items of a playlist owned by a Spotify user.
/// </summary>
public sealed record class TrackListParams : ParamsBase
{
    public string? PlaylistID { get; init; }

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
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "additional_types"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "additional_types", value);
        }
    }

    /// <summary>
    /// Filters for the query: a comma-separated list of the fields to return. If
    /// omitted, all fields are returned. For example, to get just the total number
    /// of items and the request limit:<br/>`fields=total,limit`<br/>A dot separator
    /// can be used to specify non-reoccurring fields, while parentheses can be used
    /// to specify reoccurring fields within objects. For example, to get just the
    /// added date and user ID of the adder:<br/>`fields=items(added_at,added_by.id)`<br/>Use
    /// multiple parentheses to drill down into nested objects, for example:<br/>`fields=items(track(name,href,album(name,href)))`<br/>Fields
    /// can be excluded by prefixing them with an exclamation mark, for example:<br/>`fields=items.track.album(!external_urls,images)`
    /// </summary>
    public string? Fields
    {
        get { return ModelBase.GetNullableClass<string>(this.RawQueryData, "fields"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "fields", value);
        }
    }

    /// <summary>
    /// The maximum number of items to return. Default: 20. Minimum: 1. Maximum:
    /// 100.
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

    /// <summary>
    /// The index of the first item to return. Default: 0 (the first item). Use with
    /// limit to get the next set of items.
    /// </summary>
    public long? Offset
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawQueryData, "offset"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawQueryData, "offset", value);
        }
    }

    public TrackListParams() { }

    public TrackListParams(TrackListParams trackListParams)
        : base(trackListParams) { }

    public TrackListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static TrackListParams FromRawUnchecked(
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
                + string.Format("/playlists/{0}/tracks", this.PlaylistID)
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
