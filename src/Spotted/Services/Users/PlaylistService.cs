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
    readonly Lazy<global::Spotted.Services.Users.IPlaylistServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public global::Spotted.Services.Users.IPlaylistServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public global::Spotted.Services.Users.IPlaylistService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Users.PlaylistService(
            this._client.WithOptions(modifier)
        );
    }

    public PlaylistService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new global::Spotted.Services.Users.PlaylistServiceWithRawResponse(
                client.WithRawResponse
            )
        );
    }

    /// <inheritdoc/>
    public async Task<PlaylistCreateResponse> Create(
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlaylistCreateResponse> Create(
        string userID,
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlaylistListPage> List(
        PlaylistListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlaylistListPage> List(
        string userID,
        PlaylistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { UserID = userID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PlaylistServiceWithRawResponse
    : global::Spotted.Services.Users.IPlaylistServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public global::Spotted.Services.Users.IPlaylistServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Users.PlaylistServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public PlaylistServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlaylistCreateResponse>> Create(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var playlist = await response
                    .Deserialize<PlaylistCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    playlist.Validate();
                }
                return playlist;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PlaylistCreateResponse>> Create(
        string userID,
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlaylistListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<PagingPlaylistObject>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PlaylistListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PlaylistListPage>> List(
        string userID,
        PlaylistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { UserID = userID }, cancellationToken);
    }
}
