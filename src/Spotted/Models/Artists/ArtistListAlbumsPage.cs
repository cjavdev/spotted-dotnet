using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services;

namespace Spotted.Models.Artists;

public sealed class ArtistListAlbumsPage(
    IArtistService service,
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
}
