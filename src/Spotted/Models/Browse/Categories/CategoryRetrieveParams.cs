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
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class CategoryRetrieveParams : ParamsBase
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
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("locale");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("locale", value);
        }
    }

    public CategoryRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CategoryRetrieveParams(CategoryRetrieveParams categoryRetrieveParams)
        : base(categoryRetrieveParams)
    {
        this.CategoryID = categoryRetrieveParams.CategoryID;
    }
#pragma warning restore CS8618

    public CategoryRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CategoryID"] = JsonSerializer.SerializeToElement(this.CategoryID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(CategoryRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CategoryID?.Equals(other.CategoryID) ?? other.CategoryID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
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

    public override int GetHashCode()
    {
        return 0;
    }
}
