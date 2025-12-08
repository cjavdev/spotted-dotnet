using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Top;

namespace Spotted.Services.Me;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITopService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITopService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the current user's top artists based on calculated affinity.
    /// </summary>
    Task<TopListTopArtistsPageResponse> ListTopArtists(
        TopListTopArtistsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the current user's top tracks based on calculated affinity.
    /// </summary>
    Task<TopListTopTracksPageResponse> ListTopTracks(
        TopListTopTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
