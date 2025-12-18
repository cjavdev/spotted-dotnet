using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Top;

[JsonConverter(
    typeof(JsonModelConverter<TopListTopTracksPageResponse, TopListTopTracksPageResponseFromRaw>)
)]
public sealed record class TopListTopTracksPageResponse : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init { JsonModel.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { JsonModel.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "previous"); }
        init { JsonModel.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<TrackObject>? Items
    {
        get { return JsonModel.GetNullableClass<List<TrackObject>>(this.RawData, "items"); }
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

    public TopListTopTracksPageResponse() { }

    public TopListTopTracksPageResponse(TopListTopTracksPageResponse topListTopTracksPageResponse)
        : base(topListTopTracksPageResponse) { }

    public TopListTopTracksPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TopListTopTracksPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TopListTopTracksPageResponseFromRaw.FromRawUnchecked"/>
    public static TopListTopTracksPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TopListTopTracksPageResponseFromRaw : IFromRawJson<TopListTopTracksPageResponse>
{
    /// <inheritdoc/>
    public TopListTopTracksPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TopListTopTracksPageResponse.FromRawUnchecked(rawData);
}
