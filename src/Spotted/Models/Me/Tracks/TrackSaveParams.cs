using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Tracks;

/// <summary>
/// Save one or more tracks to the current user's 'Your Music' library.
/// </summary>
public sealed record class TrackSaveParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// A JSON array of the [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids).
    /// For example: `["4iV5W9uYEdYUVa79Axb7Rh", "1301WleyT98MSxVHPZCA6M"]`<br/>A
    /// maximum of 50 items can be specified in one request. _**Note**: if the `timestamped_ids`
    /// is present in the body, any IDs listed in the query parameters (deprecated)
    /// or the `ids` field in the body will be ignored._
    /// </summary>
    public required IReadOnlyList<string> IDs
    {
        get { return JsonModel.GetNotNullClass<List<string>>(this.RawBodyData, "ids"); }
        init { JsonModel.Set(this._rawBodyData, "ids", value); }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "published", value);
        }
    }

    /// <summary>
    /// A JSON array of objects containing track IDs with their corresponding timestamps.
    /// Each object must include a track ID and an `added_at` timestamp. This allows
    /// you to specify when tracks were added to maintain a specific chronological
    /// order in the user's library.<br/>A maximum of 50 items can be specified in
    /// one request. _**Note**: if the `timestamped_ids` is present in the body, any
    /// IDs listed in the query parameters (deprecated) or the `ids` field in the
    /// body will be ignored._
    /// </summary>
    public IReadOnlyList<TimestampedID>? TimestampedIDs
    {
        get
        {
            return JsonModel.GetNullableClass<List<TimestampedID>>(
                this.RawBodyData,
                "timestamped_ids"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "timestamped_ids", value);
        }
    }

    public TrackSaveParams() { }

    public TrackSaveParams(TrackSaveParams trackSaveParams)
        : base(trackSaveParams)
    {
        this._rawBodyData = [.. trackSaveParams._rawBodyData];
    }

    public TrackSaveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackSaveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static TrackSaveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/me/tracks")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(JsonModelConverter<TimestampedID, TimestampedIDFromRaw>))]
public sealed record class TimestampedID : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// track.
    /// </summary>
    public required string ID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// The timestamp when the track was added to the library. Use ISO 8601 format
    /// with UTC timezone (e.g., `2023-01-15T14:30:00Z`). You can specify past timestamps
    /// to insert tracks at specific positions in the library's chronological order.
    /// The API uses minute-level granularity for ordering, though the timestamp supports
    /// millisecond precision.
    /// </summary>
    public required DateTimeOffset AddedAt
    {
        get { return JsonModel.GetNotNullStruct<DateTimeOffset>(this.RawData, "added_at"); }
        init { JsonModel.Set(this._rawData, "added_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AddedAt;
    }

    public TimestampedID() { }

    public TimestampedID(TimestampedID timestampedID)
        : base(timestampedID) { }

    public TimestampedID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimestampedID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TimestampedIDFromRaw.FromRawUnchecked"/>
    public static TimestampedID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TimestampedIDFromRaw : IFromRawJson<TimestampedID>
{
    /// <inheritdoc/>
    public TimestampedID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TimestampedID.FromRawUnchecked(rawData);
}
