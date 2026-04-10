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
public sealed class PlaylistService : IPlaylistService
{
    readonly Lazy<IPlaylistServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlaylistServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IPlaylistService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlaylistService(this._client.WithOptions(modifier));
    }

    public PlaylistService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PlaylistServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
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
    [Obsolete("deprecated")]
    public Task<PlaylistCreateResponse> Create(
        string userID,
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
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
    [Obsolete("deprecated")]
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
public sealed class PlaylistServiceWithRawResponse : IPlaylistServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPlaylistServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlaylistServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PlaylistServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
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
    [Obsolete("deprecated")]
    public Task<HttpResponse<PlaylistCreateResponse>> Create(
        string userID,
        PlaylistCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { UserID = userID }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
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
    [Obsolete("deprecated")]
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
