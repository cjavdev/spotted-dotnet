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
    /// <inheritdoc/>
    public IMarketService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MarketService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public MarketService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<MarketListResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var markets = await response
            .Deserialize<MarketListResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            markets.Validate();
        }
        return markets;
    }
}
