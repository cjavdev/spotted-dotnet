using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using Audiobooks = Spotted.Models.Audiobooks;

namespace Spotted.Models.Me.Audiobooks;

[JsonConverter(typeof(ModelConverter<AudiobookListPageResponse, AudiobookListPageResponseFromRaw>))]
public sealed record class AudiobookListPageResponse : ModelBase
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { ModelBase.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "next"); }
        init { ModelBase.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { ModelBase.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "previous"); }
        init { ModelBase.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "total"); }
        init { ModelBase.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<Item>? Items
    {
        get { return ModelBase.GetNullableClass<List<Item>>(this.RawData, "items"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "items", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
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

    public AudiobookListPageResponse() { }

    public AudiobookListPageResponse(AudiobookListPageResponse audiobookListPageResponse)
        : base(audiobookListPageResponse) { }

    public AudiobookListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudiobookListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudiobookListPageResponseFromRaw.FromRawUnchecked"/>
    public static AudiobookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudiobookListPageResponseFromRaw : IFromRaw<AudiobookListPageResponse>
{
    /// <inheritdoc/>
    public AudiobookListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AudiobookListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : ModelBase
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
        get { return ModelBase.GetNullableStruct<DateTimeOffset>(this.RawData, "added_at"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "added_at", value);
        }
    }

    /// <summary>
    /// Information about the audiobook.
    /// </summary>
    public Audiobook? Audiobook
    {
        get { return ModelBase.GetNullableClass<Audiobook>(this.RawData, "audiobook"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "audiobook", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddedAt;
        this.Audiobook?.Validate();
        _ = this.Published;
    }

    public Item() { }

    public Item(Item item)
        : base(item) { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

/// <summary>
/// Information about the audiobook.
/// </summary>
[JsonConverter(typeof(ModelConverter<Audiobook, AudiobookFromRaw>))]
public sealed record class Audiobook : ModelBase
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// audiobook.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The author(s) for the audiobook.
    /// </summary>
    public required IReadOnlyList<AuthorObject> Authors
    {
        get { return ModelBase.GetNotNullClass<List<AuthorObject>>(this.RawData, "authors"); }
        init { ModelBase.Set(this._rawData, "authors", value); }
    }

    /// <summary>
    /// A list of the countries in which the audiobook can be played, identified by
    /// their [ISO 3166-1 alpha-2](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2)
    /// code.
    /// </summary>
    public required IReadOnlyList<string> AvailableMarkets
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "available_markets"); }
        init { ModelBase.Set(this._rawData, "available_markets", value); }
    }

    /// <summary>
    /// The copyright statements of the audiobook.
    /// </summary>
    public required IReadOnlyList<CopyrightObject> Copyrights
    {
        get { return ModelBase.GetNotNullClass<List<CopyrightObject>>(this.RawData, "copyrights"); }
        init { ModelBase.Set(this._rawData, "copyrights", value); }
    }

    /// <summary>
    /// A description of the audiobook. HTML tags are stripped away from this field,
    /// use `html_description` field in case HTML tags are needed.
    /// </summary>
    public required string Description
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "description"); }
        init { ModelBase.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Whether or not the audiobook has explicit content (true = yes it does; false
    /// = no it does not OR unknown).
    /// </summary>
    public required bool Explicit
    {
        get { return ModelBase.GetNotNullStruct<bool>(this.RawData, "explicit"); }
        init { ModelBase.Set(this._rawData, "explicit", value); }
    }

    public required ExternalURLObject ExternalURLs
    {
        get { return ModelBase.GetNotNullClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init { ModelBase.Set(this._rawData, "external_urls", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the audiobook.
    /// </summary>
    public required string Href
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// A description of the audiobook. This field may contain HTML tags.
    /// </summary>
    public required string HTMLDescription
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "html_description"); }
        init { ModelBase.Set(this._rawData, "html_description", value); }
    }

    /// <summary>
    /// The cover art for the audiobook in various sizes, widest first.
    /// </summary>
    public required IReadOnlyList<ImageObject> Images
    {
        get { return ModelBase.GetNotNullClass<List<ImageObject>>(this.RawData, "images"); }
        init { ModelBase.Set(this._rawData, "images", value); }
    }

    /// <summary>
    /// A list of the languages used in the audiobook, identified by their [ISO 639](https://en.wikipedia.org/wiki/ISO_639)
    /// code.
    /// </summary>
    public required IReadOnlyList<string> Languages
    {
        get { return ModelBase.GetNotNullClass<List<string>>(this.RawData, "languages"); }
        init { ModelBase.Set(this._rawData, "languages", value); }
    }

    /// <summary>
    /// The media type of the audiobook.
    /// </summary>
    public required string MediaType
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "media_type"); }
        init { ModelBase.Set(this._rawData, "media_type", value); }
    }

    /// <summary>
    /// The name of the audiobook.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The narrator(s) for the audiobook.
    /// </summary>
    public required IReadOnlyList<NarratorObject> Narrators
    {
        get { return ModelBase.GetNotNullClass<List<NarratorObject>>(this.RawData, "narrators"); }
        init { ModelBase.Set(this._rawData, "narrators", value); }
    }

    /// <summary>
    /// The publisher of the audiobook.
    /// </summary>
    public required string Publisher
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "publisher"); }
        init { ModelBase.Set(this._rawData, "publisher", value); }
    }

    /// <summary>
    /// The number of chapters in this audiobook.
    /// </summary>
    public required long TotalChapters
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "total_chapters"); }
        init { ModelBase.Set(this._rawData, "total_chapters", value); }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// audiobook.
    /// </summary>
    public required string Uri
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "uri"); }
        init { ModelBase.Set(this._rawData, "uri", value); }
    }

    /// <summary>
    /// The edition of the audiobook.
    /// </summary>
    public string? Edition
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "edition"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "edition", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// The chapters of the audiobook.
    /// </summary>
    public required IntersectionMember1Chapters Chapters
    {
        get
        {
            return ModelBase.GetNotNullClass<IntersectionMember1Chapters>(this.RawData, "chapters");
        }
        init { ModelBase.Set(this._rawData, "chapters", value); }
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
            ExternalURLs = audiobook.ExternalURLs,
            Href = audiobook.Href,
            HTMLDescription = audiobook.HTMLDescription,
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
        this.ExternalURLs.Validate();
        _ = this.Href;
        _ = this.HTMLDescription;
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"audiobook\"")
            )
        )
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
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"audiobook\"");
    }

    public Audiobook(Audiobook audiobook)
        : base(audiobook) { }

    public Audiobook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"audiobook\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Audiobook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AudiobookFromRaw.FromRawUnchecked"/>
    public static Audiobook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AudiobookFromRaw : IFromRaw<Audiobook>
{
    /// <inheritdoc/>
    public Audiobook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Audiobook.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Spotted.Models.Me.Audiobooks.IntersectionMember1,
        global::Spotted.Models.Me.Audiobooks.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : ModelBase
{
    /// <summary>
    /// The chapters of the audiobook.
    /// </summary>
    public required IntersectionMember1Chapters Chapters
    {
        get
        {
            return ModelBase.GetNotNullClass<IntersectionMember1Chapters>(this.RawData, "chapters");
        }
        init { ModelBase.Set(this._rawData, "chapters", value); }
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    : IFromRaw<global::Spotted.Models.Me.Audiobooks.IntersectionMember1>
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
    typeof(ModelConverter<IntersectionMember1Chapters, IntersectionMember1ChaptersFromRaw>)
)]
public sealed record class IntersectionMember1Chapters : ModelBase
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { ModelBase.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "next"); }
        init { ModelBase.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { ModelBase.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "previous"); }
        init { ModelBase.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "total"); }
        init { ModelBase.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<Audiobooks::SimplifiedChapterObject>? Items
    {
        get
        {
            return ModelBase.GetNullableClass<List<Audiobooks::SimplifiedChapterObject>>(
                this.RawData,
                "items"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "items", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1Chapters(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class IntersectionMember1ChaptersFromRaw : IFromRaw<IntersectionMember1Chapters>
{
    /// <inheritdoc/>
    public IntersectionMember1Chapters FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IntersectionMember1Chapters.FromRawUnchecked(rawData);
}
