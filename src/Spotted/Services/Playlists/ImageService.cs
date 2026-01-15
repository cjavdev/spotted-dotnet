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
    readonly Lazy<IImageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IImageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageService(this._client.WithOptions(modifier));
    }

    public ImageService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ImageServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        ImageUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Update(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string playlistID,
        BinaryContent body,
        ImageUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
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
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<List<ImageObject>> List(
        string playlistID,
        ImageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ImageServiceWithRawResponse : IImageServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IImageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ImageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ImageServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
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
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Update(
        string playlistID,
        BinaryContent body,
        ImageUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(
            parameters with
            {
                PlaylistID = playlistID,
                Body = body,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<ImageObject>>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var imageObjects = await response
                    .Deserialize<List<ImageObject>>(token)
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
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<List<ImageObject>>> List(
        string playlistID,
        ImageListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { PlaylistID = playlistID }, cancellationToken);
    }
}
