using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Shows;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class ShowService : IShowService
{
    /// <inheritdoc/>
    public IShowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ShowService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public ShowService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<ShowRetrieveResponse> Retrieve(
        ShowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ShowRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var show = await response
            .Deserialize<ShowRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            show.Validate();
        }
        return show;
    }

    /// <inheritdoc/>
    public async Task<ShowRetrieveResponse> Retrieve(
        string id,
        ShowRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ShowBulkRetrieveResponse> BulkRetrieve(
        ShowBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ShowBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<ShowBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<ShowListEpisodesPageResponse> ListEpisodes(
        ShowListEpisodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new SpottedInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ShowListEpisodesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<ShowListEpisodesPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    public async Task<ShowListEpisodesPageResponse> ListEpisodes(
        string id,
        ShowListEpisodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.ListEpisodes(parameters with { ID = id }, cancellationToken);
    }
}
