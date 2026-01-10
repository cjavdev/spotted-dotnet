using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me;
using Me = Spotted.Services.Me;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class MeService : IMeService
{
    readonly Lazy<IMeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IMeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IMeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MeService(this._client.WithOptions(modifier));
    }

    public MeService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new MeServiceWithRawResponse(client.WithRawResponse));
        _audiobooks = new(() => new Me::AudiobookService(client));
        _playlists = new(() => new Me::PlaylistService(client));
        _top = new(() => new Me::TopService(client));
        _albums = new(() => new Me::AlbumService(client));
        _tracks = new(() => new Me::TrackService(client));
        _episodes = new(() => new Me::EpisodeService(client));
        _shows = new(() => new Me::ShowService(client));
        _following = new(() => new Me::FollowingService(client));
        _player = new(() => new Me::PlayerService(client));
    }

    readonly Lazy<Me::IAudiobookService> _audiobooks;
    public Me::IAudiobookService Audiobooks
    {
        get { return _audiobooks.Value; }
    }

    readonly Lazy<Me::IPlaylistService> _playlists;
    public Me::IPlaylistService Playlists
    {
        get { return _playlists.Value; }
    }

    readonly Lazy<Me::ITopService> _top;
    public Me::ITopService Top
    {
        get { return _top.Value; }
    }

    readonly Lazy<Me::IAlbumService> _albums;
    public Me::IAlbumService Albums
    {
        get { return _albums.Value; }
    }

    readonly Lazy<Me::ITrackService> _tracks;
    public Me::ITrackService Tracks
    {
        get { return _tracks.Value; }
    }

    readonly Lazy<Me::IEpisodeService> _episodes;
    public Me::IEpisodeService Episodes
    {
        get { return _episodes.Value; }
    }

    readonly Lazy<Me::IShowService> _shows;
    public Me::IShowService Shows
    {
        get { return _shows.Value; }
    }

    readonly Lazy<Me::IFollowingService> _following;
    public Me::IFollowingService Following
    {
        get { return _following.Value; }
    }

    readonly Lazy<Me::IPlayerService> _player;
    public Me::IPlayerService Player
    {
        get { return _player.Value; }
    }

    /// <inheritdoc/>
    public async Task<MeRetrieveResponse> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class MeServiceWithRawResponse : IMeServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IMeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public MeServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;

        _audiobooks = new(() => new Me::AudiobookServiceWithRawResponse(client));
        _playlists = new(() => new Me::PlaylistServiceWithRawResponse(client));
        _top = new(() => new Me::TopServiceWithRawResponse(client));
        _albums = new(() => new Me::AlbumServiceWithRawResponse(client));
        _tracks = new(() => new Me::TrackServiceWithRawResponse(client));
        _episodes = new(() => new Me::EpisodeServiceWithRawResponse(client));
        _shows = new(() => new Me::ShowServiceWithRawResponse(client));
        _following = new(() => new Me::FollowingServiceWithRawResponse(client));
        _player = new(() => new Me::PlayerServiceWithRawResponse(client));
    }

    readonly Lazy<Me::IAudiobookServiceWithRawResponse> _audiobooks;
    public Me::IAudiobookServiceWithRawResponse Audiobooks
    {
        get { return _audiobooks.Value; }
    }

    readonly Lazy<Me::IPlaylistServiceWithRawResponse> _playlists;
    public Me::IPlaylistServiceWithRawResponse Playlists
    {
        get { return _playlists.Value; }
    }

    readonly Lazy<Me::ITopServiceWithRawResponse> _top;
    public Me::ITopServiceWithRawResponse Top
    {
        get { return _top.Value; }
    }

    readonly Lazy<Me::IAlbumServiceWithRawResponse> _albums;
    public Me::IAlbumServiceWithRawResponse Albums
    {
        get { return _albums.Value; }
    }

    readonly Lazy<Me::ITrackServiceWithRawResponse> _tracks;
    public Me::ITrackServiceWithRawResponse Tracks
    {
        get { return _tracks.Value; }
    }

    readonly Lazy<Me::IEpisodeServiceWithRawResponse> _episodes;
    public Me::IEpisodeServiceWithRawResponse Episodes
    {
        get { return _episodes.Value; }
    }

    readonly Lazy<Me::IShowServiceWithRawResponse> _shows;
    public Me::IShowServiceWithRawResponse Shows
    {
        get { return _shows.Value; }
    }

    readonly Lazy<Me::IFollowingServiceWithRawResponse> _following;
    public Me::IFollowingServiceWithRawResponse Following
    {
        get { return _following.Value; }
    }

    readonly Lazy<Me::IPlayerServiceWithRawResponse> _player;
    public Me::IPlayerServiceWithRawResponse Player
    {
        get { return _player.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<MeRetrieveResponse>> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<MeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var me = await response
                    .Deserialize<MeRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    me.Validate();
                }
                return me;
            }
        );
    }
}
