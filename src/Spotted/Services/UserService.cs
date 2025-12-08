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
    /// <inheritdoc/>
    public IUserService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UserService(this._client.WithOptions(modifier));
    }

    readonly ISpottedClient _client;

    public UserService(ISpottedClient client)
    {
        _client = client;
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
        if (parameters.UserID == null)
        {
            throw new SpottedInvalidDataException("'parameters.UserID' cannot be null");
        }

        HttpRequest<UserRetrieveProfileParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        var deserializedResponse = await response
            .Deserialize<UserRetrieveProfileResponse>(cancellationToken)
            .ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            deserializedResponse.Validate();
        }
        return deserializedResponse;
    }

    /// <inheritdoc/>
    public async Task<UserRetrieveProfileResponse> RetrieveProfile(
        string userID,
        UserRetrieveProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return await this.RetrieveProfile(parameters with { UserID = userID }, cancellationToken);
    }
}
