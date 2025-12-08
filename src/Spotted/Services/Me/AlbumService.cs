using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Albums;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class AlbumService : global::Spotted.Services.Me.IAlbumService
{
    /// <inheritdoc/>
    public global::Spotted.Services.Me.IAlbumService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Me.AlbumService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public AlbumService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<AlbumListPageResponse> List(
        AlbumListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AlbumListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<AlbumListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        AlbumCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AlbumCheckParams> request = new()
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
        AlbumRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AlbumRemoveParams> request = new()
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
        AlbumSaveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AlbumSaveParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
