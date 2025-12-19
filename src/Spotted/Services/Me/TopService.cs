using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Top;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class TopService : ITopService
{
    /// <inheritdoc/>
    public ITopService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TopService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public TopService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<TopListTopArtistsPage> ListTopArtists(
        TopListTopArtistsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TopListTopArtistsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<TopListTopArtistsPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new TopListTopArtistsPage(this, parameters, page);
    }

    /// <inheritdoc/>
    public async Task<TopListTopTracksPage> ListTopTracks(
        TopListTopTracksParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TopListTopTracksParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var page = await response
            .Deserialize<TopListTopTracksPageResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            page.Validate();
        }
        return new TopListTopTracksPage(this, parameters, page);
    }
}
