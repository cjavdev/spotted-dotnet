using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Episodes;

namespace Spotted.Services;

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
    IEpisodeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single episode identified by its unique
    /// Spotify ID.
    /// </summary>
    Task<EpisodeObject> Retrieve(
        EpisodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EpisodeRetrieveParams, CancellationToken)"/>
    Task<EpisodeObject> Retrieve(
        string id,
        EpisodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information for several episodes based on their Spotify
    /// IDs.
    /// </summary>
    Task<EpisodeBulkRetrieveResponse> BulkRetrieve(
        EpisodeBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
