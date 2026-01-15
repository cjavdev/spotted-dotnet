using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Playlists;
using Playlists = Spotted.Services.Playlists;

namespace Spotted.Services;

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
        _tracks = new(() => new Playlists::TrackService(client));
        _followers = new(() => new Playlists::FollowerService(client));
        _images = new(() => new Playlists::ImageService(client));
    }

    readonly Lazy<Playlists::ITrackService> _tracks;
    public Playlists::ITrackService Tracks
    {
        get { return _tracks.Value; }
    }

    readonly Lazy<Playlists::IFollowerService> _followers;
    public Playlists::IFollowerService Followers
    {
        get { return _followers.Value; }
    }

    readonly Lazy<Playlists::IImageService> _images;
    public Playlists::IImageService Images
    {
        get { return _images.Value; }
    }

    /// <inheritdoc/>
    public async Task<PlaylistRetrieveResponse> Retrieve(
        PlaylistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlaylistRetrieveResponse> Retrieve(
        string playlistID,
        PlaylistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Update(
        PlaylistUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
        string playlistID,
        PlaylistUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { PlaylistID = playlistID }, cancellationToken)
            .ConfigureAwait(false);
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

        _tracks = new(() => new Playlists::TrackServiceWithRawResponse(client));
        _followers = new(() => new Playlists::FollowerServiceWithRawResponse(client));
        _images = new(() => new Playlists::ImageServiceWithRawResponse(client));
    }

    readonly Lazy<Playlists::ITrackServiceWithRawResponse> _tracks;
    public Playlists::ITrackServiceWithRawResponse Tracks
    {
        get { return _tracks.Value; }
    }

    readonly Lazy<Playlists::IFollowerServiceWithRawResponse> _followers;
    public Playlists::IFollowerServiceWithRawResponse Followers
    {
        get { return _followers.Value; }
    }

    readonly Lazy<Playlists::IImageServiceWithRawResponse> _images;
    public Playlists::IImageServiceWithRawResponse Images
    {
        get { return _images.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlaylistRetrieveResponse>> Retrieve(
        PlaylistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<PlaylistRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var playlist = await response
                    .Deserialize<PlaylistRetrieveResponse>(token)
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
    public Task<HttpResponse<PlaylistRetrieveResponse>> Retrieve(
        string playlistID,
        PlaylistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        PlaylistUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<PlaylistUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string playlistID,
        PlaylistUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}
