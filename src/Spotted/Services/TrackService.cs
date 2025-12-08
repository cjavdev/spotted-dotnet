using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models;
using Spotted.Models.Tracks;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class TrackService : ITrackService
{
    /// <inheritdoc/>
    public ITrackService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TrackService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public TrackService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<TrackObject> Retrieve(
        TrackRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<TrackRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var trackObject = await response
            .Deserialize<TrackObject>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            trackObject.Validate();
        }
        return trackObject;
    }

    /// <inheritdoc/>
    public async Task<TrackObject> Retrieve(
        string id,
        TrackRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrackBulkRetrieveResponse> BulkRetrieve(
        TrackBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TrackBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<TrackBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
