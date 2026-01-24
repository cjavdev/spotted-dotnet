using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Playlists;

namespace Spotted.Models.Playlists.Tracks;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ITrackService.List(TrackListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class TrackListPage(
    ITrackServiceWithRawResponse service,
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

    public override string ToString() =>
        JsonSerializer.Serialize(this.Items, ModelBase.ToStringSerializerOptions);

    public override bool Equals(object? obj)
    {
        if (obj is not TrackListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
