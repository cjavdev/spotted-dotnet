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
    /// <inheritdoc/>
    public IEpisodeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EpisodeService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public EpisodeService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<EpisodeObject> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var episodeObject = await response
            .Deserialize<EpisodeObject>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            episodeObject.Validate();
        }
        return episodeObject;
    }

    /// <inheritdoc/>
    public async Task<EpisodeObject> Retrieve(
        string id,
        EpisodeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EpisodeBulkRetrieveResponse> BulkRetrieve(
        EpisodeBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EpisodeBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<EpisodeBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
