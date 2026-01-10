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
    readonly Lazy<ICategoryServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICategoryServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public ICategoryService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CategoryService(this._client.WithOptions(modifier));
    }

    public CategoryService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CategoryServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CategoryRetrieveResponse> Retrieve(
        CategoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CategoryRetrieveResponse> Retrieve(
        string categoryID,
        CategoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CategoryID = categoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CategoryListPage> List(
        CategoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<CategoryGetPlaylistsResponse> GetPlaylists(
        CategoryGetPlaylistsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetPlaylists(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public Task<CategoryGetPlaylistsResponse> GetPlaylists(
        string categoryID,
        CategoryGetPlaylistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetPlaylists(parameters with { CategoryID = categoryID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CategoryServiceWithRawResponse : ICategoryServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICategoryServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CategoryServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CategoryServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CategoryRetrieveResponse>> Retrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var category = await response
                    .Deserialize<CategoryRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    category.Validate();
                }
                return category;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CategoryRetrieveResponse>> Retrieve(
        string categoryID,
        CategoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CategoryID = categoryID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CategoryListPage>> List(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<CategoryListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CategoryListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<CategoryGetPlaylistsResponse>> GetPlaylists(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<CategoryGetPlaylistsResponse>(token)
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
    public Task<HttpResponse<CategoryGetPlaylistsResponse>> GetPlaylists(
        string categoryID,
        CategoryGetPlaylistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetPlaylists(parameters with { CategoryID = categoryID }, cancellationToken);
    }
}
