using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("markets");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "markets",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Markets;
    }

    public MarketListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MarketListResponse(MarketListResponse marketListResponse)
        : base(marketListResponse) { }
#pragma warning restore CS8618

    public MarketListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MarketListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
