using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Me;

namespace Spotted.Models.Me.Albums;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IAlbumService.List(AlbumListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class AlbumListPage(
    IAlbumServiceWithRawResponse service,
    AlbumListParams parameters,
    AlbumListPageResponse response
) : IPage<AlbumListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<AlbumListResponse> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<AlbumListResponse>> IPage<AlbumListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<AlbumListPage> Next(CancellationToken cancellationToken = default)
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
