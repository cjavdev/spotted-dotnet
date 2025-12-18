using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "id"); }
        init { JsonModel.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint returning full details of the category.
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The category icon, in various sizes.
    /// </summary>
    public required IReadOnlyList<ImageObject> Icons
    {
        get { return JsonModel.GetNotNullClass<List<ImageObject>>(this.RawData, "icons"); }
        init { JsonModel.Set(this._rawData, "icons", value); }
    }

    /// <summary>
    /// The name of the category.
    /// </summary>
    public required string Name
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "name"); }
        init { JsonModel.Set(this._rawData, "name", value); }
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

    public CategoryRetrieveResponse(CategoryRetrieveResponse categoryRetrieveResponse)
        : base(categoryRetrieveResponse) { }

    public CategoryRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
