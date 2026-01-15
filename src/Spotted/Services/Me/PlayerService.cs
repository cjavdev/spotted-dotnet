using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Player;
using Spotted.Services.Me.Player;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class PlayerService : IPlayerService
{
    readonly Lazy<IPlayerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlayerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IPlayerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlayerService(this._client.WithOptions(modifier));
    }

    public PlayerService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PlayerServiceWithRawResponse(client.WithRawResponse));
        _queue = new(() => new QueueService(client));
    }

    readonly Lazy<IQueueService> _queue;
    public IQueueService Queue
    {
        get { return _queue.Value; }
    }

    /// <inheritdoc/>
    public async Task<PlayerGetCurrentlyPlayingResponse> GetCurrentlyPlaying(
        PlayerGetCurrentlyPlayingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetCurrentlyPlaying(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PlayerGetDevicesResponse> GetDevices(
        PlayerGetDevicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetDevices(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PlayerGetStateResponse> GetState(
        PlayerGetStateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetState(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PlayerListRecentlyPlayedPage> ListRecentlyPlayed(
        PlayerListRecentlyPlayedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRecentlyPlayed(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task PausePlayback(
        PlayerPausePlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.PausePlayback(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task SeekToPosition(
        PlayerSeekToPositionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SeekToPosition(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task SetRepeatMode(
        PlayerSetRepeatModeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SetRepeatMode(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task SetVolume(
        PlayerSetVolumeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SetVolume(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task SkipNext(
        PlayerSkipNextParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SkipNext(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task SkipPrevious(
        PlayerSkipPreviousParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.SkipPrevious(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task StartPlayback(
        PlayerStartPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.StartPlayback(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task ToggleShuffle(
        PlayerToggleShuffleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.ToggleShuffle(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Transfer(
        PlayerTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Transfer(parameters, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PlayerServiceWithRawResponse : IPlayerServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPlayerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlayerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PlayerServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;

        _queue = new(() => new QueueServiceWithRawResponse(client));
    }

    readonly Lazy<IQueueServiceWithRawResponse> _queue;
    public IQueueServiceWithRawResponse Queue
    {
        get { return _queue.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlayerGetCurrentlyPlayingResponse>> GetCurrentlyPlaying(
        PlayerGetCurrentlyPlayingParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlayerGetCurrentlyPlayingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PlayerGetCurrentlyPlayingResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlayerGetDevicesResponse>> GetDevices(
        PlayerGetDevicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlayerGetDevicesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PlayerGetDevicesResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlayerGetStateResponse>> GetState(
        PlayerGetStateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlayerGetStateParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<PlayerGetStateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlayerListRecentlyPlayedPage>> ListRecentlyPlayed(
        PlayerListRecentlyPlayedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlayerListRecentlyPlayedParams> request = new()
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
                    .Deserialize<PlayerListRecentlyPlayedPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PlayerListRecentlyPlayedPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> PausePlayback(
        PlayerPausePlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlayerPausePlaybackParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SeekToPosition(
        PlayerSeekToPositionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerSeekToPositionParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SetRepeatMode(
        PlayerSetRepeatModeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerSetRepeatModeParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SetVolume(
        PlayerSetVolumeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerSetVolumeParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SkipNext(
        PlayerSkipNextParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlayerSkipNextParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> SkipPrevious(
        PlayerSkipPreviousParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlayerSkipPreviousParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> StartPlayback(
        PlayerStartPlaybackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlayerStartPlaybackParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> ToggleShuffle(
        PlayerToggleShuffleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerToggleShuffleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Transfer(
        PlayerTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerTransferParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }
}
