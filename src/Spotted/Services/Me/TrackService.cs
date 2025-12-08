using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Tracks;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class TrackService : global::Spotted.Services.Me.ITrackService
{
    /// <inheritdoc/>
    public global::Spotted.Services.Me.ITrackService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Me.TrackService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public TrackService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<TrackListPageResponse> List(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<TrackListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        TrackCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TrackCheckParams> request = new()
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Save(
        TrackSaveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TrackSaveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
