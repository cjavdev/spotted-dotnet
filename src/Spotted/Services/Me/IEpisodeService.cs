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
    /// Get a list of the episodes saved in the current Spotify user's library.<br/>
    /// This API endpoint is in __beta__ and could change without warning. Please
    /// share any feedback that you have, or issues that you discover, in our [developer
    /// community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
    /// </summary>
    Task<EpisodeListPage> List(
        EpisodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check if one or more episodes is already saved in the current Spotify user's
    /// 'Your Episodes' library.<br/> This API endpoint is in __beta__ and could change
    /// without warning. Please share any feedback that you have, or issues that
    /// you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer)..
    /// </summary>
    Task<List<bool>> Check(
        EpisodeCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more episodes from the current user's library.<br/> This API
    /// endpoint is in __beta__ and could change without warning. Please share any
    /// feedback that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
    /// </summary>
    Task Remove(
        EpisodeRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Save one or more episodes to the current user's library.<br/> This API endpoint
    /// is in __beta__ and could change without warning. Please share any feedback
    /// that you have, or issues that you discover, in our [developer community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
    /// </summary>
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
    Task<HttpResponse<List<bool>>> Check(
        EpisodeCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /me/episodes`, but is otherwise the
    /// same as <see cref="IEpisodeService.Remove(EpisodeRemoveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        EpisodeRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /me/episodes`, but is otherwise the
    /// same as <see cref="IEpisodeService.Save(EpisodeSaveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Save(
        EpisodeSaveParams parameters,
        CancellationToken cancellationToken = default
    );
}
