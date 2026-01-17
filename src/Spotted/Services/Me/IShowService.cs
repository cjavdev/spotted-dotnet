using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Shows;

namespace Spotted.Services.Me;

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
    /// Get a list of shows saved in the current Spotify user's library. Optional
    /// parameters can be used to limit the number of shows returned.
    /// </summary>
    Task<ShowListPage> List(
        ShowListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check if one or more shows is already saved in the current Spotify user's library.
    /// </summary>
    Task<List<bool>> Check(
        ShowCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete one or more shows from current Spotify user's library.
    /// </summary>
    Task Remove(ShowRemoveParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Save one or more shows to current Spotify user's library.
    /// </summary>
    Task Save(ShowSaveParams? parameters = null, CancellationToken cancellationToken = default);
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
    /// Returns a raw HTTP response for `get /me/shows`, but is otherwise the
    /// same as <see cref="IShowService.List(ShowListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ShowListPage>> List(
        ShowListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /me/shows/contains`, but is otherwise the
    /// same as <see cref="IShowService.Check(ShowCheckParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<bool>>> Check(
        ShowCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /me/shows`, but is otherwise the
    /// same as <see cref="IShowService.Remove(ShowRemoveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        ShowRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /me/shows`, but is otherwise the
    /// same as <see cref="IShowService.Save(ShowSaveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Save(
        ShowSaveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
