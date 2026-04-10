using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Markets;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class MarketService : IMarketService
{
    readonly Lazy<IMarketServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMarketServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IMarketService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MarketService(this._client.WithOptions(modifier));
    }

    public MarketService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MarketServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<MarketListResponse> List(
        MarketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MarketServiceWithRawResponse : IMarketServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMarketServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MarketServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MarketServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<MarketListResponse>> List(
        MarketListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MarketListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var markets = await response
                    .Deserialize<MarketListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    markets.Validate();
                }
                return markets;
            }
        );
    }
}
