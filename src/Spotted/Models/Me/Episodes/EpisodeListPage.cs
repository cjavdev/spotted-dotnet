using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Me;

namespace Spotted.Models.Me.Episodes;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IEpisodeService.List(EpisodeListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class EpisodeListPage(
    IEpisodeServiceWithRawResponse service,
    EpisodeListParams parameters,
    EpisodeListPageResponse response
) : IPage<EpisodeListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<EpisodeListResponse> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<EpisodeListResponse>> IPage<EpisodeListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<EpisodeListPage> Next(CancellationToken cancellationToken = default)
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

    public override bool Equals(object? obj)
    {
        if (obj is not EpisodeListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
