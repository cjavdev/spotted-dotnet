using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Me.Playlists;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class PlaylistService : global::Spotted.Services.Me.IPlaylistService
{
    /// <inheritdoc/>
    public global::Spotted.Services.Me.IPlaylistService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Me.PlaylistService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public PlaylistService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<PlaylistListPage> List(
        PlaylistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlaylistListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<PagingPlaylistObject>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new PlaylistListPage(this, parameters, page);
    }
}
