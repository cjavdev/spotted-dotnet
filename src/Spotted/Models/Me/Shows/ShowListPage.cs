using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Me;

namespace Spotted.Models.Me.Shows;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IShowService.List(ShowListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ShowListPage(
    IShowServiceWithRawResponse service,
    ShowListParams parameters,
    ShowListPageResponse response
) : IPage<ShowListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<ShowListResponse> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<ShowListResponse>> IPage<ShowListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ShowListPage> Next(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this.Items, ModelBase.ToStringSerializerOptions);
}
