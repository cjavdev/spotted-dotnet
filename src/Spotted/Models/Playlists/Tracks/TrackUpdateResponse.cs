using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Playlists.Tracks;

[JsonConverter(typeof(JsonModelConverter<TrackUpdateResponse, TrackUpdateResponseFromRaw>))]
public sealed record class TrackUpdateResponse : JsonModel
{
    public string? SnapshotID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("snapshot_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("snapshot_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SnapshotID;
    }

    public TrackUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TrackUpdateResponse(TrackUpdateResponse trackUpdateResponse)
        : base(trackUpdateResponse) { }
#pragma warning restore CS8618

    public TrackUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackUpdateResponseFromRaw.FromRawUnchecked"/>
    public static TrackUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackUpdateResponseFromRaw : IFromRawJson<TrackUpdateResponse>
{
    /// <inheritdoc/>
    public TrackUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrackUpdateResponse.FromRawUnchecked(rawData);
}
