using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Tracks;

/// <summary>
/// Save one or more tracks to the current user's 'Your Music' library.
///
/// <para>**Note:** This endpoint is deprecated. Use [Save Items to Library](/documentation/web-api/reference/save-library-items) instead.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
[Obsolete("deprecated")]
public record class TrackSaveParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
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
    public required IReadOnlyList<string> Ids
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>("ids");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "ids",
                ImmutableArray.ToImmutableArray(value)
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
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("published");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("published", value);
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
    public IReadOnlyList<TimestampedID>? TimestampedIds
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<TimestampedID>>(
                "timestamped_ids"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<TimestampedID>?>(
                "timestamped_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public TrackSaveParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrackSaveParams(TrackSaveParams trackSaveParams)
        : base(trackSaveParams)
    {
        this._rawBodyData = new(trackSaveParams._rawBodyData);
    }
#pragma warning restore CS8618

    public TrackSaveParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackSaveParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
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

    public override string ToString() =>
        JsonSerializer.Serialize(
            new Dictionary<string, object?>()
            {
                ["HeaderData"] = this._rawHeaderData.Freeze(),
                ["QueryData"] = this._rawQueryData.Freeze(),
                ["BodyData"] = this._rawBodyData.Freeze(),
            },
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(TrackSaveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
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
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
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

    public override int GetHashCode()
    {
        return 0;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("added_at");
        }
        init { this._rawData.Set("added_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AddedAt;
    }

    public TimestampedID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TimestampedID(TimestampedID timestampedID)
        : base(timestampedID) { }
#pragma warning restore CS8618

    public TimestampedID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TimestampedID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
