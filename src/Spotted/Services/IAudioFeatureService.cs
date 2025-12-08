using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.AudioFeatures;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAudioFeatureService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudioFeatureService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get audio feature information for a single track identified by its unique
    /// Spotify ID.
    /// </summary>
    [Obsolete("deprecated")]
    Task<AudioFeatureRetrieveResponse> Retrieve(
        AudioFeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AudioFeatureRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<AudioFeatureRetrieveResponse> Retrieve(
        string id,
        AudioFeatureRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get audio features for multiple tracks based on their Spotify IDs.
    /// </summary>
    [Obsolete("deprecated")]
    Task<AudioFeatureBulkRetrieveResponse> BulkRetrieve(
        AudioFeatureBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
