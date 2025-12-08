using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models;
using Spotted.Models.Playlists.Images;

namespace Spotted.Services.Playlists;

/// <inheritdoc/>
public sealed class ImageService : IImageService
{
    /// <inheritdoc/>
    public IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public ImageService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Update(
        ImageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }
        if (parameters.Body == null)
        {
            throw new SpottedInvalidDataException("'parameters.Body' cannot be null");
        }

        HttpRequest<ImageUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return response;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Update(
        string playlistID,
        string body,
        ImageUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Update(
            parameters with
            {
                PlaylistID = playlistID,
                Body = body,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<List<ImageObject>> List(
        ImageListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PlaylistID == null)
        {
            throw new SpottedInvalidDataException("'parameters.PlaylistID' cannot be null");
        }

        HttpRequest<ImageListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var imageObjects = await response
            .Deserialize<List<ImageObject>>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in imageObjects)
            {
                item.Validate();
            }
        }
        return imageObjects;
    }

    /// <inheritdoc/>
    public async Task<List<ImageObject>> List(
        string playlistID,
        ImageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.List(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}
