using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Playlists;
using Playlists = Spotted.Services.Playlists;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPlaylistService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlaylistService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Playlists::ITrackService Tracks { get; }

    Playlists::IFollowerService Followers { get; }

    Playlists::IImageService Images { get; }

    /// <summary>
    /// Get a playlist owned by a Spotify user.
    /// </summary>
    Task<PlaylistRetrieveResponse> Retrieve(
        PlaylistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PlaylistRetrieveParams, CancellationToken)"/>
    Task<PlaylistRetrieveResponse> Retrieve(
        string playlistID,
        PlaylistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change a playlist's name and public/private state. (The user must, of course,
    /// own the playlist.)
    /// </summary>
    Task Update(PlaylistUpdateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Update(PlaylistUpdateParams, CancellationToken)"/>
    Task Update(
        string playlistID,
        PlaylistUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
