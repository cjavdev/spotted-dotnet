using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Episodes;

namespace Spotted.Services.Me;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEpisodeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEpisodeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEpisodeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a list of the episodes saved in the current Spotify user's library.
    /// </summary>
    Task<EpisodeListPage> List(
        EpisodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check if one or more episodes is already saved in the current Spotify user's
    /// 'Your Episodes' library.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Check User's Saved Items](/documentation/web-api/reference/check-library-contains) instead.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<bool>> Check(
        EpisodeCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more episodes from the current user's library.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Remove Items from Library](/documentation/web-api/reference/remove-library-items) instead.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Remove(
        EpisodeRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Save one or more episodes to the current user's library.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Save Items to Library](/documentation/web-api/reference/save-library-items) instead.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Save(EpisodeSaveParams parameters, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="IEpisodeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEpisodeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEpisodeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /me/episodes`, but is otherwise the
    /// same as <see cref="IEpisodeService.List(EpisodeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EpisodeListPage>> List(
        EpisodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /me/episodes/contains`, but is otherwise the
    /// same as <see cref="IEpisodeService.Check(EpisodeCheckParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<bool>>> Check(
        EpisodeCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /me/episodes`, but is otherwise the
    /// same as <see cref="IEpisodeService.Remove(EpisodeRemoveParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Remove(
        EpisodeRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /me/episodes`, but is otherwise the
    /// same as <see cref="IEpisodeService.Save(EpisodeSaveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Save(
        EpisodeSaveParams parameters,
        CancellationToken cancellationToken = default
    );
}
