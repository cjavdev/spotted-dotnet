using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Albums;

namespace Spotted.Services.Me;

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
    /// Get a list of the albums saved in the current Spotify user's 'Your Music' library.
    /// </summary>
    Task<AlbumListPage> List(
        AlbumListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check if one or more albums is already saved in the current Spotify user's
    /// 'Your Music' library.
    /// </summary>
    Task<List<bool>> Check(
        AlbumCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more albums from the current user's 'Your Music' library.
    /// </summary>
    Task Remove(
        AlbumRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Save one or more albums to the current user's 'Your Music' library.
    /// </summary>
    Task Save(AlbumSaveParams? parameters = null, CancellationToken cancellationToken = default);
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
    /// Returns a raw HTTP response for `get /me/albums`, but is otherwise the
    /// same as <see cref="IAlbumService.List(AlbumListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AlbumListPage>> List(
        AlbumListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /me/albums/contains`, but is otherwise the
    /// same as <see cref="IAlbumService.Check(AlbumCheckParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<bool>>> Check(
        AlbumCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /me/albums`, but is otherwise the
    /// same as <see cref="IAlbumService.Remove(AlbumRemoveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        AlbumRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /me/albums`, but is otherwise the
    /// same as <see cref="IAlbumService.Save(AlbumSaveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Save(
        AlbumSaveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
