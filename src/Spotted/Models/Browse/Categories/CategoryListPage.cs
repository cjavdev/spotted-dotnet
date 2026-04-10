using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Browse;

namespace Spotted.Models.Browse.Categories;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ICategoryService.List(CategoryListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class CategoryListPage(
    ICategoryServiceWithRawResponse service,
    CategoryListParams parameters,
    CategoryListPageResponse response
) : IPage<CategoryListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<CategoryListResponse> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<CategoryListResponse>> IPage<CategoryListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<CategoryListPage> Next(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not CategoryListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
