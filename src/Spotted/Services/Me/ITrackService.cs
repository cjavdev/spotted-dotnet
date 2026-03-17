using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Tracks;

namespace Spotted.Services.Me;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITrackService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITrackServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrackService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a list of the songs saved in the current Spotify user's 'Your Music'
    /// library.
    /// </summary>
    Task<TrackListPage> List(
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check if one or more tracks is already saved in the current Spotify user's 'Your
    /// Music' library.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Check User's Saved
    /// Items](/documentation/web-api/reference/check-library-contains) instead. </para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<bool>> Check(
        TrackCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more tracks from the current user's 'Your Music' library.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Remove Items from
    /// Library](/documentation/web-api/reference/remove-library-items) instead. </para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Remove(
        TrackRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Save one or more tracks to the current user's 'Your Music' library.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Save Items to
    /// Library](/documentation/web-api/reference/save-library-items) instead. </para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Save(TrackSaveParams parameters, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="ITrackService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITrackServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrackServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /me/tracks</c>, but is otherwise the
    /// same as <see cref="ITrackService.List(TrackListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TrackListPage>> List(
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /me/tracks/contains</c>, but is otherwise the
    /// same as <see cref="ITrackService.Check(TrackCheckParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<bool>>> Check(
        TrackCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /me/tracks</c>, but is otherwise the
    /// same as <see cref="ITrackService.Remove(TrackRemoveParams?, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Remove(
        TrackRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /me/tracks</c>, but is otherwise the
    /// same as <see cref="ITrackService.Save(TrackSaveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Save(
        TrackSaveParams parameters,
        CancellationToken cancellationToken = default
    );
}
