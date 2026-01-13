using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Playlists.Followers;

/// <summary>
/// Check to see if the current user is following a specified playlist.
/// </summary>
public sealed record class FollowerCheckParams : ParamsBase
{
    public string? PlaylistID { get; init; }

    /// <summary>
    /// **Deprecated** A single item list containing current user's [Spotify Username](/documentation/web-api/concepts/spotify-uris-ids).
    /// Maximum: 1 id.
    /// </summary>
    public string? Ids
    {
        get { return this._rawQueryData.GetNullableClass<string>("ids"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("ids", value);
        }
    }

    public FollowerCheckParams() { }

    public FollowerCheckParams(FollowerCheckParams followerCheckParams)
        : base(followerCheckParams)
    {
        this.PlaylistID = followerCheckParams.PlaylistID;
    }

    public FollowerCheckParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowerCheckParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static FollowerCheckParams FromRawUnchecked(
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
                + string.Format("/playlists/{0}/followers/contains", this.PlaylistID)
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
