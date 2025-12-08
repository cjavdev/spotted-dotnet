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
    /// <inheritdoc/>
    public IArtistService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ArtistService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public ArtistService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ArtistObject> Retrieve(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var artistObject = await response
            .Deserialize<ArtistObject>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            artistObject.Validate();
        }
        return artistObject;
    }

    /// <inheritdoc/>
    public async Task<ArtistObject> Retrieve(
        string id,
        ArtistRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ArtistBulkRetrieveResponse> BulkRetrieve(
        ArtistBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ArtistBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ArtistBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<ArtistListAlbumsPageResponse> ListAlbums(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<ArtistListAlbumsPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<ArtistListAlbumsPageResponse> ListAlbums(
        string id,
        ArtistListAlbumsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListAlbums(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ArtistListRelatedArtistsResponse> ListRelatedArtists(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ArtistListRelatedArtistsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<ArtistListRelatedArtistsResponse> ListRelatedArtists(
        string id,
        ArtistListRelatedArtistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListRelatedArtists(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ArtistTopTracksResponse> TopTracks(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ArtistTopTracksResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<ArtistTopTracksResponse> TopTracks(
        string id,
        ArtistTopTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.TopTracks(parameters with { ID = id }, cancellationToken);
    }
}
