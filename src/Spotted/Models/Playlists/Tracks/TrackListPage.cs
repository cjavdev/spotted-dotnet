using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Playlists;

namespace Spotted.Models.Playlists.Tracks;

public sealed class TrackListPage(
    ITrackService service,
    TrackListParams parameters,
    TrackListPageResponse response
) : IPage<PlaylistTrackObject>
{
    /// <inheritdoc/>
    public IReadOnlyList<PlaylistTrackObject> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<PlaylistTrackObject>> IPage<PlaylistTrackObject>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<TrackListPage> Next(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
