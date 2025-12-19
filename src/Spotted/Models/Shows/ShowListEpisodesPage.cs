using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services;

namespace Spotted.Models.Shows;

public sealed class ShowListEpisodesPage(
    IShowService service,
    ShowListEpisodesParams parameters,
    ShowListEpisodesPageResponse response
) : IPage<SimplifiedEpisodeObject>
{
    /// <inheritdoc/>
    public IReadOnlyList<SimplifiedEpisodeObject> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<SimplifiedEpisodeObject>> IPage<SimplifiedEpisodeObject>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ShowListEpisodesPage> Next(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
