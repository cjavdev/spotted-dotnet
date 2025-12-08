using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.AudioAnalysis;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAudioAnalysisService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudioAnalysisService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a low-level audio analysis for a track in the Spotify catalog. The audio
    /// analysis describes the track’s structure and musical content, including rhythm,
    /// pitch, and timbre.
    /// </summary>
    [Obsolete("deprecated")]
    Task<AudioAnalysisRetrieveResponse> Retrieve(
        AudioAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AudioAnalysisRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<AudioAnalysisRetrieveResponse> Retrieve(
        string id,
        AudioAnalysisRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
