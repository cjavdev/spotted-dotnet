using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models;
using Spotted.Models.Episodes;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class EpisodeService : IEpisodeService
{
    readonly Lazy<IEpisodeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEpisodeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IEpisodeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EpisodeService(this._client.WithOptions(modifier));
    }

    public EpisodeService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EpisodeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EpisodeObject> Retrieve(
        EpisodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EpisodeObject> Retrieve(
        string id,
        EpisodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EpisodeBulkRetrieveResponse> BulkRetrieve(
        EpisodeBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.BulkRetrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EpisodeServiceWithRawResponse : IEpisodeServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEpisodeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EpisodeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EpisodeServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EpisodeObject>> Retrieve(
        EpisodeRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EpisodeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var episodeObject = await response
                    .Deserialize<EpisodeObject>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    episodeObject.Validate();
                }
                return episodeObject;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EpisodeObject>> Retrieve(
        string id,
        EpisodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EpisodeBulkRetrieveResponse>> BulkRetrieve(
        EpisodeBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EpisodeBulkRetrieveParams> request = new()
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
                    .Deserialize<EpisodeBulkRetrieveResponse>(token)
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
