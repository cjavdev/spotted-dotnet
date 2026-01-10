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
    readonly Lazy<global::Spotted.Services.Playlists.ITrackServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public global::Spotted.Services.Playlists.ITrackServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public global::Spotted.Services.Playlists.ITrackService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Playlists.TrackService(
            this._client.WithOptions(modifier)
        );
    }

    public TrackService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new global::Spotted.Services.Playlists.TrackServiceWithRawResponse(
                client.WithRawResponse
            )
        );
    }

    /// <inheritdoc/>
    public async Task<TrackUpdateResponse> Update(
        TrackUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TrackUpdateResponse> Update(
        string playlistID,
        TrackUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrackListPage> List(
        TrackListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TrackListPage> List(
        string playlistID,
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrackAddResponse> Add(
        TrackAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TrackAddResponse> Add(
        string playlistID,
        TrackAddParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Add(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TrackRemoveResponse> Remove(
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Remove(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TrackRemoveResponse> Remove(
        string playlistID,
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TrackServiceWithRawResponse
    : global::Spotted.Services.Playlists.ITrackServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public global::Spotted.Services.Playlists.ITrackServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new global::Spotted.Services.Playlists.TrackServiceWithRawResponse(
            this._client.WithOptions(modifier)
        );
    }

    public TrackServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrackUpdateResponse>> Update(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var track = await response
                    .Deserialize<TrackUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    track.Validate();
                }
                return track;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TrackUpdateResponse>> Update(
        string playlistID,
        TrackUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrackListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<TrackListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TrackListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TrackListPage>> List(
        string playlistID,
        TrackListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrackAddResponse>> Add(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<TrackAddResponse>(token)
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
    public Task<HttpResponse<TrackAddResponse>> Add(
        string playlistID,
        TrackAddParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Add(parameters with { PlaylistID = playlistID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TrackRemoveResponse>> Remove(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var track = await response
                    .Deserialize<TrackRemoveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    track.Validate();
                }
                return track;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TrackRemoveResponse>> Remove(
        string playlistID,
        TrackRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}
