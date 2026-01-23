using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Browse;

[JsonConverter(
    typeof(JsonModelConverter<
        BrowseGetFeaturedPlaylistsResponse,
        BrowseGetFeaturedPlaylistsResponseFromRaw
    >)
)]
public sealed record class BrowseGetFeaturedPlaylistsResponse : JsonModel
{
    /// <summary>
    /// The localized message of a playlist.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    public PagingPlaylistObject? Playlists
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PagingPlaylistObject>("playlists");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("playlists", value);
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
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
        _ = this.Message;
        this.Playlists?.Validate();
        _ = this.Published;
    }

    public BrowseGetFeaturedPlaylistsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowseGetFeaturedPlaylistsResponse(
        BrowseGetFeaturedPlaylistsResponse browseGetFeaturedPlaylistsResponse
    )
        : base(browseGetFeaturedPlaylistsResponse) { }
#pragma warning restore CS8618

    public BrowseGetFeaturedPlaylistsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowseGetFeaturedPlaylistsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class BrowseGetFeaturedPlaylistsResponseFromRaw : IFromRawJson<BrowseGetFeaturedPlaylistsResponse>
{
    /// <inheritdoc/>
    public BrowseGetFeaturedPlaylistsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowseGetFeaturedPlaylistsResponse.FromRawUnchecked(rawData);
}
