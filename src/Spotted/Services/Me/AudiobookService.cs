using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Audiobooks;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class AudiobookService : IAudiobookService
{
    readonly Lazy<IAudiobookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAudiobookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IAudiobookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudiobookService(this._client.WithOptions(modifier));
    }

    public AudiobookService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AudiobookServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AudiobookListPage> List(
        AudiobookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        AudiobookCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Check(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Remove(
        AudiobookRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Save(AudiobookSaveParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Save(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AudiobookServiceWithRawResponse : IAudiobookServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAudiobookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudiobookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AudiobookServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AudiobookListPage>> List(
        AudiobookListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AudiobookListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<AudiobookListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AudiobookListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<bool>>> Check(
        AudiobookCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudiobookCheckParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<List<bool>>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        AudiobookRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudiobookRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Save(
        AudiobookSaveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudiobookSaveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
