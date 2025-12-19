using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Users;

namespace Spotted.Models.Users.Playlists;

public sealed class PlaylistListPage(
    IPlaylistService service,
    PlaylistListParams parameters,
    PagingPlaylistObject response
) : IPage<SimplifiedPlaylistObject>
{
    /// <inheritdoc/>
    public IReadOnlyList<SimplifiedPlaylistObject> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<SimplifiedPlaylistObject>> IPage<SimplifiedPlaylistObject>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<PlaylistListPage> Next(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
