using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models;
using Spotted.Models.Artists;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class ArtistService : IArtistService
{
    readonly Lazy<IArtistServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IArtistServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IArtistService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ArtistService(this._client.WithOptions(modifier));
    }

    public ArtistService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ArtistServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ArtistObject> Retrieve(
        ArtistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ArtistObject> Retrieve(
        string id,
        ArtistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ArtistBulkRetrieveResponse> BulkRetrieve(
        ArtistBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.BulkRetrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ArtistListAlbumsPage> ListAlbums(
        ArtistListAlbumsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAlbums(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ArtistListAlbumsPage> ListAlbums(
        string id,
        ArtistListAlbumsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAlbums(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ArtistListRelatedArtistsResponse> ListRelatedArtists(
        ArtistListRelatedArtistsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListRelatedArtists(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<ArtistListRelatedArtistsResponse> ListRelatedArtists(
        string id,
        ArtistListRelatedArtistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRelatedArtists(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ArtistTopTracksResponse> TopTracks(
        ArtistTopTracksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TopTracks(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<ArtistTopTracksResponse> TopTracks(
        string id,
        ArtistTopTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TopTracks(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ArtistServiceWithRawResponse : IArtistServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IArtistServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ArtistServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ArtistServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ArtistObject>> Retrieve(
        ArtistRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ArtistRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var artistObject = await response
                    .Deserialize<ArtistObject>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    artistObject.Validate();
                }
                return artistObject;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ArtistObject>> Retrieve(
        string id,
        ArtistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<ArtistBulkRetrieveResponse>> BulkRetrieve(
        ArtistBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ArtistBulkRetrieveParams> request = new()
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
                    .Deserialize<ArtistBulkRetrieveResponse>(token)
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
    public async Task<HttpResponse<ArtistListAlbumsPage>> ListAlbums(
        ArtistListAlbumsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ArtistListAlbumsParams> request = new()
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
                    .Deserialize<ArtistListAlbumsPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ArtistListAlbumsPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ArtistListAlbumsPage>> ListAlbums(
        string id,
        ArtistListAlbumsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListAlbums(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<ArtistListRelatedArtistsResponse>> ListRelatedArtists(
        ArtistListRelatedArtistsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ArtistListRelatedArtistsParams> request = new()
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
                    .Deserialize<ArtistListRelatedArtistsResponse>(token)
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
    [Obsolete("deprecated")]
    public Task<HttpResponse<ArtistListRelatedArtistsResponse>> ListRelatedArtists(
        string id,
        ArtistListRelatedArtistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRelatedArtists(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<ArtistTopTracksResponse>> TopTracks(
        ArtistTopTracksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ArtistTopTracksParams> request = new()
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
                    .Deserialize<ArtistTopTracksResponse>(token)
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
    [Obsolete("deprecated")]
    public Task<HttpResponse<ArtistTopTracksResponse>> TopTracks(
        string id,
        ArtistTopTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TopTracks(parameters with { ID = id }, cancellationToken);
    }
}
