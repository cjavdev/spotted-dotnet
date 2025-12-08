using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Episodes;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class EpisodeService : global::Spotted.Services.Me.IEpisodeService
{
    /// <inheritdoc/>
    public global::Spotted.Services.Me.IEpisodeService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Me.EpisodeService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public EpisodeService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<EpisodeListPageResponse> List(
        EpisodeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EpisodeListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<EpisodeListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        EpisodeCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EpisodeCheckParams> request = new()
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
        EpisodeRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EpisodeRemoveParams> request = new()
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
        EpisodeSaveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EpisodeSaveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
