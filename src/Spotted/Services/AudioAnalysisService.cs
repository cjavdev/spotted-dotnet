using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.AudioAnalysis;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class AudioAnalysisService : IAudioAnalysisService
{
    readonly Lazy<IAudioAnalysisServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAudioAnalysisServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IAudioAnalysisService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudioAnalysisService(this._client.WithOptions(modifier));
    }

    public AudioAnalysisService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AudioAnalysisServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<AudioAnalysisRetrieveResponse> Retrieve(
        AudioAnalysisRetrieveParams parameters,
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
    public Task<AudioAnalysisRetrieveResponse> Retrieve(
        string id,
        AudioAnalysisRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AudioAnalysisServiceWithRawResponse : IAudioAnalysisServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAudioAnalysisServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AudioAnalysisServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AudioAnalysisServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<AudioAnalysisRetrieveResponse>> Retrieve(
        AudioAnalysisRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AudioAnalysisRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var audioAnalysis = await response
                    .Deserialize<AudioAnalysisRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    audioAnalysis.Validate();
                }
                return audioAnalysis;
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse<AudioAnalysisRetrieveResponse>> Retrieve(
        string id,
        AudioAnalysisRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}
