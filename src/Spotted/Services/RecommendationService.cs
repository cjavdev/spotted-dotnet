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
    readonly Lazy<IRecommendationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRecommendationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IRecommendationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RecommendationService(this._client.WithOptions(modifier));
    }

    public RecommendationService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RecommendationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<RecommendationGetResponse> Get(
        RecommendationGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<RecommendationListAvailableGenreSeedsResponse> ListAvailableGenreSeeds(
        RecommendationListAvailableGenreSeedsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAvailableGenreSeeds(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RecommendationServiceWithRawResponse : IRecommendationServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRecommendationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RecommendationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RecommendationServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<RecommendationGetResponse>> Get(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var recommendation = await response
                    .Deserialize<RecommendationGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    recommendation.Validate();
                }
                return recommendation;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<
        HttpResponse<RecommendationListAvailableGenreSeedsResponse>
    > ListAvailableGenreSeeds(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<RecommendationListAvailableGenreSeedsResponse>(token)
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
