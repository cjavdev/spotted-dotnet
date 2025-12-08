using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Browse.Categories;

[JsonConverter(
    typeof(ModelConverter<CategoryGetPlaylistsResponse, CategoryGetPlaylistsResponseFromRaw>)
)]
public sealed record class CategoryGetPlaylistsResponse : ModelBase
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

class CategoryGetPlaylistsResponseFromRaw : IFromRaw<CategoryGetPlaylistsResponse>
{
    /// <inheritdoc/>
    public CategoryGetPlaylistsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CategoryGetPlaylistsResponse.FromRawUnchecked(rawData);
}
