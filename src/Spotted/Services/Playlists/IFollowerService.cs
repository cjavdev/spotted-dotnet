using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Playlists.Followers;

namespace Spotted.Services.Playlists;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFollowerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFollowerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Check to see if the current user is following a specified playlist.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Check User's Saved
    /// Items](/documentation/web-api/reference/check-library-contains) instead. </para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<List<bool>> Check(
        FollowerCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Check(FollowerCheckParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<List<bool>> Check(
        string playlistID,
        FollowerCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add the current user as a follower of a playlist.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Save Items to
    /// Library](/documentation/web-api/reference/save-library-items) instead. </para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Follow(FollowerFollowParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Follow(FollowerFollowParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task Follow(
        string playlistID,
        FollowerFollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove the current user as a follower of a playlist.
    ///
    /// <para>**Note:** This endpoint is deprecated. Use [Remove Items from
    /// Library](/documentation/web-api/reference/remove-library-items) instead. </para>
    /// </summary>
    [Obsolete("deprecated")]
    Task Unfollow(FollowerUnfollowParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Unfollow(FollowerUnfollowParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task Unfollow(
        string playlistID,
        FollowerUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFollowerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFollowerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /playlists/{playlist_id}/followers/contains</c>, but is otherwise the
    /// same as <see cref="IFollowerService.Check(FollowerCheckParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<bool>>> Check(
        FollowerCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Check(FollowerCheckParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<List<bool>>> Check(
        string playlistID,
        FollowerCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /playlists/{playlist_id}/followers</c>, but is otherwise the
    /// same as <see cref="IFollowerService.Follow(FollowerFollowParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Follow(
        FollowerFollowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Follow(FollowerFollowParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> Follow(
        string playlistID,
        FollowerFollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /playlists/{playlist_id}/followers</c>, but is otherwise the
    /// same as <see cref="IFollowerService.Unfollow(FollowerUnfollowParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse> Unfollow(
        FollowerUnfollowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unfollow(FollowerUnfollowParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse> Unfollow(
        string playlistID,
        FollowerUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
