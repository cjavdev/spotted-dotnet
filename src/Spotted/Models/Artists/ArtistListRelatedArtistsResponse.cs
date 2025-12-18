using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Artists;

[JsonConverter(
    typeof(JsonModelConverter<
        ArtistListRelatedArtistsResponse,
        ArtistListRelatedArtistsResponseFromRaw
    >)
)]
public sealed record class ArtistListRelatedArtistsResponse : JsonModel
{
    public required IReadOnlyList<ArtistObject> Artists
    {
        get { return JsonModel.GetNotNullClass<List<ArtistObject>>(this.RawData, "artists"); }
        init { JsonModel.Set(this._rawData, "artists", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Artists)
        {
            item.Validate();
        }
    }

    public ArtistListRelatedArtistsResponse() { }

    public ArtistListRelatedArtistsResponse(
        ArtistListRelatedArtistsResponse artistListRelatedArtistsResponse
    )
        : base(artistListRelatedArtistsResponse) { }

    public ArtistListRelatedArtistsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtistListRelatedArtistsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtistListRelatedArtistsResponseFromRaw.FromRawUnchecked"/>
    public static ArtistListRelatedArtistsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ArtistListRelatedArtistsResponse(List<ArtistObject> artists)
        : this()
    {
        this.Artists = artists;
    }
}

class ArtistListRelatedArtistsResponseFromRaw : IFromRawJson<ArtistListRelatedArtistsResponse>
{
    /// <inheritdoc/>
    public ArtistListRelatedArtistsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ArtistListRelatedArtistsResponse.FromRawUnchecked(rawData);
}
