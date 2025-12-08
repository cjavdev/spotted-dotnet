using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Following;

namespace Spotted.Services.Me;

/// <inheritdoc/>
public sealed class FollowingService : IFollowingService
{
    /// <inheritdoc/>
    public IFollowingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowingService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public FollowingService(ISpottedClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<FollowingBulkRetrieveResponse> BulkRetrieve(
        FollowingBulkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FollowingBulkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<FollowingBulkRetrieveResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        FollowingCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FollowingCheckParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<List<bool>>(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Follow(
        FollowingFollowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FollowingFollowParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Unfollow(
        FollowingUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FollowingUnfollowParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
    }
}
