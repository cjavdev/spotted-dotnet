using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Following;

namespace Spotted.Services.Me;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFollowingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFollowingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the current user's followed artists.
    /// </summary>
    Task<FollowingBulkRetrieveResponse> BulkRetrieve(
        FollowingBulkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check to see if the current user is following one or more artists or other
    /// Spotify users.
    /// </summary>
    Task<List<bool>> Check(
        FollowingCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add the current user as a follower of one or more artists or other Spotify users.
    /// </summary>
    Task Follow(FollowingFollowParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove the current user as a follower of one or more artists or other Spotify users.
    /// </summary>
    Task Unfollow(
        FollowingUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFollowingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFollowingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /me/following`, but is otherwise the
    /// same as <see cref="IFollowingService.BulkRetrieve(FollowingBulkRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FollowingBulkRetrieveResponse>> BulkRetrieve(
        FollowingBulkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /me/following/contains`, but is otherwise the
    /// same as <see cref="IFollowingService.Check(FollowingCheckParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<bool>>> Check(
        FollowingCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /me/following`, but is otherwise the
    /// same as <see cref="IFollowingService.Follow(FollowingFollowParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Follow(
        FollowingFollowParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /me/following`, but is otherwise the
    /// same as <see cref="IFollowingService.Unfollow(FollowingUnfollowParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Unfollow(
        FollowingUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
