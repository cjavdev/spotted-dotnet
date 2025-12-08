using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Playlists.Tracks;

namespace Spotted.Services.Playlists;

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
    global::Spotted.Services.Playlists.ITrackService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Either reorder or replace items in a playlist depending on the request's
    /// parameters. To reorder items, include `range_start`, `insert_before`, `range_length`
    /// and `snapshot_id` in the request's body. To replace items, include `uris`
    /// as either a query parameter or in the request's body. Replacing items in
    /// a playlist will overwrite its existing items. This operation can be used
    /// for replacing or clearing items in a playlist. <br/> **Note**: Replace and
    /// reorder are mutually exclusive operations which share the same endpoint,
    /// but have different parameters. These operations can't be applied together
    /// in a single request.
    /// </summary>
    Task<TrackUpdateResponse> Update(
        TrackUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TrackUpdateParams, CancellationToken)"/>
    Task<TrackUpdateResponse> Update(
        string playlistID,
        TrackUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get full details of the items of a playlist owned by a Spotify user.
    /// </summary>
    Task<TrackListPageResponse> List(
        TrackListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TrackListParams, CancellationToken)"/>
    Task<TrackListPageResponse> List(
        string playlistID,
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add one or more items to a user's playlist.
    /// </summary>
    Task<TrackAddResponse> Add(
        TrackAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(TrackAddParams, CancellationToken)"/>
    Task<TrackAddResponse> Add(
        string playlistID,
        TrackAddParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more items from a user's playlist.
    /// </summary>
    Task<TrackRemoveResponse> Remove(
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(TrackRemoveParams, CancellationToken)"/>
    Task<TrackRemoveResponse> Remove(
        string playlistID,
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
