using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Albums;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAlbumService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAlbumServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAlbumService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single album.
    /// </summary>
    Task<AlbumRetrieveResponse> Retrieve(
        AlbumRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AlbumRetrieveParams, CancellationToken)"/>
    Task<AlbumRetrieveResponse> Retrieve(
        string id,
        AlbumRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information for multiple albums identified by their Spotify IDs.
    /// </summary>
    Task<AlbumBulkRetrieveResponse> BulkRetrieve(
        AlbumBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information about an album’s tracks. Optional parameters
    /// can be used to limit the number of tracks returned.
    /// </summary>
    Task<AlbumListTracksPage> ListTracks(
        AlbumListTracksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTracks(AlbumListTracksParams, CancellationToken)"/>
    Task<AlbumListTracksPage> ListTracks(
        string id,
        AlbumListTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAlbumService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAlbumServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAlbumServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /albums/{id}`, but is otherwise the
    /// same as <see cref="IAlbumService.Retrieve(AlbumRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AlbumRetrieveResponse>> Retrieve(
        AlbumRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AlbumRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AlbumRetrieveResponse>> Retrieve(
        string id,
        AlbumRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /albums`, but is otherwise the
    /// same as <see cref="IAlbumService.BulkRetrieve(AlbumBulkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AlbumBulkRetrieveResponse>> BulkRetrieve(
        AlbumBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /albums/{id}/tracks`, but is otherwise the
    /// same as <see cref="IAlbumService.ListTracks(AlbumListTracksParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AlbumListTracksPage>> ListTracks(
        AlbumListTracksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListTracks(AlbumListTracksParams, CancellationToken)"/>
    Task<HttpResponse<AlbumListTracksPage>> ListTracks(
        string id,
        AlbumListTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
