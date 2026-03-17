using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Artists;

/// <summary>
/// Get Spotify catalog information about an artist's albums.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ArtistListAlbumsParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// A comma-separated list of keywords that will be used to filter the response.
    /// If not supplied, all album types will be returned. &lt;br/&gt; Valid values
    /// are:&lt;br/&gt;- `album`&lt;br/&gt;- `single`&lt;br/&gt;- `appears_on`&lt;br/&gt;-
    /// `compilation`&lt;br/&gt;For example: `include_groups=album,single`.
    /// </summary>
    public string? IncludeGroups
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("include_groups");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("include_groups", value);
        }
    }

    /// <summary>
    /// The maximum number of items to return. Default: 5. Minimum: 1. Maximum: 10.
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
    /// An [ISO 3166-1 alpha-2 country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2).
    ///   If a country code is specified, only content that is available in that market
    /// will be returned.&lt;br/&gt;   If a valid user access token is specified in
    /// the request header, the country associated with   the user account will take
    /// priority over this parameter.&lt;br/&gt;   _**Note**: If neither market or
    /// user country are provided, the content is considered unavailable for the
    /// client._&lt;br/&gt;   Users can view the country that is associated with
    /// their account in the [account settings](https://www.spotify.com/account/overview/).
    /// </summary>
    public string? Market
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("market");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("market", value);
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

    public ArtistListAlbumsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtistListAlbumsParams(ArtistListAlbumsParams artistListAlbumsParams)
        : base(artistListAlbumsParams)
    {
        this.ID = artistListAlbumsParams.ID;
    }
#pragma warning restore CS8618

    public ArtistListAlbumsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtistListAlbumsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ArtistListAlbumsParams FromRawUnchecked(
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
                    ["ID"] = JsonSerializer.SerializeToElement(this.ID),
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

    public virtual bool Equals(ArtistListAlbumsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/artists/{0}/albums", this.ID)
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
