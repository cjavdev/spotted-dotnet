using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Search;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class SearchService : ISearchService
{
    readonly Lazy<ISearchServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISearchServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchService(this._client.WithOptions(modifier));
    }

    public SearchService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SearchServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SearchQueryResponse> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Query(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SearchServiceWithRawResponse : ISearchServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISearchServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SearchServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SearchQueryResponse>> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SearchQueryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SearchQueryResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
