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
    /// <inheritdoc/>
    public IBrowseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrowseService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public BrowseService(ISpottedClient client)
    {
        _client = client;
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
        parameters ??= new();

        HttpRequest<BrowseGetFeaturedPlaylistsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BrowseGetFeaturedPlaylistsResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<BrowseGetNewReleasesResponse> GetNewReleases(
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
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<BrowseGetNewReleasesResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }
}
