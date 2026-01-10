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
    readonly Lazy<IChapterServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChapterServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IChapterService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChapterService(this._client.WithOptions(modifier));
    }

    public ChapterService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChapterServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ChapterRetrieveResponse> Retrieve(
        ChapterRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChapterRetrieveResponse> Retrieve(
        string id,
        ChapterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChapterBulkRetrieveResponse> BulkRetrieve(
        ChapterBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.BulkRetrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ChapterServiceWithRawResponse : IChapterServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChapterServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChapterServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChapterServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChapterRetrieveResponse>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var chapter = await response
                    .Deserialize<ChapterRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    chapter.Validate();
                }
                return chapter;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChapterRetrieveResponse>> Retrieve(
        string id,
        ChapterRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChapterBulkRetrieveResponse>> BulkRetrieve(
        ChapterBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ChapterBulkRetrieveParams> request = new()
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
                    .Deserialize<ChapterBulkRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
