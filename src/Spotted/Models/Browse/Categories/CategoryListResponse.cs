using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Browse.Categories;

[JsonConverter(typeof(ModelConverter<CategoryListResponse, CategoryListResponseFromRaw>))]
public sealed record class CategoryListResponse : ModelBase
{
    public required CategoryListResponseCategories Categories
    {
        get
        {
            return ModelBase.GetNotNullClass<CategoryListResponseCategories>(
                this.RawData,
                "categories"
            );
        }
        init { ModelBase.Set(this._rawData, "categories", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Categories.Validate();
    }

    public CategoryListResponse() { }

    public CategoryListResponse(CategoryListResponse categoryListResponse)
        : base(categoryListResponse) { }

    public CategoryListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryListResponseFromRaw.FromRawUnchecked"/>
    public static CategoryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CategoryListResponse(CategoryListResponseCategories categories)
        : this()
    {
        this.Categories = categories;
    }
}

class CategoryListResponseFromRaw : IFromRaw<CategoryListResponse>
{
    /// <inheritdoc/>
    public CategoryListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CategoryListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<CategoryListResponseCategories, CategoryListResponseCategoriesFromRaw>)
)]
public sealed record class CategoryListResponseCategories : ModelBase
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { ModelBase.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "next"); }
        init { ModelBase.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { ModelBase.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "previous"); }
        init { ModelBase.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "total"); }
        init { ModelBase.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<global::Spotted.Models.Browse.Categories.Item>? Items
    {
        get
        {
            return ModelBase.GetNullableClass<List<global::Spotted.Models.Browse.Categories.Item>>(
                this.RawData,
                "items"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "items", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public CategoryListResponseCategories() { }

    public CategoryListResponseCategories(
        CategoryListResponseCategories categoryListResponseCategories
    )
        : base(categoryListResponseCategories) { }

    public CategoryListResponseCategories(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CategoryListResponseCategories(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CategoryListResponseCategoriesFromRaw.FromRawUnchecked"/>
    public static CategoryListResponseCategories FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CategoryListResponseCategoriesFromRaw : IFromRaw<CategoryListResponseCategories>
{
    /// <inheritdoc/>
    public CategoryListResponseCategories FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CategoryListResponseCategories.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(ModelConverter<
        global::Spotted.Models.Browse.Categories.Item,
        global::Spotted.Models.Browse.Categories.ItemFromRaw
    >)
)]
public sealed record class Item : ModelBase
{
    /// <summary>
    /// The [Spotify category ID](/documentation/web-api/concepts/spotify-uris-ids)
    /// of the category.
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// A link to the Web API endpoint returning full details of the category.
    /// </summary>
    public required string Href
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The category icon, in various sizes.
    /// </summary>
    public required IReadOnlyList<ImageObject> Icons
    {
        get { return ModelBase.GetNotNullClass<List<ImageObject>>(this.RawData, "icons"); }
        init { ModelBase.Set(this._rawData, "icons", value); }
    }

    /// <summary>
    /// The name of the category.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "name"); }
        init { ModelBase.Set(this._rawData, "name", value); }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
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

    public Item() { }

    public Item(global::Spotted.Models.Browse.Categories.Item item)
        : base(item) { }

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Spotted.Models.Browse.Categories.ItemFromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Browse.Categories.Item FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRaw<global::Spotted.Models.Browse.Categories.Item>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Browse.Categories.Item FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Browse.Categories.Item.FromRawUnchecked(rawData);
}
