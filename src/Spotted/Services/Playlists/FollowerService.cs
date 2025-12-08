using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Playlists.Followers;

namespace Spotted.Services.Playlists;

/// <inheritdoc/>
public sealed class FollowerService : IFollowerService
{
    /// <inheritdoc/>
    public IFollowerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowerService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public FollowerService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        FollowerCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<FollowerCheckParams> request = new()
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
    public async Task<List<bool>> Check(
        string playlistID,
        FollowerCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Check(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Follow(
        FollowerFollowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<FollowerFollowParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Follow(
        string playlistID,
        FollowerFollowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Follow(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Unfollow(
        FollowerUnfollowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<FollowerUnfollowParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Unfollow(
        string playlistID,
        FollowerUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Unfollow(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}
