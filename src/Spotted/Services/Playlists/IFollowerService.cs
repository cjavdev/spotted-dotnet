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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFollowerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Check to see if the current user is following a specified playlist.
    /// </summary>
    Task<List<bool>> Check(
        FollowerCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Check(FollowerCheckParams, CancellationToken)"/>
    Task<List<bool>> Check(
        string playlistID,
        FollowerCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add the current user as a follower of a playlist.
    /// </summary>
    Task Follow(FollowerFollowParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Follow(FollowerFollowParams, CancellationToken)"/>
    Task Follow(
        string playlistID,
        FollowerFollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove the current user as a follower of a playlist.
    /// </summary>
    Task Unfollow(FollowerUnfollowParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Unfollow(FollowerUnfollowParams, CancellationToken)"/>
    Task Unfollow(
        string playlistID,
        FollowerUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
