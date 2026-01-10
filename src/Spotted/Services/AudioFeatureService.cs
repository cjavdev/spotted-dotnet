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
    readonly Lazy<IAudioFeatureServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAudioFeatureServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IAudioFeatureService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudioFeatureService(this._client.WithOptions(modifier));
    }

    public AudioFeatureService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AudioFeatureServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<AudioFeatureRetrieveResponse> Retrieve(
        AudioFeatureRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<AudioFeatureRetrieveResponse> Retrieve(
        string id,
        AudioFeatureRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<AudioFeatureBulkRetrieveResponse> BulkRetrieve(
        AudioFeatureBulkRetrieveParams parameters,
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
public sealed class AudioFeatureServiceWithRawResponse : IAudioFeatureServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAudioFeatureServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AudioFeatureServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AudioFeatureServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<AudioFeatureRetrieveResponse>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var audioFeature = await response
                    .Deserialize<AudioFeatureRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    audioFeature.Validate();
                }
                return audioFeature;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<AudioFeatureRetrieveResponse>> Retrieve(
        string id,
        AudioFeatureRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<AudioFeatureBulkRetrieveResponse>> BulkRetrieve(
        AudioFeatureBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudioFeatureBulkRetrieveParams> request = new()
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
                    .Deserialize<AudioFeatureBulkRetrieveResponse>(token)
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
