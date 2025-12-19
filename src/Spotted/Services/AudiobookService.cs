using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Audiobooks;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class AudiobookService : IAudiobookService
{
    /// <inheritdoc/>
    public IAudiobookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AudiobookService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public AudiobookService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<AudiobookRetrieveResponse> Retrieve(
        AudiobookRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AudiobookRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var audiobook = await response
            .Deserialize<AudiobookRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            audiobook.Validate();
        }
        return audiobook;
    }

    /// <inheritdoc/>
    public async Task<AudiobookRetrieveResponse> Retrieve(
        string id,
        AudiobookRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AudiobookBulkRetrieveResponse> BulkRetrieve(
        AudiobookBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AudiobookBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<AudiobookBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<AudiobookListChaptersPage> ListChapters(
        AudiobookListChaptersParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AudiobookListChaptersParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<AudiobookListChaptersPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new AudiobookListChaptersPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task<AudiobookListChaptersPage> ListChapters(
        string id,
        AudiobookListChaptersParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListChapters(parameters with { ID = id }, cancellationToken);
    }
}
