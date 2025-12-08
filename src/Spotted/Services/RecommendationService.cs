using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Recommendations;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class RecommendationService : IRecommendationService
{
    /// <inheritdoc/>
    public IRecommendationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RecommendationService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public RecommendationService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<RecommendationGetResponse> Get(
        RecommendationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RecommendationGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var recommendation = await response
            .Deserialize<RecommendationGetResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            recommendation.Validate();
        }
        return recommendation;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<RecommendationListAvailableGenreSeedsResponse> ListAvailableGenreSeeds(
        RecommendationListAvailableGenreSeedsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RecommendationListAvailableGenreSeedsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<RecommendationListAvailableGenreSeedsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
