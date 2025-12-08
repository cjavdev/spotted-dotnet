using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.AudioFeatures;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class AudioFeatureService : IAudioFeatureService
{
    /// <inheritdoc/>
    public IAudioFeatureService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudioFeatureService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public AudioFeatureService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<AudioFeatureRetrieveResponse> Retrieve(
        AudioFeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AudioFeatureRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var audioFeature = await response
            .Deserialize<AudioFeatureRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audioFeature.Validate();
        }
        return audioFeature;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<AudioFeatureRetrieveResponse> Retrieve(
        string id,
        AudioFeatureRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<AudioFeatureBulkRetrieveResponse> BulkRetrieve(
        AudioFeatureBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudioFeatureBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AudioFeatureBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
