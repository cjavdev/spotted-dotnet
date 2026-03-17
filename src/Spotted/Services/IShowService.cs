using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Shows;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IShowService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IShowServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShowService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single show identified by its unique
    /// Spotify ID.
    /// </summary>
    Task<ShowRetrieveResponse> Retrieve(
        ShowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ShowRetrieveParams, CancellationToken)"/>
    Task<ShowRetrieveResponse> Retrieve(
        string id,
        ShowRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information for several shows based on their Spotify IDs.
    /// </summary>
    [Obsolete("deprecated")]
    Task<ShowBulkRetrieveResponse> BulkRetrieve(
        ShowBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information about an show’s episodes. Optional parameters
    /// can be used to limit the number of episodes returned.
    /// </summary>
    Task<ShowListEpisodesPage> ListEpisodes(
        ShowListEpisodesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEpisodes(ShowListEpisodesParams, CancellationToken)"/>
    Task<ShowListEpisodesPage> ListEpisodes(
        string id,
        ShowListEpisodesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IShowService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IShowServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IShowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /shows/{id}</c>, but is otherwise the
    /// same as <see cref="IShowService.Retrieve(ShowRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ShowRetrieveResponse>> Retrieve(
        ShowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ShowRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ShowRetrieveResponse>> Retrieve(
        string id,
        ShowRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /shows</c>, but is otherwise the
    /// same as <see cref="IShowService.BulkRetrieve(ShowBulkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ShowBulkRetrieveResponse>> BulkRetrieve(
        ShowBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /shows/{id}/episodes</c>, but is otherwise the
    /// same as <see cref="IShowService.ListEpisodes(ShowListEpisodesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ShowListEpisodesPage>> ListEpisodes(
        ShowListEpisodesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListEpisodes(ShowListEpisodesParams, CancellationToken)"/>
    Task<HttpResponse<ShowListEpisodesPage>> ListEpisodes(
        string id,
        ShowListEpisodesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
