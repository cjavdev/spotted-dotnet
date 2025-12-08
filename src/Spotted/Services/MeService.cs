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
    /// <inheritdoc/>
    public IMeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new MeService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public MeService(ISpottedClient client)
    {
        _client = client;
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
        parameters ??= new();

        HttpRequest<MeRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var me = await response
            .Deserialize<MeRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            me.Validate();
        }
        return me;
    }
}
