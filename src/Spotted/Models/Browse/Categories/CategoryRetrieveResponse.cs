using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Browse.Categories;

[JsonConverter(typeof(ModelConverter<CategoryRetrieveResponse, CategoryRetrieveResponseFromRaw>))]
public sealed record class CategoryRetrieveResponse : ModelBase
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

class CategoryRetrieveResponseFromRaw : IFromRaw<CategoryRetrieveResponse>
{
    /// <inheritdoc/>
    public CategoryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CategoryRetrieveResponse.FromRawUnchecked(rawData);
}
