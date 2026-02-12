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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITrackServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrackService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// **Deprecated:** Use [Update Playlist Items](/documentation/web-api/reference/reorder-or-replace-playlists-items) instead.
    ///
    /// <para>Either reorder or replace items in a playlist depending on the request's
    /// parameters. To reorder items, include `range_start`, `insert_before`, `range_length`
    /// and `snapshot_id` in the request's body. To replace items, include `uris`
    /// as either a query parameter or in the request's body. Replacing items in
    /// a playlist will overwrite its existing items. This operation can be used
    /// for replacing or clearing items in a playlist. <br/> **Note**: Replace and
    /// reorder are mutually exclusive operations which share the same endpoint,
    /// but have different parameters. These operations can't be applied together
    /// in a single request.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<TrackUpdateResponse> Update(
        TrackUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TrackUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<TrackUpdateResponse> Update(
        string playlistID,
        TrackUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated:** Use [Get Playlist Items](/documentation/web-api/reference/get-playlists-items) instead.
    ///
    /// <para>Get full details of the items of a playlist owned by a Spotify user.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<TrackListPage> List(
        TrackListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TrackListParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<TrackListPage> List(
        string playlistID,
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated:** Use [Add Items to Playlist](/documentation/web-api/reference/add-items-to-playlist) instead.
    ///
    /// <para>Add one or more items to a user's playlist.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<TrackAddResponse> Add(
        TrackAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(TrackAddParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<TrackAddResponse> Add(
        string playlistID,
        TrackAddParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// **Deprecated:** Use [Remove Playlist Items](/documentation/web-api/reference/remove-items-playlist) instead.
    ///
    /// <para>Remove one or more items from a user's playlist.</para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<TrackRemoveResponse> Remove(
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(TrackRemoveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<TrackRemoveResponse> Remove(
        string playlistID,
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITrackService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITrackServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrackServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `put /playlists/{playlist_id}/tracks`, but is otherwise the
    /// same as <see cref="ITrackService.Update(TrackUpdateParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackUpdateResponse>> Update(
        TrackUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TrackUpdateParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackUpdateResponse>> Update(
        string playlistID,
        TrackUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /playlists/{playlist_id}/tracks`, but is otherwise the
    /// same as <see cref="ITrackService.List(TrackListParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackListPage>> List(
        TrackListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TrackListParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackListPage>> List(
        string playlistID,
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /playlists/{playlist_id}/tracks`, but is otherwise the
    /// same as <see cref="ITrackService.Add(TrackAddParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackAddResponse>> Add(
        TrackAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(TrackAddParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackAddResponse>> Add(
        string playlistID,
        TrackAddParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /playlists/{playlist_id}/tracks`, but is otherwise the
    /// same as <see cref="ITrackService.Remove(TrackRemoveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackRemoveResponse>> Remove(
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(TrackRemoveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackRemoveResponse>> Remove(
        string playlistID,
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
