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
    readonly Lazy<IFollowerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFollowerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IFollowerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowerService(this._client.WithOptions(modifier));
    }

    public FollowerService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FollowerServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        FollowerCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Check(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<bool>> Check(
        string playlistID,
        FollowerCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Check(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Follow(
        FollowerFollowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Follow(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Follow(
        string playlistID,
        FollowerFollowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Follow(parameters with { PlaylistID = playlistID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Unfollow(
        FollowerUnfollowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Unfollow(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Unfollow(
        string playlistID,
        FollowerUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Unfollow(parameters with { PlaylistID = playlistID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FollowerServiceWithRawResponse : IFollowerServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFollowerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FollowerServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<bool>>> Check(
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
    public Task<HttpResponse<List<bool>>> Check(
        string playlistID,
        FollowerCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Check(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Follow(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Follow(
        string playlistID,
        FollowerFollowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Follow(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unfollow(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unfollow(
        string playlistID,
        FollowerUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unfollow(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}
