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
    /// <inheritdoc/>
    public IPlayerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlayerService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public PlayerService(ISpottedClient client)
    {
        _client = client;
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
        parameters ??= new();

        HttpRequest<PlayerGetCurrentlyPlayingParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PlayerGetCurrentlyPlayingResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<PlayerGetDevicesResponse> GetDevices(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PlayerGetDevicesResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<PlayerGetStateResponse> GetState(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<PlayerGetStateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<PlayerListRecentlyPlayedPage> ListRecentlyPlayed(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<PlayerListRecentlyPlayedPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new PlayerListRecentlyPlayedPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task PausePlayback(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SeekToPosition(
        PlayerSeekToPositionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerSeekToPositionParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SetRepeatMode(
        PlayerSetRepeatModeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerSetRepeatModeParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SetVolume(
        PlayerSetVolumeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerSetVolumeParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SkipNext(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task SkipPrevious(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task StartPlayback(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task ToggleShuffle(
        PlayerToggleShuffleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerToggleShuffleParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Transfer(
        PlayerTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlayerTransferParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
