using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Playlists.Tracks;

[JsonConverter(typeof(JsonModelConverter<TrackRemoveResponse, TrackRemoveResponseFromRaw>))]
public sealed record class TrackRemoveResponse : JsonModel
{
    public string? SnapshotID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "snapshot_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "snapshot_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SnapshotID;
    }

    public TrackRemoveResponse() { }

    public TrackRemoveResponse(TrackRemoveResponse trackRemoveResponse)
        : base(trackRemoveResponse) { }

    public TrackRemoveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackRemoveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackRemoveResponseFromRaw.FromRawUnchecked"/>
    public static TrackRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackRemoveResponseFromRaw : IFromRawJson<TrackRemoveResponse>
{
    /// <inheritdoc/>
    public TrackRemoveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrackRemoveResponse.FromRawUnchecked(rawData);
}
