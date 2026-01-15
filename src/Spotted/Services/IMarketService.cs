using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Markets;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMarketService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMarketServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMarketService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get the list of markets where Spotify is available.
    /// </summary>
    Task<MarketListResponse> List(
        MarketListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMarketService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMarketServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMarketServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /markets`, but is otherwise the
    /// same as <see cref="IMarketService.List(MarketListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MarketListResponse>> List(
        MarketListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
