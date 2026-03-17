using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Playlists;

namespace Spotted.Services.Me;

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
    /// Get a list of the playlists owned or followed by the current Spotify user.
    /// </summary>
    Task<PlaylistListPage> List(
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
    /// Returns a raw HTTP response for <c>get /me/playlists</c>, but is otherwise the
    /// same as <see cref="IPlaylistService.List(PlaylistListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlaylistListPage>> List(
        PlaylistListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
