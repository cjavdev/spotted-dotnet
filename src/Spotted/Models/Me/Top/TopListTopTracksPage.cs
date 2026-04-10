using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Me;

namespace Spotted.Models.Me.Top;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ITopService.ListTopTracks(TopListTopTracksParams, CancellationToken)"/> queries.
/// </summary>
public sealed class TopListTopTracksPage(
    ITopServiceWithRawResponse service,
    TopListTopTracksParams parameters,
    TopListTopTracksPageResponse response
) : IPage<TrackObject>
{
    /// <inheritdoc/>
    public IReadOnlyList<TrackObject> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<TrackObject>> IPage<TrackObject>.Next(CancellationToken cancellationToken) =>
        await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<TopListTopTracksPage> Next(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not TopListTopTracksPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
