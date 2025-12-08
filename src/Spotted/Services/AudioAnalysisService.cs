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
    /// <inheritdoc/>
    public IAudioAnalysisService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudioAnalysisService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public AudioAnalysisService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<AudioAnalysisRetrieveResponse> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var audioAnalysis = await response
            .Deserialize<AudioAnalysisRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audioAnalysis.Validate();
        }
        return audioAnalysis;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<AudioAnalysisRetrieveResponse> Retrieve(
        string id,
        AudioAnalysisRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }
}
