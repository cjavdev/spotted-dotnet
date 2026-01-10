using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Audiobooks;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAudiobookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAudiobookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudiobookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single audiobook. Audiobooks are only
    /// available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    Task<AudiobookRetrieveResponse> Retrieve(
        AudiobookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AudiobookRetrieveParams, CancellationToken)"/>
    Task<AudiobookRetrieveResponse> Retrieve(
        string id,
        AudiobookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information for several audiobooks identified by their
    /// Spotify IDs. Audiobooks are only available within the US, UK, Canada, Ireland,
    /// New Zealand and Australia markets.
    /// </summary>
    Task<AudiobookBulkRetrieveResponse> BulkRetrieve(
        AudiobookBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information about an audiobook's chapters. Audiobooks
    /// are only available within the US, UK, Canada, Ireland, New Zealand and Australia markets.
    /// </summary>
    Task<AudiobookListChaptersPage> ListChapters(
        AudiobookListChaptersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListChapters(AudiobookListChaptersParams, CancellationToken)"/>
    Task<AudiobookListChaptersPage> ListChapters(
        string id,
        AudiobookListChaptersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAudiobookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAudiobookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudiobookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /audiobooks/{id}`, but is otherwise the
    /// same as <see cref="IAudiobookService.Retrieve(AudiobookRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AudiobookRetrieveResponse>> Retrieve(
        AudiobookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AudiobookRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AudiobookRetrieveResponse>> Retrieve(
        string id,
        AudiobookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /audiobooks`, but is otherwise the
    /// same as <see cref="IAudiobookService.BulkRetrieve(AudiobookBulkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AudiobookBulkRetrieveResponse>> BulkRetrieve(
        AudiobookBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /audiobooks/{id}/chapters`, but is otherwise the
    /// same as <see cref="IAudiobookService.ListChapters(AudiobookListChaptersParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AudiobookListChaptersPage>> ListChapters(
        AudiobookListChaptersParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListChapters(AudiobookListChaptersParams, CancellationToken)"/>
    Task<HttpResponse<AudiobookListChaptersPage>> ListChapters(
        string id,
        AudiobookListChaptersParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
