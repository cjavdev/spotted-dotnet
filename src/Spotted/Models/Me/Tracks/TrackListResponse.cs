using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Tracks;

[JsonConverter(typeof(JsonModelConverter<TrackListResponse, TrackListResponseFromRaw>))]
public sealed record class TrackListResponse : JsonModel
{
    /// <summary>
    /// The date and time the track was saved. Timestamps are returned in ISO 8601
    /// format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.
    /// If the time is imprecise (for example, the date/time of an album release),
    /// an additional field indicates the precision; see for example, release_date
    /// in an album object.
    /// </summary>
    public DateTimeOffset? AddedAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "added_at"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "added_at", value);
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
    /// Information about the track.
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
        _ = this.AddedAt;
        _ = this.Published;
        this.Track?.Validate();
    }

    public TrackListResponse() { }

    public TrackListResponse(TrackListResponse trackListResponse)
        : base(trackListResponse) { }

    public TrackListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackListResponseFromRaw.FromRawUnchecked"/>
    public static TrackListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackListResponseFromRaw : IFromRawJson<TrackListResponse>
{
    /// <inheritdoc/>
    public TrackListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrackListResponse.FromRawUnchecked(rawData);
}
