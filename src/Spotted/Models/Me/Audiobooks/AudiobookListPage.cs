using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services.Me;

namespace Spotted.Models.Me.Audiobooks;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IAudiobookService.List(AudiobookListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class AudiobookListPage(
    IAudiobookServiceWithRawResponse service,
    AudiobookListParams parameters,
    AudiobookListPageResponse response
) : IPage<AudiobookListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<AudiobookListResponse> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<AudiobookListResponse>> IPage<AudiobookListResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<AudiobookListPage> Next(CancellationToken cancellationToken = default)
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
