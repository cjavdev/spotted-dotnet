using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me;
using Me = Spotted.Services.Me;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMeService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Me::IAudiobookService Audiobooks { get; }

    Me::IPlaylistService Playlists { get; }

    Me::ITopService Top { get; }

    Me::IAlbumService Albums { get; }

    Me::ITrackService Tracks { get; }

    Me::IEpisodeService Episodes { get; }

    Me::IShowService Shows { get; }

    Me::IFollowingService Following { get; }

    Me::IPlayerService Player { get; }

    /// <summary>
    /// Get detailed profile information about the current user (including the current
    /// user's username).
    /// </summary>
    Task<MeRetrieveResponse> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
