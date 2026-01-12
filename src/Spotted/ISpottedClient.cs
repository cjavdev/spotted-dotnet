using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Services;

namespace Spotted;

/// <summary>
/// A client for interacting with the Spotted REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface ISpottedClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ClientID { get; init; }

    string? ClientSecret { get; init; }

    string? AccessToken { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpottedClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpottedClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAlbumService Albums { get; }

    IArtistService Artists { get; }

    IShowService Shows { get; }

    IEpisodeService Episodes { get; }

    IAudiobookService Audiobooks { get; }

    IMeService Me { get; }

    IChapterService Chapters { get; }

    ITrackService Tracks { get; }

    ISearchService Search { get; }

    IPlaylistService Playlists { get; }

    IUserService Users { get; }

    IBrowseService Browse { get; }

    IAudioFeatureService AudioFeatures { get; }

    IAudioAnalysisService AudioAnalysis { get; }

    IRecommendationService Recommendations { get; }

    IMarketService Markets { get; }
}

/// <summary>
/// A view of <see cref="ISpottedClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface ISpottedClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string? ClientID { get; init; }

    string? ClientSecret { get; init; }

    string? AccessToken { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpottedClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IAlbumServiceWithRawResponse Albums { get; }

    IArtistServiceWithRawResponse Artists { get; }

    IShowServiceWithRawResponse Shows { get; }

    IEpisodeServiceWithRawResponse Episodes { get; }

    IAudiobookServiceWithRawResponse Audiobooks { get; }

    IMeServiceWithRawResponse Me { get; }

    IChapterServiceWithRawResponse Chapters { get; }

    ITrackServiceWithRawResponse Tracks { get; }

    ISearchServiceWithRawResponse Search { get; }

    IPlaylistServiceWithRawResponse Playlists { get; }

    IUserServiceWithRawResponse Users { get; }

    IBrowseServiceWithRawResponse Browse { get; }

    IAudioFeatureServiceWithRawResponse AudioFeatures { get; }

    IAudioAnalysisServiceWithRawResponse AudioAnalysis { get; }

    IRecommendationServiceWithRawResponse Recommendations { get; }

    IMarketServiceWithRawResponse Markets { get; }

    /// <summary>
    /// Sends a request to the Spotted REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
