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
    /// <inheritdoc/>
    public ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SearchService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public SearchService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<SearchQueryResponse> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SearchQueryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<SearchQueryResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
