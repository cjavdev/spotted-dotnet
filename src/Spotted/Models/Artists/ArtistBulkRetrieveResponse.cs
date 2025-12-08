using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Artists;

[JsonConverter(
    typeof(ModelConverter<ArtistBulkRetrieveResponse, ArtistBulkRetrieveResponseFromRaw>)
)]
public sealed record class ArtistBulkRetrieveResponse : ModelBase
{
    public required IReadOnlyList<ArtistObject> Artists
    {
        get { return ModelBase.GetNotNullClass<List<ArtistObject>>(this.RawData, "artists"); }
        init { ModelBase.Set(this._rawData, "artists", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Artists)
        {
            item.Validate();
        }
    }

    public ArtistBulkRetrieveResponse() { }

    public ArtistBulkRetrieveResponse(ArtistBulkRetrieveResponse artistBulkRetrieveResponse)
        : base(artistBulkRetrieveResponse) { }

    public ArtistBulkRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtistBulkRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtistBulkRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ArtistBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ArtistBulkRetrieveResponse(List<ArtistObject> artists)
        : this()
    {
        this.Artists = artists;
    }
}

class ArtistBulkRetrieveResponseFromRaw : IFromRaw<ArtistBulkRetrieveResponse>
{
    /// <inheritdoc/>
    public ArtistBulkRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ArtistBulkRetrieveResponse.FromRawUnchecked(rawData);
}
