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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IArtistServiceWithRawResponse WithRawResponse { get; }

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
    /// Get Spotify catalog information for several artists based on their Spotify IDs.
    /// </summary>
    [Obsolete("deprecated")]
    Task<ArtistBulkRetrieveResponse> BulkRetrieve(
        ArtistBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information about an artist's albums.
    /// </summary>
    [Obsolete("deprecated")]
    Task<ArtistListAlbumsPage> ListAlbums(
        ArtistListAlbumsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAlbums(ArtistListAlbumsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
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
    [Obsolete("deprecated")]
    Task<ArtistTopTracksResponse> TopTracks(
        ArtistTopTracksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TopTracks(ArtistTopTracksParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<ArtistTopTracksResponse> TopTracks(
        string id,
        ArtistTopTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IArtistService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IArtistServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IArtistServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /artists/{id}`, but is otherwise the
    /// same as <see cref="IArtistService.Retrieve(ArtistRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ArtistObject>> Retrieve(
        ArtistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ArtistRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ArtistObject>> Retrieve(
        string id,
        ArtistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /artists`, but is otherwise the
    /// same as <see cref="IArtistService.BulkRetrieve(ArtistBulkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ArtistBulkRetrieveResponse>> BulkRetrieve(
        ArtistBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /artists/{id}/albums`, but is otherwise the
    /// same as <see cref="IArtistService.ListAlbums(ArtistListAlbumsParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ArtistListAlbumsPage>> ListAlbums(
        ArtistListAlbumsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListAlbums(ArtistListAlbumsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ArtistListAlbumsPage>> ListAlbums(
        string id,
        ArtistListAlbumsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /artists/{id}/related-artists`, but is otherwise the
    /// same as <see cref="IArtistService.ListRelatedArtists(ArtistListRelatedArtistsParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ArtistListRelatedArtistsResponse>> ListRelatedArtists(
        ArtistListRelatedArtistsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ListRelatedArtists(ArtistListRelatedArtistsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ArtistListRelatedArtistsResponse>> ListRelatedArtists(
        string id,
        ArtistListRelatedArtistsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /artists/{id}/top-tracks`, but is otherwise the
    /// same as <see cref="IArtistService.TopTracks(ArtistTopTracksParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<ArtistTopTracksResponse>> TopTracks(
        ArtistTopTracksParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="TopTracks(ArtistTopTracksParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<ArtistTopTracksResponse>> TopTracks(
        string id,
        ArtistTopTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
