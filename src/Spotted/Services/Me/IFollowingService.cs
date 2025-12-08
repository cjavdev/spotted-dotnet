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
    /// Add the current user as a follower of one or more artists or other Spotify
    /// users.
    /// </summary>
    Task Follow(FollowingFollowParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove the current user as a follower of one or more artists or other Spotify
    /// users.
    /// </summary>
    Task Unfollow(
        FollowingUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
