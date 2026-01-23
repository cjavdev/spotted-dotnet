using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Browse.Categories;

[JsonConverter(
    typeof(JsonModelConverter<CategoryRetrieveResponse, CategoryRetrieveResponseFromRaw>)
)]
public sealed record class CategoryRetrieveResponse : JsonModel
{
    /// <summary>
    /// The [Spotify category ID](/documentation/web-api/concepts/spotify-uris-ids)
    /// of the category.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint returning full details of the category.
    /// </summary>
    public required string Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("href");
        }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// The category icon, in various sizes.
    /// </summary>
    public required IReadOnlyList<ImageObject> Icons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ImageObject>>("icons");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ImageObject>>(
                "icons",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The name of the category.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        _ = this.ID;
        _ = this.Href;
        foreach (var item in this.Icons)
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.Published;
    }

    public CategoryRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CategoryRetrieveResponse(CategoryRetrieveResponse categoryRetrieveResponse)
        : base(categoryRetrieveResponse) { }
#pragma warning restore CS8618

    public CategoryRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CategoryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryRetrieveResponseFromRaw : IFromRawJson<CategoryRetrieveResponse>
{
    /// <inheritdoc/>
    public CategoryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CategoryRetrieveResponse.FromRawUnchecked(rawData);
}
