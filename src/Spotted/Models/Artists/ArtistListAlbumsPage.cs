using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services;

namespace Spotted.Models.Artists;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IArtistService.ListAlbums(ArtistListAlbumsParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ArtistListAlbumsPage(
    IArtistServiceWithRawResponse service,
    ArtistListAlbumsParams parameters,
    ArtistListAlbumsPageResponse response
) : IPage<ArtistListAlbumsResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<ArtistListAlbumsResponse> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<ArtistListAlbumsResponse>> IPage<ArtistListAlbumsResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ArtistListAlbumsPage> Next(CancellationToken cancellationToken = default)
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
