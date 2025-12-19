using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Artists;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IArtistService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IArtistService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single artist identified by their unique
    /// Spotify ID.
    /// </summary>
    Task<ArtistObject> Retrieve(
        ArtistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ArtistRetrieveParams, CancellationToken)"/>
    Task<ArtistObject> Retrieve(
        string id,
        ArtistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information for several artists based on their Spotify
    /// IDs.
    /// </summary>
    Task<ArtistBulkRetrieveResponse> BulkRetrieve(
        ArtistBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information about an artist's albums.
    /// </summary>
    Task<ArtistListAlbumsPage> ListAlbums(
        ArtistListAlbumsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAlbums(ArtistListAlbumsParams, CancellationToken)"/>
    Task<ArtistListAlbumsPage> ListAlbums(
        string id,
        ArtistListAlbumsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information about artists similar to a given artist. Similarity
    /// is based on analysis of the Spotify community's listening history.
    /// </summary>
    [Obsolete("deprecated")]
    Task<ArtistListRelatedArtistsResponse> ListRelatedArtists(
        ArtistListRelatedArtistsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRelatedArtists(ArtistListRelatedArtistsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ArtistListRelatedArtistsResponse> ListRelatedArtists(
        string id,
        ArtistListRelatedArtistsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information about an artist's top tracks by country.
    /// </summary>
    Task<ArtistTopTracksResponse> TopTracks(
        ArtistTopTracksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TopTracks(ArtistTopTracksParams, CancellationToken)"/>
    Task<ArtistTopTracksResponse> TopTracks(
        string id,
        ArtistTopTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
