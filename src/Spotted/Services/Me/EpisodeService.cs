using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Episodes;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class EpisodeService : IEpisodeService
{
    readonly Lazy<IEpisodeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEpisodeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IEpisodeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EpisodeService(this._client.WithOptions(modifier));
    }

    public EpisodeService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EpisodeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EpisodeListPage> List(
        EpisodeListParams? parameters = null,
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
        EpisodeCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Check(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task Remove(
        EpisodeRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task Save(EpisodeSaveParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Save(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EpisodeServiceWithRawResponse : IEpisodeServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEpisodeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EpisodeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EpisodeServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EpisodeListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<EpisodeListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EpisodeListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<bool>>> Check(
        EpisodeCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EpisodeCheckParams> request = new()
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
    [Obsolete("deprecated")]
    public Task<HttpResponse> Remove(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> Save(
        EpisodeSaveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EpisodeSaveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
