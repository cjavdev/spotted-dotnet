using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Player.Queue;

namespace Spotted.Services.Me.Player;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IQueueService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IQueueServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add an item to be played next in the user's current playback queue. This API
    /// only works for users who have Spotify Premium. The order of execution is not
    /// guaranteed when you use this API with other Player API endpoints.
    /// </summary>
    Task Add(QueueAddParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the list of objects that make up the user's queue.
    /// </summary>
    Task<QueueGetResponse> Get(
        QueueGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IQueueService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IQueueServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQueueServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /me/player/queue</c>, but is otherwise the
    /// same as <see cref="IQueueService.Add(QueueAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Add(
        QueueAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /me/player/queue</c>, but is otherwise the
    /// same as <see cref="IQueueService.Get(QueueGetParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<QueueGetResponse>> Get(
        QueueGetParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
