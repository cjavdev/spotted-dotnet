using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Recommendations;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRecommendationService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRecommendationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Recommendations are generated based on the available information for a given
    /// seed entity and matched against similar artists and tracks. If there is sufficient
    /// information about the provided seeds, a list of tracks will be returned together
    /// with pool size details.
    ///
    /// <para>For artists and tracks that are very new or obscure there might not
    /// be enough data to generate a list of tracks. </para>
    /// </summary>
    [Obsolete("deprecated")]
    Task<RecommendationGetResponse> Get(
        RecommendationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of available genres seed parameter values for [recommendations](/documentation/web-api/reference/get-recommendations).
    /// </summary>
    [Obsolete("deprecated")]
    Task<RecommendationListAvailableGenreSeedsResponse> ListAvailableGenreSeeds(
        RecommendationListAvailableGenreSeedsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
