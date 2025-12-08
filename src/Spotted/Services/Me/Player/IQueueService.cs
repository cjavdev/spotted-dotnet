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
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add an item to be played next in the user's current playback queue. This
    /// API only works for users who have Spotify Premium. The order of execution
    /// is not guaranteed when you use this API with other Player API endpoints.
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
