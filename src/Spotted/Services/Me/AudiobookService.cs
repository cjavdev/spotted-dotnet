using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Audiobooks;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class AudiobookService : global::Spotted.Services.Me.IAudiobookService
{
    /// <inheritdoc/>
    public global::Spotted.Services.Me.IAudiobookService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Me.AudiobookService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public AudiobookService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<AudiobookListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<AudiobookListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        AudiobookCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudiobookCheckParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<List<bool>>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Remove(
        AudiobookRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudiobookRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Save(
        AudiobookSaveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudiobookSaveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
