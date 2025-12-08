using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Chapters;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class ChapterService : IChapterService
{
    /// <inheritdoc/>
    public IChapterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChapterService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public ChapterService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ChapterRetrieveResponse> Retrieve(
        ChapterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ChapterRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var chapter = await response
            .Deserialize<ChapterRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            chapter.Validate();
        }
        return chapter;
    }

    /// <inheritdoc/>
    public async Task<ChapterRetrieveResponse> Retrieve(
        string id,
        ChapterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChapterBulkRetrieveResponse> BulkRetrieve(
        ChapterBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ChapterBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ChapterBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
