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
    /// Get Spotify catalog information for multiple albums identified by their Spotify
    /// IDs.
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
