using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Browse;
using Spotted.Services.Browse;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class BrowseService : IBrowseService
{
    readonly Lazy<IBrowseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBrowseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IBrowseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrowseService(this._client.WithOptions(modifier));
    }

    public BrowseService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BrowseServiceWithRawResponse(client.WithRawResponse));
        _categories = new(() => new CategoryService(client));
    }

    readonly Lazy<ICategoryService> _categories;
    public ICategoryService Categories
    {
        get { return _categories.Value; }
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<BrowseGetFeaturedPlaylistsResponse> GetFeaturedPlaylists(
        BrowseGetFeaturedPlaylistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetFeaturedPlaylists(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<BrowseGetNewReleasesResponse> GetNewReleases(
        BrowseGetNewReleasesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetNewReleases(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BrowseServiceWithRawResponse : IBrowseServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBrowseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrowseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BrowseServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;

        _categories = new(() => new CategoryServiceWithRawResponse(client));
    }

    readonly Lazy<ICategoryServiceWithRawResponse> _categories;
    public ICategoryServiceWithRawResponse Categories
    {
        get { return _categories.Value; }
    }

    /// <inheritdoc/>
    [Obsolete("deprecated")]
    public async Task<HttpResponse<BrowseGetFeaturedPlaylistsResponse>> GetFeaturedPlaylists(
        BrowseGetFeaturedPlaylistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BrowseGetFeaturedPlaylistsParams> request = new()
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
                    .Deserialize<BrowseGetFeaturedPlaylistsResponse>(token)
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
    public async Task<HttpResponse<BrowseGetNewReleasesResponse>> GetNewReleases(
        BrowseGetNewReleasesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BrowseGetNewReleasesParams> request = new()
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
                    .Deserialize<BrowseGetNewReleasesResponse>(token)
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
