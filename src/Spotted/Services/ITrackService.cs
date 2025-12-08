using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Tracks;

namespace Spotted.Services;

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
    ITrackService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single track identified by its unique
    /// Spotify ID.
    /// </summary>
    Task<TrackObject> Retrieve(
        TrackRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TrackRetrieveParams, CancellationToken)"/>
    Task<TrackObject> Retrieve(
        string id,
        TrackRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information for multiple tracks based on their Spotify
    /// IDs.
    /// </summary>
    Task<TrackBulkRetrieveResponse> BulkRetrieve(
        TrackBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
