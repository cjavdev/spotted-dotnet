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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Spotted.Services.Me.ITrackService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Get a list of the songs saved in the current Spotify user's 'Your Music'
    /// library.
    /// </summary>
    Task<TrackListPage> List(
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check if one or more tracks is already saved in the current Spotify user's
    /// 'Your Music' library.
    /// </summary>
    Task<List<bool>> Check(
        TrackCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more tracks from the current user's 'Your Music' library.
    /// </summary>
    Task Remove(
        TrackRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Save one or more tracks to the current user's 'Your Music' library.
    /// </summary>
    Task Save(TrackSaveParams parameters, CancellationToken cancellationToken = default);
}
