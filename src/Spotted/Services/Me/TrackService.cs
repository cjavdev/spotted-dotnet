using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Tracks;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class TrackService : ITrackService
{
    readonly Lazy<ITrackServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITrackServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public ITrackService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TrackService(this._client.WithOptions(modifier));
    }

    public TrackService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TrackServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TrackListPage> List(
        TrackListParams? parameters = null,
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
        TrackCheckParams parameters,
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
        TrackRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task Save(TrackSaveParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Save(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TrackServiceWithRawResponse : ITrackServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITrackServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TrackServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TrackServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrackListPage>> List(
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TrackListParams> request = new()
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
                    .Deserialize<TrackListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TrackListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<bool>>> Check(
        TrackCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TrackCheckParams> request = new()
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
        TrackRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TrackRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<HttpResponse> Save(
        TrackSaveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TrackSaveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
