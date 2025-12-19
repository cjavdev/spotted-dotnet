using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Albums;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class AlbumService : IAlbumService
{
    /// <inheritdoc/>
    public IAlbumService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AlbumService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public AlbumService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<AlbumRetrieveResponse> Retrieve(
        AlbumRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AlbumRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var album = await response
            .Deserialize<AlbumRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            album.Validate();
        }
        return album;
    }

    /// <inheritdoc/>
    public async Task<AlbumRetrieveResponse> Retrieve(
        string id,
        AlbumRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AlbumBulkRetrieveResponse> BulkRetrieve(
        AlbumBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AlbumBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AlbumBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<AlbumListTracksPage> ListTracks(
        AlbumListTracksParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AlbumListTracksParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<AlbumListTracksPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new AlbumListTracksPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task<AlbumListTracksPage> ListTracks(
        string id,
        AlbumListTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListTracks(parameters with { ID = id }, cancellationToken);
    }
}
