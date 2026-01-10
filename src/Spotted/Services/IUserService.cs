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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserServiceWithRawResponse WithRawResponse { get; }

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

/// <summary>
/// A view of <see cref="IUserService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Users::IPlaylistServiceWithRawResponse Playlists { get; }

    /// <summary>
    /// Returns a raw HTTP response for `get /users/{user_id}`, but is otherwise the
    /// same as <see cref="IUserService.RetrieveProfile(UserRetrieveProfileParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserRetrieveProfileResponse>> RetrieveProfile(
        UserRetrieveProfileParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveProfile(UserRetrieveProfileParams, CancellationToken)"/>
    Task<HttpResponse<UserRetrieveProfileResponse>> RetrieveProfile(
        string userID,
        UserRetrieveProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
