using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Me.Albums;

/// <summary>
/// Check if one or more albums is already saved in the current Spotify user's 'Your
/// Music' library.
/// </summary>
public sealed record class AlbumCheckParams : ParamsBase
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

    public AlbumCheckParams() { }

    public AlbumCheckParams(AlbumCheckParams albumCheckParams)
        : base(albumCheckParams) { }

    public AlbumCheckParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumCheckParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static AlbumCheckParams FromRawUnchecked(
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/me/albums/contains")
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
