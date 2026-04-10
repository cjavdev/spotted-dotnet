using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Playlists;

/// <summary>
/// Get a playlist owned by a Spotify user.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PlaylistRetrieveParams : ParamsBase
{
    public string? PlaylistID { get; init; }

    /// <summary>
    /// A comma-separated list of item types that your client supports besides the
    /// default `track` type. Valid types are: `track` and `episode`.&lt;br/&gt; _**Note**:
    /// This parameter was introduced to allow existing clients to maintain their
    /// current behaviour and might be deprecated in the future._&lt;br/&gt; In addition
    /// to providing this parameter, make sure that your client properly handles cases
    /// of new types in the future by checking against the `type` field of each object.
    /// </summary>
    public string? AdditionalTypes
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("additional_types");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("additional_types", value);
        }
    }

    /// <summary>
    /// Filters for the query: a comma-separated list of the fields to return. If
    /// omitted, all fields are returned. For example, to get just the playlist''s
    /// description and URI: `fields=description,uri`. A dot separator can be used
    /// to specify non-reoccurring fields, while parentheses can be used to specify
    /// reoccurring fields within objects. For example, to get just the added date
    /// and user ID of the adder: `fields=tracks.items(added_at,added_by.id)`. Use
    /// multiple parentheses to drill down into nested objects, for example: `fields=tracks.items(track(name,href,album(name,href)))`.
    /// Fields can be excluded by prefixing them with an exclamation mark, for example:
    /// `fields=tracks.items(track(name,href,album(!name,href)))`
    /// </summary>
    public string? Fields
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("fields");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("fields", value);
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

    public PlaylistRetrieveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlaylistRetrieveParams(PlaylistRetrieveParams playlistRetrieveParams)
        : base(playlistRetrieveParams)
    {
        this.PlaylistID = playlistRetrieveParams.PlaylistID;
    }
#pragma warning restore CS8618

    public PlaylistRetrieveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistRetrieveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string playlistID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PlaylistID = playlistID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PlaylistRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string playlistID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            playlistID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["PlaylistID"] = JsonSerializer.SerializeToElement(this.PlaylistID),
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

    public virtual bool Equals(PlaylistRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PlaylistID?.Equals(other.PlaylistID) ?? other.PlaylistID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/playlists/{0}", this.PlaylistID)
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
