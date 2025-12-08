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
    /// <inheritdoc/>
    public IPlaylistService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlaylistService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public PlaylistService(ISpottedClient client)
    {
        _client = client;
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
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<PlaylistRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var playlist = await response
            .Deserialize<PlaylistRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            playlist.Validate();
        }
        return playlist;
    }

    /// <inheritdoc/>
    public async Task<PlaylistRetrieveResponse> Retrieve(
        string playlistID,
        PlaylistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Update(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Update(
        string playlistID,
        PlaylistUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Update(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}
