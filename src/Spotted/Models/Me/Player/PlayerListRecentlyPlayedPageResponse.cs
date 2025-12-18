using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

[JsonConverter(
    typeof(JsonModelConverter<
        PlayerListRecentlyPlayedPageResponse,
        PlayerListRecentlyPlayedPageResponseFromRaw
    >)
)]
public sealed record class PlayerListRecentlyPlayedPageResponse : JsonModel
{
    /// <summary>
    /// The cursors used to find the next set of items.
    /// </summary>
    public Cursors? Cursors
    {
        get { return JsonModel.GetNullableClass<Cursors>(this.RawData, "cursors"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "cursors", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request.
    /// </summary>
    public string? Href
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "href", value);
        }
    }

    public IReadOnlyList<PlayerListRecentlyPlayedPageResponseItem>? Items
    {
        get
        {
            return JsonModel.GetNullableClass<List<PlayerListRecentlyPlayedPageResponseItem>>(
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

            JsonModel.Set(this._rawData, "items", value);
        }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public long? Limit
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "limit", value);
        }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "next", value);
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
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public long? Total
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawData, "total"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "total", value);
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

    public PlayerListRecentlyPlayedPageResponse() { }

    public PlayerListRecentlyPlayedPageResponse(
        PlayerListRecentlyPlayedPageResponse playerListRecentlyPlayedPageResponse
    )
        : base(playerListRecentlyPlayedPageResponse) { }

    public PlayerListRecentlyPlayedPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerListRecentlyPlayedPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlayerListRecentlyPlayedPageResponseFromRaw.FromRawUnchecked"/>
    public static PlayerListRecentlyPlayedPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlayerListRecentlyPlayedPageResponseFromRaw
    : IFromRawJson<PlayerListRecentlyPlayedPageResponse>
{
    /// <inheritdoc/>
    public PlayerListRecentlyPlayedPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlayerListRecentlyPlayedPageResponse.FromRawUnchecked(rawData);
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
        get { return JsonModel.GetNullableClass<string>(this.RawData, "after"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "after", value);
        }
    }

    /// <summary>
    /// The cursor to use as key to find the previous page of items.
    /// </summary>
    public string? Before
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "before"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "before", value);
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
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
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
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Cursors(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

[JsonConverter(
    typeof(JsonModelConverter<
        PlayerListRecentlyPlayedPageResponseItem,
        PlayerListRecentlyPlayedPageResponseItemFromRaw
    >)
)]
public sealed record class PlayerListRecentlyPlayedPageResponseItem : JsonModel
{
    /// <summary>
    /// The context the track was played from.
    /// </summary>
    public ContextObject? Context
    {
        get { return JsonModel.GetNullableClass<ContextObject>(this.RawData, "context"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "context", value);
        }
    }

    /// <summary>
    /// The date and time the track was played.
    /// </summary>
    public DateTimeOffset? PlayedAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "played_at"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "played_at", value);
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
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// The track the user listened to.
    /// </summary>
    public TrackObject? Track
    {
        get { return JsonModel.GetNullableClass<TrackObject>(this.RawData, "track"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "track", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Context?.Validate();
        _ = this.PlayedAt;
        _ = this.Published;
        this.Track?.Validate();
    }

    public PlayerListRecentlyPlayedPageResponseItem() { }

    public PlayerListRecentlyPlayedPageResponseItem(
        PlayerListRecentlyPlayedPageResponseItem playerListRecentlyPlayedPageResponseItem
    )
        : base(playerListRecentlyPlayedPageResponseItem) { }

    public PlayerListRecentlyPlayedPageResponseItem(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerListRecentlyPlayedPageResponseItem(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlayerListRecentlyPlayedPageResponseItemFromRaw.FromRawUnchecked"/>
    public static PlayerListRecentlyPlayedPageResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlayerListRecentlyPlayedPageResponseItemFromRaw
    : IFromRawJson<PlayerListRecentlyPlayedPageResponseItem>
{
    /// <inheritdoc/>
    public PlayerListRecentlyPlayedPageResponseItem FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlayerListRecentlyPlayedPageResponseItem.FromRawUnchecked(rawData);
}
