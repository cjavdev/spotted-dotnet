using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Recommendations;

[JsonConverter(typeof(ModelConverter<RecommendationGetResponse, RecommendationGetResponseFromRaw>))]
public sealed record class RecommendationGetResponse : ModelBase
{
    /// <summary>
    /// An array of recommendation seed objects.
    /// </summary>
    public required IReadOnlyList<Seed> Seeds
    {
        get { return ModelBase.GetNotNullClass<List<Seed>>(this.RawData, "seeds"); }
        init { ModelBase.Set(this._rawData, "seeds", value); }
    }

    /// <summary>
    /// An array of track objects ordered according to the parameters supplied.
    /// </summary>
    public required IReadOnlyList<TrackObject> Tracks
    {
        get { return ModelBase.GetNotNullClass<List<TrackObject>>(this.RawData, "tracks"); }
        init { ModelBase.Set(this._rawData, "tracks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Seeds)
        {
            item.Validate();
        }
        foreach (var item in this.Tracks)
        {
            item.Validate();
        }
    }

    public RecommendationGetResponse() { }

    public RecommendationGetResponse(RecommendationGetResponse recommendationGetResponse)
        : base(recommendationGetResponse) { }

    public RecommendationGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecommendationGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RecommendationGetResponseFromRaw.FromRawUnchecked"/>
    public static RecommendationGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RecommendationGetResponseFromRaw : IFromRaw<RecommendationGetResponse>
{
    /// <inheritdoc/>
    public RecommendationGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecommendationGetResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Seed, SeedFromRaw>))]
public sealed record class Seed : ModelBase
{
    /// <summary>
    /// The id used to select this seed. This will be the same as the string used
    /// in the `seed_artists`, `seed_tracks` or `seed_genres` parameter.
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// The number of tracks available after min\_\* and max\_\* filters have been
    /// applied.
    /// </summary>
    public long? AfterFilteringSize
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "afterFilteringSize"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "afterFilteringSize", value);
        }
    }

    /// <summary>
    /// The number of tracks available after relinking for regional availability.
    /// </summary>
    public long? AfterRelinkingSize
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "afterRelinkingSize"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "afterRelinkingSize", value);
        }
    }

    /// <summary>
    /// A link to the full track or artist data for this seed. For tracks this will
    /// be a link to a Track Object. For artists a link to an Artist Object. For
    /// genre seeds, this value will be `null`.
    /// </summary>
    public string? Href
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "href", value);
        }
    }

    /// <summary>
    /// The number of recommended tracks available for this seed.
    /// </summary>
    public long? InitialPoolSize
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "initialPoolSize"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "initialPoolSize", value);
        }
    }

    /// <summary>
    /// The entity type of this seed. One of `artist`, `track` or `genre`.
    /// </summary>
    public string? Type
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AfterFilteringSize;
        _ = this.AfterRelinkingSize;
        _ = this.Href;
        _ = this.InitialPoolSize;
        _ = this.Type;
    }

    public Seed() { }

    public Seed(Seed seed)
        : base(seed) { }

    public Seed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Seed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SeedFromRaw.FromRawUnchecked"/>
    public static Seed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SeedFromRaw : IFromRaw<Seed>
{
    /// <inheritdoc/>
    public Seed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Seed.FromRawUnchecked(rawData);
}
