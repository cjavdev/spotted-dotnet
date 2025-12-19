using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services;

namespace Spotted.Models.Albums;

public sealed class AlbumListTracksPage(
    IAlbumService service,
    AlbumListTracksParams parameters,
    AlbumListTracksPageResponse response
) : IPage<SimplifiedTrackObject>
{
    /// <inheritdoc/>
    public IReadOnlyList<SimplifiedTrackObject> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<SimplifiedTrackObject>> IPage<SimplifiedTrackObject>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<AlbumListTracksPage> Next(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
