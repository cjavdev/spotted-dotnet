using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using Audiobooks = Spotted.Models.Audiobooks;

namespace Spotted.Models.Me.Audiobooks;

[JsonConverter(typeof(JsonModelConverter<AudiobookListResponse, AudiobookListResponseFromRaw>))]
public sealed record class AudiobookListResponse : JsonModel
{
    /// <summary>
    /// The date and time the audiobook was saved Timestamps are returned in ISO 8601
    /// format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.
    /// If the time is imprecise (for example, the date/time of an album release),
    /// an additional field indicates the precision; see for example, release_date
    /// in an album object.
    /// </summary>
    public DateTimeOffset? AddedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("added_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("added_at", value);
        }
    }

    /// <summary>
    /// Information about the audiobook.
    /// </summary>
    public Audiobook? Audiobook
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Audiobook>("audiobook");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("audiobook", value);
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
        _ = this.AddedAt;
        this.Audiobook?.Validate();
        _ = this.Published;
    }

    public AudiobookListResponse() { }

    public AudiobookListResponse(AudiobookListResponse audiobookListResponse)
        : base(audiobookListResponse) { }

    public AudiobookListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudiobookListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudiobookListResponseFromRaw.FromRawUnchecked"/>
    public static AudiobookListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudiobookListResponseFromRaw : IFromRawJson<AudiobookListResponse>
{
    /// <inheritdoc/>
    public AudiobookListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudiobookListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the audiobook.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Audiobook, AudiobookFromRaw>))]
public sealed record class Audiobook : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// audiobook.
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
    /// The author(s) for the audiobook.
    /// </summary>
    public required IReadOnlyList<AuthorObject> Authors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AuthorObject>>("authors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AuthorObject>>(
                "authors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A list of the countries in which the audiobook can be played, identified by
    /// their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code.
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
    /// The copyright statements of the audiobook.
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
    /// A description of the audiobook. HTML tags are stripped away from this field,
    /// use `html_description` field in case HTML tags are needed.
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
    /// Whether or not the audiobook has explicit content (true = yes it does; false
    /// = no it does not OR unknown).
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
    /// A link to the Web API endpoint providing full details of the audiobook.
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
    /// A description of the audiobook. This field may contain HTML tags.
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
    /// The cover art for the audiobook in various sizes, widest first.
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
    /// A list of the languages used in the audiobook, identified by their [ISO 639](https://en.wikipedia.org/wiki/ISO_639)
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
    /// The media type of the audiobook.
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
    /// The name of the audiobook.
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
    /// The narrator(s) for the audiobook.
    /// </summary>
    public required IReadOnlyList<NarratorObject> Narrators
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<NarratorObject>>("narrators");
        }
        init
        {
            this._rawData.Set<ImmutableArray<NarratorObject>>(
                "narrators",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The publisher of the audiobook.
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
    /// The number of chapters in this audiobook.
    /// </summary>
    public required long TotalChapters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_chapters");
        }
        init { this._rawData.Set("total_chapters", value); }
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
    /// audiobook.
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
    /// The edition of the audiobook.
    /// </summary>
    public string? Edition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("edition");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("edition", value);
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

    /// <summary>
    /// The chapters of the audiobook.
    /// </summary>
    public required IntersectionMember1Chapters Chapters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntersectionMember1Chapters>("chapters");
        }
        init { this._rawData.Set("chapters", value); }
    }

    public static implicit operator AudiobookBase(Audiobook audiobook) =>
        new()
        {
            ID = audiobook.ID,
            Authors = audiobook.Authors,
            AvailableMarkets = audiobook.AvailableMarkets,
            Copyrights = audiobook.Copyrights,
            Description = audiobook.Description,
            Explicit = audiobook.Explicit,
            ExternalUrls = audiobook.ExternalUrls,
            Href = audiobook.Href,
            HtmlDescription = audiobook.HtmlDescription,
            Images = audiobook.Images,
            Languages = audiobook.Languages,
            MediaType = audiobook.MediaType,
            Name = audiobook.Name,
            Narrators = audiobook.Narrators,
            Publisher = audiobook.Publisher,
            TotalChapters = audiobook.TotalChapters,
            Type = audiobook.Type,
            Uri = audiobook.Uri,
            Edition = audiobook.Edition,
            Published = audiobook.Published,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.Authors)
        {
            item.Validate();
        }
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
        _ = this.Languages;
        _ = this.MediaType;
        _ = this.Name;
        foreach (var item in this.Narrators)
        {
            item.Validate();
        }
        _ = this.Publisher;
        _ = this.TotalChapters;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("audiobook")))
        {
            throw new SpottedInvalidDataException("Invalid value given for constant");
        }
        _ = this.Uri;
        _ = this.Edition;
        _ = this.Published;
        this.Chapters.Validate();
    }

    public Audiobook()
    {
        this.Type = JsonSerializer.SerializeToElement("audiobook");
    }

    public Audiobook(Audiobook audiobook)
        : base(audiobook) { }

    public Audiobook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("audiobook");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Audiobook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudiobookFromRaw.FromRawUnchecked"/>
    public static Audiobook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudiobookFromRaw : IFromRawJson<Audiobook>
{
    /// <inheritdoc/>
    public Audiobook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Audiobook.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Spotted.Models.Me.Audiobooks.IntersectionMember1,
        global::Spotted.Models.Me.Audiobooks.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The chapters of the audiobook.
    /// </summary>
    public required IntersectionMember1Chapters Chapters
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntersectionMember1Chapters>("chapters");
        }
        init { this._rawData.Set("chapters", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Chapters.Validate();
    }

    public IntersectionMember1() { }

    public IntersectionMember1(
        global::Spotted.Models.Me.Audiobooks.IntersectionMember1 intersectionMember1
    )
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

    /// <inheritdoc cref="global::Spotted.Models.Me.Audiobooks.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Me.Audiobooks.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1Chapters chapters)
        : this()
    {
        this.Chapters = chapters;
    }
}

class IntersectionMember1FromRaw
    : IFromRawJson<global::Spotted.Models.Me.Audiobooks.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Me.Audiobooks.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Me.Audiobooks.IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The chapters of the audiobook.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<IntersectionMember1Chapters, IntersectionMember1ChaptersFromRaw>)
)]
public sealed record class IntersectionMember1Chapters : JsonModel
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

    public IReadOnlyList<Audiobooks::SimplifiedChapterObject>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<Audiobooks::SimplifiedChapterObject>
            >("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Audiobooks::SimplifiedChapterObject>?>(
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

    public IntersectionMember1Chapters() { }

    public IntersectionMember1Chapters(IntersectionMember1Chapters intersectionMember1Chapters)
        : base(intersectionMember1Chapters) { }

    public IntersectionMember1Chapters(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1Chapters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1ChaptersFromRaw.FromRawUnchecked"/>
    public static IntersectionMember1Chapters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1ChaptersFromRaw : IFromRawJson<IntersectionMember1Chapters>
{
    /// <inheritdoc/>
    public IntersectionMember1Chapters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntersectionMember1Chapters.FromRawUnchecked(rawData);
}
