using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Playlists.Tracks;

[JsonConverter(typeof(JsonModelConverter<TrackAddResponse, TrackAddResponseFromRaw>))]
public sealed record class TrackAddResponse : JsonModel
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

    public TrackAddResponse() { }

    public TrackAddResponse(TrackAddResponse trackAddResponse)
        : base(trackAddResponse) { }

    public TrackAddResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackAddResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackAddResponseFromRaw.FromRawUnchecked"/>
    public static TrackAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TrackAddResponseFromRaw : IFromRawJson<TrackAddResponse>
{
    /// <inheritdoc/>
    public TrackAddResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TrackAddResponse.FromRawUnchecked(rawData);
}
