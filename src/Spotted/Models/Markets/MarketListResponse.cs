using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Markets;

[JsonConverter(typeof(JsonModelConverter<MarketListResponse, MarketListResponseFromRaw>))]
public sealed record class MarketListResponse : JsonModel
{
    public IReadOnlyList<string>? Markets
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "markets"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "markets", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Markets;
    }

    public MarketListResponse() { }

    public MarketListResponse(MarketListResponse marketListResponse)
        : base(marketListResponse) { }

    public MarketListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarketListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MarketListResponseFromRaw.FromRawUnchecked"/>
    public static MarketListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MarketListResponseFromRaw : IFromRawJson<MarketListResponse>
{
    /// <inheritdoc/>
    public MarketListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MarketListResponse.FromRawUnchecked(rawData);
}
