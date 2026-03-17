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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChapterServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChapterService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single audiobook chapter. Chapters are
    /// only available within the US, UK, Canada, Ireland, New Zealand and Australia
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
    /// Get Spotify catalog information for several audiobook chapters identified by
    /// their Spotify IDs. Chapters are only available within the US, UK, Canada,
    /// Ireland, New Zealand and Australia markets.
    /// </summary>
    [Obsolete("deprecated")]
    Task<ChapterBulkRetrieveResponse> BulkRetrieve(
        ChapterBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IChapterService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChapterServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChapterServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /chapters/{id}</c>, but is otherwise the
    /// same as <see cref="IChapterService.Retrieve(ChapterRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ChapterRetrieveResponse>> Retrieve(
        ChapterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ChapterRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ChapterRetrieveResponse>> Retrieve(
        string id,
        ChapterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /chapters</c>, but is otherwise the
    /// same as <see cref="IChapterService.BulkRetrieve(ChapterBulkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ChapterBulkRetrieveResponse>> BulkRetrieve(
        ChapterBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
