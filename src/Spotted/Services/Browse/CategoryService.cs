using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Browse.Categories;

namespace Spotted.Services.Browse;

/// <inheritdoc/>
public sealed class CategoryService : ICategoryService
{
    /// <inheritdoc/>
    public ICategoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CategoryService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public CategoryService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<CategoryRetrieveResponse> Retrieve(
        CategoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CategoryID == null)
        {
            throw new SpottedInvalidDataException("'parameters.CategoryID' cannot be null");
        }

        HttpRequest<CategoryRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var category = await response
            .Deserialize<CategoryRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            category.Validate();
        }
        return category;
    }

    /// <inheritdoc/>
    public async Task<CategoryRetrieveResponse> Retrieve(
        string categoryID,
        CategoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.Retrieve(parameters with { CategoryID = categoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CategoryListPageResponse> List(
        CategoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CategoryListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<CategoryListPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return page;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<CategoryGetPlaylistsResponse> GetPlaylists(
        CategoryGetPlaylistsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CategoryID == null)
        {
            throw new SpottedInvalidDataException("'parameters.CategoryID' cannot be null");
        }

        HttpRequest<CategoryGetPlaylistsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<CategoryGetPlaylistsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<CategoryGetPlaylistsResponse> GetPlaylists(
        string categoryID,
        CategoryGetPlaylistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.GetPlaylists(
            parameters with
            {
                CategoryID = categoryID,
            },
            cancellationToken
        );
    }
}
