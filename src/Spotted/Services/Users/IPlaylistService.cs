using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Users.Playlists;

namespace Spotted.Services.Users;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPlaylistService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPlaylistServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlaylistService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a playlist for a Spotify user. (The playlist will be empty until you
    /// [add tracks](/documentation/web-api/reference/add-tracks-to-playlist).) Each
    /// user is generally limited to a maximum of 11000 playlists.
    /// </summary>
    Task<PlaylistCreateResponse> Create(
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(PlaylistCreateParams, CancellationToken)"/>
    Task<PlaylistCreateResponse> Create(
        string userID,
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of the playlists owned or followed by a Spotify user.
    /// </summary>
    Task<PlaylistListPage> List(
        PlaylistListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(PlaylistListParams, CancellationToken)"/>
    Task<PlaylistListPage> List(
        string userID,
        PlaylistListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPlaylistService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPlaylistServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlaylistServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /users/{user_id}/playlists`, but is otherwise the
    /// same as <see cref="IPlaylistService.Create(PlaylistCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlaylistCreateResponse>> Create(
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(PlaylistCreateParams, CancellationToken)"/>
    Task<HttpResponse<PlaylistCreateResponse>> Create(
        string userID,
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /users/{user_id}/playlists`, but is otherwise the
    /// same as <see cref="IPlaylistService.List(PlaylistListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlaylistListPage>> List(
        PlaylistListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(PlaylistListParams, CancellationToken)"/>
    Task<HttpResponse<PlaylistListPage>> List(
        string userID,
        PlaylistListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
