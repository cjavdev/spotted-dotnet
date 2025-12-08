using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Browse;

[JsonConverter(
    typeof(ModelConverter<
        BrowseGetFeaturedPlaylistsResponse,
        BrowseGetFeaturedPlaylistsResponseFromRaw
    >)
)]
public sealed record class BrowseGetFeaturedPlaylistsResponse : ModelBase
{
    /// <summary>
    /// The localized message of a playlist.
    /// </summary>
    public string? Message
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "message", value);
        }
    }

    public PagingPlaylistObject? Playlists
    {
        get { return ModelBase.GetNullableClass<PagingPlaylistObject>(this.RawData, "playlists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "playlists", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Playlists?.Validate();
    }

    public BrowseGetFeaturedPlaylistsResponse() { }

    public BrowseGetFeaturedPlaylistsResponse(
        BrowseGetFeaturedPlaylistsResponse browseGetFeaturedPlaylistsResponse
    )
        : base(browseGetFeaturedPlaylistsResponse) { }

    public BrowseGetFeaturedPlaylistsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowseGetFeaturedPlaylistsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowseGetFeaturedPlaylistsResponseFromRaw.FromRawUnchecked"/>
    public static BrowseGetFeaturedPlaylistsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowseGetFeaturedPlaylistsResponseFromRaw : IFromRaw<BrowseGetFeaturedPlaylistsResponse>
{
    /// <inheritdoc/>
    public BrowseGetFeaturedPlaylistsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowseGetFeaturedPlaylistsResponse.FromRawUnchecked(rawData);
}
