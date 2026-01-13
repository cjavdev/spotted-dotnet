using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Recommendations;

[JsonConverter(
    typeof(JsonModelConverter<RecommendationGetResponse, RecommendationGetResponseFromRaw>)
)]
public sealed record class RecommendationGetResponse : JsonModel
{
    /// <summary>
    /// An array of recommendation seed objects.
    /// </summary>
    public required IReadOnlyList<Seed> Seeds
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<Seed>>("seeds"); }
        init
        {
            this._rawData.Set<ImmutableArray<Seed>>(
                "seeds",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An array of track objects ordered according to the parameters supplied.
    /// </summary>
    public required IReadOnlyList<TrackObject> Tracks
    {
        get { return this._rawData.GetNotNullStruct<ImmutableArray<TrackObject>>("tracks"); }
        init
        {
            this._rawData.Set<ImmutableArray<TrackObject>>(
                "tracks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return this._rawData.GetNullableStruct<bool>("published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
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
        _ = this.Published;
    }

    public RecommendationGetResponse() { }

    public RecommendationGetResponse(RecommendationGetResponse recommendationGetResponse)
        : base(recommendationGetResponse) { }

    public RecommendationGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RecommendationGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class RecommendationGetResponseFromRaw : IFromRawJson<RecommendationGetResponse>
{
    /// <inheritdoc/>
    public RecommendationGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RecommendationGetResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Seed, SeedFromRaw>))]
public sealed record class Seed : JsonModel
{
    /// <summary>
    /// The id used to select this seed. This will be the same as the string used
    /// in the `seed_artists`, `seed_tracks` or `seed_genres` parameter.
    /// </summary>
    public string? ID
    {
        get { return this._rawData.GetNullableClass<string>("id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// The number of tracks available after min\_\* and max\_\* filters have been
    /// applied.
    /// </summary>
    public long? AfterFilteringSize
    {
        get { return this._rawData.GetNullableStruct<long>("afterFilteringSize"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("afterFilteringSize", value);
        }
    }

    /// <summary>
    /// The number of tracks available after relinking for regional availability.
    /// </summary>
    public long? AfterRelinkingSize
    {
        get { return this._rawData.GetNullableStruct<long>("afterRelinkingSize"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("afterRelinkingSize", value);
        }
    }

    /// <summary>
    /// A link to the full track or artist data for this seed. For tracks this will
    /// be a link to a Track Object. For artists a link to an Artist Object. For
    /// genre seeds, this value will be `null`.
    /// </summary>
    public string? Href
    {
        get { return this._rawData.GetNullableClass<string>("href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("href", value);
        }
    }

    /// <summary>
    /// The number of recommended tracks available for this seed.
    /// </summary>
    public long? InitialPoolSize
    {
        get { return this._rawData.GetNullableStruct<long>("initialPoolSize"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("initialPoolSize", value);
        }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return this._rawData.GetNullableStruct<bool>("published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <summary>
    /// The entity type of this seed. One of `artist`, `track` or `genre`.
    /// </summary>
    public string? Type
    {
        get { return this._rawData.GetNullableClass<string>("type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
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
        _ = this.Published;
        _ = this.Type;
    }

    public Seed() { }

    public Seed(Seed seed)
        : base(seed) { }

    public Seed(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Seed(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SeedFromRaw.FromRawUnchecked"/>
    public static Seed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SeedFromRaw : IFromRawJson<Seed>
{
    /// <inheritdoc/>
    public Seed FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Seed.FromRawUnchecked(rawData);
}
