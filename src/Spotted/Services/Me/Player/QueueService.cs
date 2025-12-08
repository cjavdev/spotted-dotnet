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
    /// <inheritdoc/>
    public IQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new QueueService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public QueueService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task Add(QueueAddParams parameters, CancellationToken cancellationToken = default)
    {
        HttpRequest<QueueAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<QueueGetResponse> Get(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var queue = await response
            .Deserialize<QueueGetResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            queue.Validate();
        }
        return queue;
    }
}
