using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Player;
using Spotted.Services.Me.Player;

namespace Spotted.Services.Me;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPlayerService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlayerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IQueueService Queue { get; }

    /// <summary>
    /// Get the object currently being played on the user's Spotify account.
    /// </summary>
    Task<PlayerGetCurrentlyPlayingResponse> GetCurrentlyPlaying(
        PlayerGetCurrentlyPlayingParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get information about a user’s available Spotify Connect devices. Some device
    /// models are not supported and will not be listed in the API response.
    /// </summary>
    Task<PlayerGetDevicesResponse> GetDevices(
        PlayerGetDevicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get information about the user’s current playback state, including track
    /// or episode, progress, and active device.
    /// </summary>
    Task<PlayerGetStateResponse> GetState(
        PlayerGetStateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get tracks from the current user's recently played tracks. _**Note**: Currently
    /// doesn't support podcast episodes._
    /// </summary>
    Task<PlayerListRecentlyPlayedPage> ListRecentlyPlayed(
        PlayerListRecentlyPlayedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Pause playback on the user's account. This API only works for users who have
    /// Spotify Premium. The order of execution is not guaranteed when you use this
    /// API with other Player API endpoints.
    /// </summary>
    Task PausePlayback(
        PlayerPausePlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Seeks to the given position in the user’s currently playing track. This API
    /// only works for users who have Spotify Premium. The order of execution is
    /// not guaranteed when you use this API with other Player API endpoints.
    /// </summary>
    Task SeekToPosition(
        PlayerSeekToPositionParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set the repeat mode for the user's playback. This API only works for users
    /// who have Spotify Premium. The order of execution is not guaranteed when you
    /// use this API with other Player API endpoints.
    /// </summary>
    Task SetRepeatMode(
        PlayerSetRepeatModeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set the volume for the user’s current playback device. This API only works
    /// for users who have Spotify Premium. The order of execution is not guaranteed
    /// when you use this API with other Player API endpoints.
    /// </summary>
    Task SetVolume(PlayerSetVolumeParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Skips to next track in the user’s queue. This API only works for users who
    /// have Spotify Premium. The order of execution is not guaranteed when you use
    /// this API with other Player API endpoints.
    /// </summary>
    Task SkipNext(
        PlayerSkipNextParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Skips to previous track in the user’s queue. This API only works for users
    /// who have Spotify Premium. The order of execution is not guaranteed when you
    /// use this API with other Player API endpoints.
    /// </summary>
    Task SkipPrevious(
        PlayerSkipPreviousParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Start a new context or resume current playback on the user's active device.
    /// This API only works for users who have Spotify Premium. The order of execution
    /// is not guaranteed when you use this API with other Player API endpoints.
    /// </summary>
    Task StartPlayback(
        PlayerStartPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Toggle shuffle on or off for user’s playback. This API only works for users
    /// who have Spotify Premium. The order of execution is not guaranteed when you
    /// use this API with other Player API endpoints.
    /// </summary>
    Task ToggleShuffle(
        PlayerToggleShuffleParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Transfer playback to a new device and optionally begin playback. This API
    /// only works for users who have Spotify Premium. The order of execution is not
    /// guaranteed when you use this API with other Player API endpoints.
    /// </summary>
    Task Transfer(PlayerTransferParams parameters, CancellationToken cancellationToken = default);
}
