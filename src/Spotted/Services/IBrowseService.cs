using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Browse;
using Spotted.Services.Browse;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBrowseService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrowseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICategoryService Categories { get; }

    /// <summary>
    /// Get a list of Spotify featured playlists (shown, for example, on a Spotify
    /// player's 'Browse' tab).
    /// </summary>
    [Obsolete("deprecated")]
    Task<BrowseGetFeaturedPlaylistsResponse> GetFeaturedPlaylists(
        BrowseGetFeaturedPlaylistsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of new album releases featured in Spotify (shown, for example,
    /// on a Spotify player’s “Browse” tab).
    /// </summary>
    Task<BrowseGetNewReleasesResponse> GetNewReleases(
        BrowseGetNewReleasesParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
