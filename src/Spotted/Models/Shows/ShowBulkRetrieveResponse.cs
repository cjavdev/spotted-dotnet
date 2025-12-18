using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Shows;

[JsonConverter(
    typeof(JsonModelConverter<ShowBulkRetrieveResponse, ShowBulkRetrieveResponseFromRaw>)
)]
public sealed record class ShowBulkRetrieveResponse : JsonModel
{
    public required IReadOnlyList<ShowBase> Shows
    {
        get { return JsonModel.GetNotNullClass<List<ShowBase>>(this.RawData, "shows"); }
        init { JsonModel.Set(this._rawData, "shows", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Shows)
        {
            item.Validate();
        }
    }

    public ShowBulkRetrieveResponse() { }

    public ShowBulkRetrieveResponse(ShowBulkRetrieveResponse showBulkRetrieveResponse)
        : base(showBulkRetrieveResponse) { }

    public ShowBulkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShowBulkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShowBulkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ShowBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ShowBulkRetrieveResponse(List<ShowBase> shows)
        : this()
    {
        this.Shows = shows;
    }
}

class ShowBulkRetrieveResponseFromRaw : IFromRawJson<ShowBulkRetrieveResponse>
{
    /// <inheritdoc/>
    public ShowBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ShowBulkRetrieveResponse.FromRawUnchecked(rawData);
}
