using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Episodes;

[JsonConverter(
    typeof(ModelConverter<EpisodeBulkRetrieveResponse, EpisodeBulkRetrieveResponseFromRaw>)
)]
public sealed record class EpisodeBulkRetrieveResponse : ModelBase
{
    public required IReadOnlyList<EpisodeObject> Episodes
    {
        get { return ModelBase.GetNotNullClass<List<EpisodeObject>>(this.RawData, "episodes"); }
        init { ModelBase.Set(this._rawData, "episodes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Episodes)
        {
            item.Validate();
        }
    }

    public EpisodeBulkRetrieveResponse() { }

    public EpisodeBulkRetrieveResponse(EpisodeBulkRetrieveResponse episodeBulkRetrieveResponse)
        : base(episodeBulkRetrieveResponse) { }

    public EpisodeBulkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EpisodeBulkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EpisodeBulkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EpisodeBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EpisodeBulkRetrieveResponse(List<EpisodeObject> episodes)
        : this()
    {
        this.Episodes = episodes;
    }
}

class EpisodeBulkRetrieveResponseFromRaw : IFromRaw<EpisodeBulkRetrieveResponse>
{
    /// <inheritdoc/>
    public EpisodeBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EpisodeBulkRetrieveResponse.FromRawUnchecked(rawData);
}
