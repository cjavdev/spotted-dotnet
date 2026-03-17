using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me;
using Me = Spotted.Services.Me;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Me::IAudiobookService Audiobooks { get; }

    Me::IPlaylistService Playlists { get; }

    Me::ITopService Top { get; }

    Me::IAlbumService Albums { get; }

    Me::ITrackService Tracks { get; }

    Me::IEpisodeService Episodes { get; }

    Me::IShowService Shows { get; }

    Me::IFollowingService Following { get; }

    Me::IPlayerService Player { get; }

    /// <summary>
    /// Get detailed profile information about the current user (including the current
    /// user's username).
    /// </summary>
    Task<MeRetrieveResponse> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IMeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Me::IAudiobookServiceWithRawResponse Audiobooks { get; }

    Me::IPlaylistServiceWithRawResponse Playlists { get; }

    Me::ITopServiceWithRawResponse Top { get; }

    Me::IAlbumServiceWithRawResponse Albums { get; }

    Me::ITrackServiceWithRawResponse Tracks { get; }

    Me::IEpisodeServiceWithRawResponse Episodes { get; }

    Me::IShowServiceWithRawResponse Shows { get; }

    Me::IFollowingServiceWithRawResponse Following { get; }

    Me::IPlayerServiceWithRawResponse Player { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /me</c>, but is otherwise the
    /// same as <see cref="IMeService.Retrieve(MeRetrieveParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<MeRetrieveResponse>> Retrieve(
        MeRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
