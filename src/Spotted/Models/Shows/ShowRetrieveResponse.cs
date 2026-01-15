using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;

namespace Spotted.Models.Shows;

[JsonConverter(typeof(JsonModelConverter<ShowRetrieveResponse, ShowRetrieveResponseFromRaw>))]
public sealed record class ShowRetrieveResponse : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// show.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// A list of the countries in which the show can be played, identified by their
    /// [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) code.
    /// </summary>
    public required IReadOnlyList<string> AvailableMarkets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("available_markets");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "available_markets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The copyright statements of the show.
    /// </summary>
    public required IReadOnlyList<CopyrightObject> Copyrights
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CopyrightObject>>("copyrights");
        }
        init
        {
            this._rawData.Set<ImmutableArray<CopyrightObject>>(
                "copyrights",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A description of the show. HTML tags are stripped away from this field, use
    /// `html_description` field in case HTML tags are needed.
    /// </summary>
    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Whether or not the show has explicit content (true = yes it does; false =
    /// no it does not OR unknown).
    /// </summary>
    public required bool Explicit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("explicit");
        }
        init { this._rawData.Set("explicit", value); }
    }

    public required ExternalUrlObject ExternalUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ExternalUrlObject>("external_urls");
        }
        init { this._rawData.Set("external_urls", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the show.
    /// </summary>
    public required string Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// A description of the show. This field may contain HTML tags.
    /// </summary>
    public required string HtmlDescription
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("html_description");
        }
        init { this._rawData.Set("html_description", value); }
    }

    /// <summary>
    /// The cover art for the show in various sizes, widest first.
    /// </summary>
    public required IReadOnlyList<ImageObject> Images
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ImageObject>>("images");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImageObject>>(
                "images",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// True if all of the shows episodes are hosted outside of Spotify's CDN. This
    /// field might be `null` in some cases.
    /// </summary>
    public required bool IsExternallyHosted
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("is_externally_hosted");
        }
        init { this._rawData.Set("is_externally_hosted", value); }
    }

    /// <summary>
    /// A list of the languages used in the show, identified by their [ISO 639](https://en.wikipedia.org/wiki/ISO_639)
    /// code.
    /// </summary>
    public required IReadOnlyList<string> Languages
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("languages");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "languages",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The media type of the show.
    /// </summary>
    public required string MediaType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("media_type");
        }
        init { this._rawData.Set("media_type", value); }
    }

    /// <summary>
    /// The name of the episode.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The publisher of the show.
    /// </summary>
    public required string Publisher
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("publisher");
        }
        init { this._rawData.Set("publisher", value); }
    }

    /// <summary>
    /// The total number of episodes in the show.
    /// </summary>
    public required long TotalEpisodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_episodes");
        }
        init { this._rawData.Set("total_episodes", value); }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// show.
    /// </summary>
    public required string Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("uri");
        }
        init { this._rawData.Set("uri", value); }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <summary>
    /// The episodes of the show.
    /// </summary>
    public required IntersectionMember1Episodes Episodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntersectionMember1Episodes>("episodes");
        }
        init { this._rawData.Set("episodes", value); }
    }

    public static implicit operator ShowBase(ShowRetrieveResponse showRetrieveResponse) =>
        new()
        {
            ID = showRetrieveResponse.ID,
            AvailableMarkets = showRetrieveResponse.AvailableMarkets,
            Copyrights = showRetrieveResponse.Copyrights,
            Description = showRetrieveResponse.Description,
            Explicit = showRetrieveResponse.Explicit,
            ExternalUrls = showRetrieveResponse.ExternalUrls,
            Href = showRetrieveResponse.Href,
            HtmlDescription = showRetrieveResponse.HtmlDescription,
            Images = showRetrieveResponse.Images,
            IsExternallyHosted = showRetrieveResponse.IsExternallyHosted,
            Languages = showRetrieveResponse.Languages,
            MediaType = showRetrieveResponse.MediaType,
            Name = showRetrieveResponse.Name,
            Publisher = showRetrieveResponse.Publisher,
            TotalEpisodes = showRetrieveResponse.TotalEpisodes,
            Type = showRetrieveResponse.Type,
            Uri = showRetrieveResponse.Uri,
            Published = showRetrieveResponse.Published,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AvailableMarkets;
        foreach (var item in this.Copyrights)
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.Explicit;
        this.ExternalUrls.Validate();
        _ = this.Href;
        _ = this.HtmlDescription;
        foreach (var item in this.Images)
        {
            item.Validate();
        }
        _ = this.IsExternallyHosted;
        _ = this.Languages;
        _ = this.MediaType;
        _ = this.Name;
        _ = this.Publisher;
        _ = this.TotalEpisodes;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("show")))
        {
            throw new SpottedInvalidDataException("Invalid value given for constant");
        }
        _ = this.Uri;
        _ = this.Published;
        this.Episodes.Validate();
    }

    public ShowRetrieveResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("show");
    }

    public ShowRetrieveResponse(ShowRetrieveResponse showRetrieveResponse)
        : base(showRetrieveResponse) { }

    public ShowRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("show");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShowRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShowRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ShowRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShowRetrieveResponseFromRaw : IFromRawJson<ShowRetrieveResponse>
{
    /// <inheritdoc/>
    public ShowRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShowRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Spotted.Models.Shows.IntersectionMember1,
        global::Spotted.Models.Shows.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The episodes of the show.
    /// </summary>
    public required IntersectionMember1Episodes Episodes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntersectionMember1Episodes>("episodes");
        }
        init { this._rawData.Set("episodes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Episodes.Validate();
    }

    public IntersectionMember1() { }

    public IntersectionMember1(global::Spotted.Models.Shows.IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Spotted.Models.Shows.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Shows.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1Episodes episodes)
        : this()
    {
        this.Episodes = episodes;
    }
}

class IntersectionMember1FromRaw : IFromRawJson<global::Spotted.Models.Shows.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Shows.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Shows.IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The episodes of the show.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IntersectionMember1Episodes, IntersectionMember1EpisodesFromRaw>)
)]
public sealed record class IntersectionMember1Episodes : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("limit");
        }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next");
        }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("offset");
        }
        init { this._rawData.Set("offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previous");
        }
        init { this._rawData.Set("previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    public IReadOnlyList<SimplifiedEpisodeObject>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimplifiedEpisodeObject>>(
                "items"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SimplifiedEpisodeObject>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public IntersectionMember1Episodes() { }

    public IntersectionMember1Episodes(IntersectionMember1Episodes intersectionMember1Episodes)
        : base(intersectionMember1Episodes) { }

    public IntersectionMember1Episodes(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1Episodes(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1EpisodesFromRaw.FromRawUnchecked"/>
    public static IntersectionMember1Episodes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1EpisodesFromRaw : IFromRawJson<IntersectionMember1Episodes>
{
    /// <inheritdoc/>
    public IntersectionMember1Episodes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntersectionMember1Episodes.FromRawUnchecked(rawData);
}
