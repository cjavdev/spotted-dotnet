using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Playlists.Tracks;

namespace Spotted.Services.Playlists;

/// <inheritdoc/>
public sealed class TrackService : global::Spotted.Services.Playlists.ITrackService
{
    /// <inheritdoc/>
    public global::Spotted.Services.Playlists.ITrackService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Playlists.TrackService(
            this._client.WithOptions(modifier)
        );
    }

    readonly ISpottedClient _client;

    public TrackService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<TrackUpdateResponse> Update(
        TrackUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<TrackUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var track = await response
            .Deserialize<TrackUpdateResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            track.Validate();
        }
        return track;
    }

    /// <inheritdoc/>
    public async Task<TrackUpdateResponse> Update(
        string playlistID,
        TrackUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrackListPage> List(
        TrackListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<TrackListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<TrackListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new TrackListPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task<TrackListPage> List(
        string playlistID,
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrackAddResponse> Add(
        TrackAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<TrackAddParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<TrackAddResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<TrackAddResponse> Add(
        string playlistID,
        TrackAddParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Add(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrackRemoveResponse> Remove(
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<TrackRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var track = await response
            .Deserialize<TrackRemoveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            track.Validate();
        }
        return track;
    }

    /// <inheritdoc/>
    public async Task<TrackRemoveResponse> Remove(
        string playlistID,
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return await this.Remove(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}
