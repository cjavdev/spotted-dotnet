using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Browse.Categories;

/// <summary>
/// Get a single category used to tag items in Spotify (on, for example, the Spotify
/// player’s “Browse” tab).
/// </summary>
public sealed record class CategoryRetrieveParams : ParamsBase
{
    public string? CategoryID { get; init; }

    /// <summary>
    /// The desired language, consisting of an [ISO 639-1](http://en.wikipedia.org/wiki/ISO_639-1)
    /// language code and an [ISO 3166-1 alpha-2 country code](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2),
    /// joined by an underscore. For example: `es_MX`, meaning &quot;Spanish (Mexico)&quot;.
    /// Provide this parameter if you want the category strings returned in a particular
    /// language.<br/> _**Note**: if `locale` is not supplied, or if the specified
    /// language is not available, the category strings returned will be in the Spotify
    /// default language (American English)._
    /// </summary>
    public string? Locale
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "locale"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "locale", value);
        }
    }

    public CategoryRetrieveParams() { }

    public CategoryRetrieveParams(CategoryRetrieveParams categoryRetrieveParams)
        : base(categoryRetrieveParams) { }

    public CategoryRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static CategoryRetrieveParams FromRawUnchecked(
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
                + string.Format("/browse/categories/{0}", this.CategoryID)
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
