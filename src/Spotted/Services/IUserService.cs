using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Users;
using Users = Spotted.Services.Users;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Users::IPlaylistService Playlists { get; }

    /// <summary>
    /// Get public profile information about a Spotify user.
    /// </summary>
    Task<UserRetrieveProfileResponse> RetrieveProfile(
        UserRetrieveProfileParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveProfile(UserRetrieveProfileParams, CancellationToken)"/>
    Task<UserRetrieveProfileResponse> RetrieveProfile(
        string userID,
        UserRetrieveProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
