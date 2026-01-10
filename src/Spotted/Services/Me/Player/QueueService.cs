using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Player.Queue;

namespace Spotted.Services.Me.Player;

/// <inheritdoc/>
public sealed class QueueService : IQueueService
{
    readonly Lazy<IQueueServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IQueueServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new QueueService(this._client.WithOptions(modifier));
    }

    public QueueService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new QueueServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task Add(QueueAddParams parameters, CancellationToken cancellationToken = default)
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<QueueGetResponse> Get(
        QueueGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Get(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class QueueServiceWithRawResponse : IQueueServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IQueueServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new QueueServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public QueueServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Add(
        QueueAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<QueueAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<QueueGetResponse>> Get(
        QueueGetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<QueueGetParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var queue = await response
                    .Deserialize<QueueGetResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    queue.Validate();
                }
                return queue;
            }
        );
    }
}
