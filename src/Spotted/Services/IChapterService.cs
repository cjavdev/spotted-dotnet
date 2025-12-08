using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Chapters;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChapterService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChapterService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single audiobook chapter. Chapters
    /// are only available within the US, UK, Canada, Ireland, New Zealand and Australia
    /// markets.
    /// </summary>
    Task<ChapterRetrieveResponse> Retrieve(
        ChapterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChapterRetrieveParams, CancellationToken)"/>
    Task<ChapterRetrieveResponse> Retrieve(
        string id,
        ChapterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information for several audiobook chapters identified
    /// by their Spotify IDs. Chapters are only available within the US, UK, Canada,
    /// Ireland, New Zealand and Australia markets.
    /// </summary>
    Task<ChapterBulkRetrieveResponse> BulkRetrieve(
        ChapterBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
