using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Artists;

[JsonConverter(typeof(JsonModelConverter<ArtistTopTracksResponse, ArtistTopTracksResponseFromRaw>))]
public sealed record class ArtistTopTracksResponse : JsonModel
{
    public required IReadOnlyList<TrackObject> Tracks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TrackObject>>("tracks");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TrackObject>>(
                "tracks",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Tracks)
        {
            item.Validate();
        }
    }

    public ArtistTopTracksResponse() { }

    public ArtistTopTracksResponse(ArtistTopTracksResponse artistTopTracksResponse)
        : base(artistTopTracksResponse) { }

    public ArtistTopTracksResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtistTopTracksResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtistTopTracksResponseFromRaw.FromRawUnchecked"/>
    public static ArtistTopTracksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ArtistTopTracksResponse(IReadOnlyList<TrackObject> tracks)
        : this()
    {
        this.Tracks = tracks;
    }
}

class ArtistTopTracksResponseFromRaw : IFromRawJson<ArtistTopTracksResponse>
{
    /// <inheritdoc/>
    public ArtistTopTracksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ArtistTopTracksResponse.FromRawUnchecked(rawData);
}
