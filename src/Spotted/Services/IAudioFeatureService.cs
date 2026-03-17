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
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAudioFeatureServiceWithRawResponse WithRawResponse { get; }

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

/// <summary>
/// A view of <see cref="IAudioFeatureService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAudioFeatureServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAudioFeatureServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /audio-features/{id}</c>, but is otherwise the
    /// same as <see cref="IAudioFeatureService.Retrieve(AudioFeatureRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<AudioFeatureRetrieveResponse>> Retrieve(
        AudioFeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AudioFeatureRetrieveParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<HttpResponse<AudioFeatureRetrieveResponse>> Retrieve(
        string id,
        AudioFeatureRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /audio-features</c>, but is otherwise the
    /// same as <see cref="IAudioFeatureService.BulkRetrieve(AudioFeatureBulkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<AudioFeatureBulkRetrieveResponse>> BulkRetrieve(
        AudioFeatureBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
