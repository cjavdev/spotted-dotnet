using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Albums;

[JsonConverter(
    typeof(JsonModelConverter<AlbumListTracksPageResponse, AlbumListTracksPageResponseFromRaw>)
)]
public sealed record class AlbumListTracksPageResponse : JsonModel
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

    public IReadOnlyList<SimplifiedTrackObject>? Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimplifiedTrackObject>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<SimplifiedTrackObject>?>(
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

    public AlbumListTracksPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlbumListTracksPageResponse(AlbumListTracksPageResponse albumListTracksPageResponse)
        : base(albumListTracksPageResponse) { }
#pragma warning restore CS8618

    public AlbumListTracksPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumListTracksPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumListTracksPageResponseFromRaw.FromRawUnchecked"/>
    public static AlbumListTracksPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumListTracksPageResponseFromRaw : IFromRawJson<AlbumListTracksPageResponse>
{
    /// <inheritdoc/>
    public AlbumListTracksPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AlbumListTracksPageResponse.FromRawUnchecked(rawData);
}
