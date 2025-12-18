using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Browse.Categories;

[JsonConverter(
    typeof(JsonModelConverter<CategoryGetPlaylistsResponse, CategoryGetPlaylistsResponseFromRaw>)
)]
public sealed record class CategoryGetPlaylistsResponse : JsonModel
{
    /// <summary>
    /// The localized message of a playlist.
    /// </summary>
    public string? Message
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "message"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "message", value);
        }
    }

    public PagingPlaylistObject? Playlists
    {
        get { return JsonModel.GetNullableClass<PagingPlaylistObject>(this.RawData, "playlists"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "playlists", value);
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
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Playlists?.Validate();
        _ = this.Published;
    }

    public CategoryGetPlaylistsResponse() { }

    public CategoryGetPlaylistsResponse(CategoryGetPlaylistsResponse categoryGetPlaylistsResponse)
        : base(categoryGetPlaylistsResponse) { }

    public CategoryGetPlaylistsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryGetPlaylistsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryGetPlaylistsResponseFromRaw.FromRawUnchecked"/>
    public static CategoryGetPlaylistsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryGetPlaylistsResponseFromRaw : IFromRawJson<CategoryGetPlaylistsResponse>
{
    /// <inheritdoc/>
    public CategoryGetPlaylistsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CategoryGetPlaylistsResponse.FromRawUnchecked(rawData);
}
