using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models;
using Spotted.Models.Users.Playlists;

namespace Spotted.Services.Users;

/// <inheritdoc/>
public sealed class PlaylistService : global::Spotted.Services.Users.IPlaylistService
{
    /// <inheritdoc/>
    public global::Spotted.Services.Users.IPlaylistService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Users.PlaylistService(
            this._client.WithOptions(modifier)
        );
    }

    readonly ISpottedClient _client;

    public PlaylistService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<PlaylistCreateResponse> Create(
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new SpottedInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<PlaylistCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var playlist = await response
            .Deserialize<PlaylistCreateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            playlist.Validate();
        }
        return playlist;
    }

    /// <inheritdoc/>
    public async Task<PlaylistCreateResponse> Create(
        string userID,
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Create(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PagingPlaylistObject> List(
        PlaylistListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new SpottedInvalidDataException("'parameters.UserID' cannot be null");
        }

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
        return page;
    }

    /// <inheritdoc/>
    public async Task<PagingPlaylistObject> List(
        string userID,
        PlaylistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { UserID = userID }, cancellationToken);
    }
}
