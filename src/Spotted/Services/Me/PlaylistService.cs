using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Me.Playlists;

namespace Spotted.Services.Me;

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
    public async Task<PlaylistListPage> List(
        PlaylistListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
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
    public async Task<HttpResponse<PlaylistListPage>> List(
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
}
