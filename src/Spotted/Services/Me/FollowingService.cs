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
    readonly Lazy<IFollowingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFollowingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IFollowingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowingService(this._client.WithOptions(modifier));
    }

    public FollowingService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FollowingServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FollowingBulkRetrieveResponse> BulkRetrieve(
        FollowingBulkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.BulkRetrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<List<bool>> Check(
        FollowingCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Check(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Follow(
        FollowingFollowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Follow(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task Unfollow(
        FollowingUnfollowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unfollow(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class FollowingServiceWithRawResponse : IFollowingServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFollowingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FollowingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FollowingServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FollowingBulkRetrieveResponse>> BulkRetrieve(
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
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<FollowingBulkRetrieveResponse>(token)
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
    public async Task<HttpResponse<List<bool>>> Check(
        FollowingCheckParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FollowingCheckParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<List<bool>>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Follow(
        FollowingFollowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FollowingFollowParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unfollow(
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
        return this._client.Execute(request, cancellationToken);
    }
}
