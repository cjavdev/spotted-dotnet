using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Following;

[JsonConverter(
    typeof(JsonModelConverter<FollowingBulkRetrieveResponse, FollowingBulkRetrieveResponseFromRaw>)
)]
public sealed record class FollowingBulkRetrieveResponse : JsonModel
{
    public required FollowingBulkRetrieveResponseArtists Artists
    {
        get
        {
            return this._rawData.GetNotNullClass<FollowingBulkRetrieveResponseArtists>("artists");
        }
        init { this._rawData.Set("artists", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Artists.Validate();
    }

    public FollowingBulkRetrieveResponse() { }

    public FollowingBulkRetrieveResponse(
        FollowingBulkRetrieveResponse followingBulkRetrieveResponse
    )
        : base(followingBulkRetrieveResponse) { }

    public FollowingBulkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowingBulkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowingBulkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static FollowingBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FollowingBulkRetrieveResponse(FollowingBulkRetrieveResponseArtists artists)
        : this()
    {
        this.Artists = artists;
    }
}

class FollowingBulkRetrieveResponseFromRaw : IFromRawJson<FollowingBulkRetrieveResponse>
{
    /// <inheritdoc/>
    public FollowingBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowingBulkRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        FollowingBulkRetrieveResponseArtists,
        FollowingBulkRetrieveResponseArtistsFromRaw
    >)
)]
public sealed record class FollowingBulkRetrieveResponseArtists : JsonModel
{
    /// <summary>
    /// The cursors used to find the next set of items.
    /// </summary>
    public Cursors? Cursors
    {
        get { return this._rawData.GetNullableClass<Cursors>("cursors"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("cursors", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request.
    /// </summary>
    public string? Href
    {
        get { return this._rawData.GetNullableClass<string>("href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("href", value);
        }
    }

    public IReadOnlyList<ArtistObject>? Items
    {
        get { return this._rawData.GetNullableStruct<ImmutableArray<ArtistObject>>("items"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ArtistObject>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public long? Limit
    {
        get { return this._rawData.GetNullableStruct<long>("limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("limit", value);
        }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public string? Next
    {
        get { return this._rawData.GetNullableClass<string>("next"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("next", value);
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
        get { return this._rawData.GetNullableStruct<bool>("published"); }
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
    /// The total number of items available to return.
    /// </summary>
    public long? Total
    {
        get { return this._rawData.GetNullableStruct<long>("total"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cursors?.Validate();
        _ = this.Href;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Limit;
        _ = this.Next;
        _ = this.Published;
        _ = this.Total;
    }

    public FollowingBulkRetrieveResponseArtists() { }

    public FollowingBulkRetrieveResponseArtists(
        FollowingBulkRetrieveResponseArtists followingBulkRetrieveResponseArtists
    )
        : base(followingBulkRetrieveResponseArtists) { }

    public FollowingBulkRetrieveResponseArtists(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowingBulkRetrieveResponseArtists(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowingBulkRetrieveResponseArtistsFromRaw.FromRawUnchecked"/>
    public static FollowingBulkRetrieveResponseArtists FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowingBulkRetrieveResponseArtistsFromRaw
    : IFromRawJson<FollowingBulkRetrieveResponseArtists>
{
    /// <inheritdoc/>
    public FollowingBulkRetrieveResponseArtists FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FollowingBulkRetrieveResponseArtists.FromRawUnchecked(rawData);
}

/// <summary>
/// The cursors used to find the next set of items.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cursors, CursorsFromRaw>))]
public sealed record class Cursors : JsonModel
{
    /// <summary>
    /// The cursor to use as key to find the next page of items.
    /// </summary>
    public string? After
    {
        get { return this._rawData.GetNullableClass<string>("after"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("after", value);
        }
    }

    /// <summary>
    /// The cursor to use as key to find the previous page of items.
    /// </summary>
    public string? Before
    {
        get { return this._rawData.GetNullableClass<string>("before"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("before", value);
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
        get { return this._rawData.GetNullableStruct<bool>("published"); }
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
        _ = this.After;
        _ = this.Before;
        _ = this.Published;
    }

    public Cursors() { }

    public Cursors(Cursors cursors)
        : base(cursors) { }

    public Cursors(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cursors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CursorsFromRaw.FromRawUnchecked"/>
    public static Cursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CursorsFromRaw : IFromRawJson<Cursors>
{
    /// <inheritdoc/>
    public Cursors FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Cursors.FromRawUnchecked(rawData);
}
