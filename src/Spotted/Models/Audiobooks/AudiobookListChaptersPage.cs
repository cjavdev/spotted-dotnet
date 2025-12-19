using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services;

namespace Spotted.Models.Audiobooks;

public sealed class AudiobookListChaptersPage(
    IAudiobookService service,
    AudiobookListChaptersParams parameters,
    AudiobookListChaptersPageResponse response
) : IPage<SimplifiedChapterObject>
{
    /// <inheritdoc/>
    public IReadOnlyList<SimplifiedChapterObject> Items
    {
        get { return response.Items ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        return this.Items.Count > 0;
    }

    /// <inheritdoc/>
    async Task<IPage<SimplifiedChapterObject>> IPage<SimplifiedChapterObject>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<AudiobookListChaptersPage> Next(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Cannot request next page");
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }
}
