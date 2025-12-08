using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Tracks;

[JsonConverter(typeof(ModelConverter<TrackBulkRetrieveResponse, TrackBulkRetrieveResponseFromRaw>))]
public sealed record class TrackBulkRetrieveResponse : ModelBase
{
    public required IReadOnlyList<TrackObject> Tracks
    {
        get { return ModelBase.GetNotNullClass<List<TrackObject>>(this.RawData, "tracks"); }
        init { ModelBase.Set(this._rawData, "tracks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tracks)
        {
            item.Validate();
        }
    }

    public TrackBulkRetrieveResponse() { }

    public TrackBulkRetrieveResponse(TrackBulkRetrieveResponse trackBulkRetrieveResponse)
        : base(trackBulkRetrieveResponse) { }

    public TrackBulkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackBulkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TrackBulkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TrackBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public TrackBulkRetrieveResponse(List<TrackObject> tracks)
        : this()
    {
        this.Tracks = tracks;
    }
}

class TrackBulkRetrieveResponseFromRaw : IFromRaw<TrackBulkRetrieveResponse>
{
    /// <inheritdoc/>
    public TrackBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TrackBulkRetrieveResponse.FromRawUnchecked(rawData);
}
