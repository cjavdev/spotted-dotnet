using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Me;

namespace Spotted.Models.Me.Player;

public sealed class PlayerListRecentlyPlayedPage(
    IPlayerService service,
    PlayerListRecentlyPlayedParams parameters,
    PlayerListRecentlyPlayedPageResponse response
) : IPage<PlayerListRecentlyPlayedResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<PlayerListRecentlyPlayedResponse> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<
        IPage<PlayerListRecentlyPlayedResponse>
    > IPage<PlayerListRecentlyPlayedResponse>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<PlayerListRecentlyPlayedPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
