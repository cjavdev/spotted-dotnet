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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Spotted.Services.Me.IEpisodeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Get a list of the episodes saved in the current Spotify user's library.<br/>
    /// This API endpoint is in __beta__ and could change without warning. Please
    /// share any feedback that you have, or issues that you discover, in our [developer
    /// community forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
    /// </summary>
    Task<EpisodeListPageResponse> List(
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
    /// feedback that you have, or issues that you discover, in our [developer community
    /// forum](https://community.spotify.com/t5/Spotify-for-Developers/bd-p/Spotify_Developer).
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
