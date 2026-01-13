using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Recommendations;

[JsonConverter(
    typeof(JsonModelConverter<
        RecommendationListAvailableGenreSeedsResponse,
        RecommendationListAvailableGenreSeedsResponseFromRaw
    >)
)]
public sealed record class RecommendationListAvailableGenreSeedsResponse : JsonModel
{
    public required IReadOnlyList<string> Genres
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<string>>("genres"); }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "genres",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Genres;
    }

    public RecommendationListAvailableGenreSeedsResponse() { }

    public RecommendationListAvailableGenreSeedsResponse(
        RecommendationListAvailableGenreSeedsResponse recommendationListAvailableGenreSeedsResponse
    )
        : base(recommendationListAvailableGenreSeedsResponse) { }

    public RecommendationListAvailableGenreSeedsResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecommendationListAvailableGenreSeedsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecommendationListAvailableGenreSeedsResponseFromRaw.FromRawUnchecked"/>
    public static RecommendationListAvailableGenreSeedsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RecommendationListAvailableGenreSeedsResponse(List<string> genres)
        : this()
    {
        this.Genres = genres;
    }
}

class RecommendationListAvailableGenreSeedsResponseFromRaw
    : IFromRawJson<RecommendationListAvailableGenreSeedsResponse>
{
    /// <inheritdoc/>
    public RecommendationListAvailableGenreSeedsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecommendationListAvailableGenreSeedsResponse.FromRawUnchecked(rawData);
}
