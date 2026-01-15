using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Users;
using Users = Spotted.Services.Users;

namespace Spotted.Services;

/// <inheritdoc/>
public sealed class UserService : IUserService
{
    readonly Lazy<IUserServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly ISpottedClient _client;

    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    public UserService(ISpottedClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UserServiceWithRawResponse(client.WithRawResponse));
        _playlists = new(() => new Users::PlaylistService(client));
    }

    readonly Lazy<Users::IPlaylistService> _playlists;
    public Users::IPlaylistService Playlists
    {
        get { return _playlists.Value; }
    }

    /// <inheritdoc/>
    public async Task<UserRetrieveProfileResponse> RetrieveProfile(
        UserRetrieveProfileParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveProfile(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UserRetrieveProfileResponse> RetrieveProfile(
        string userID,
        UserRetrieveProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveProfile(parameters with { UserID = userID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class UserServiceWithRawResponse : IUserServiceWithRawResponse
{
    readonly ISpottedClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUserServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UserServiceWithRawResponse(ISpottedClientWithRawResponse client)
    {
        _client = client;

        _playlists = new(() => new Users::PlaylistServiceWithRawResponse(client));
    }

    readonly Lazy<Users::IPlaylistServiceWithRawResponse> _playlists;
    public Users::IPlaylistServiceWithRawResponse Playlists
    {
        get { return _playlists.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UserRetrieveProfileResponse>> RetrieveProfile(
        UserRetrieveProfileParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UserID == null)
        {
            throw new SpottedInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<UserRetrieveProfileParams> request = new()
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
                    .Deserialize<UserRetrieveProfileResponse>(token)
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
    public Task<HttpResponse<UserRetrieveProfileResponse>> RetrieveProfile(
        string userID,
        UserRetrieveProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveProfile(parameters with { UserID = userID }, cancellationToken);
    }
}
