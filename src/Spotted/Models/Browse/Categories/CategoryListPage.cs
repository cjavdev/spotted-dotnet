using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Browse;

namespace Spotted.Models.Browse.Categories;

public sealed class CategoryListPage(
    ICategoryService service,
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
}
