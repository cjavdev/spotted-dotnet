using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Audiobooks;

namespace Spotted.Services.Me;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAudiobookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    global::Spotted.Services.Me.IAudiobookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Spotted.Services.Me.IAudiobookService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Get a list of the audiobooks saved in the current Spotify user's 'Your Music' library.
    /// </summary>
    Task<AudiobookListPage> List(
        AudiobookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check if one or more audiobooks are already saved in the current Spotify user's library.
    /// </summary>
    Task<List<bool>> Check(
        AudiobookCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one or more audiobooks from the Spotify user's library.
    /// </summary>
    Task Remove(AudiobookRemoveParams parameters, CancellationToken cancellationToken = default);

    /// <summary>
    /// Save one or more audiobooks to the current Spotify user's library.
    /// </summary>
    Task Save(AudiobookSaveParams parameters, CancellationToken cancellationToken = default);
}

/// <summary>
/// A view of <see cref="global::Spotted.Services.Me.IAudiobookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAudiobookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Spotted.Services.Me.IAudiobookServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /me/audiobooks`, but is otherwise the
    /// same as <see cref="global::Spotted.Services.Me.IAudiobookService.List(AudiobookListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AudiobookListPage>> List(
        AudiobookListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /me/audiobooks/contains`, but is otherwise the
    /// same as <see cref="global::Spotted.Services.Me.IAudiobookService.Check(AudiobookCheckParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<List<bool>>> Check(
        AudiobookCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /me/audiobooks`, but is otherwise the
    /// same as <see cref="global::Spotted.Services.Me.IAudiobookService.Remove(AudiobookRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Remove(
        AudiobookRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `put /me/audiobooks`, but is otherwise the
    /// same as <see cref="global::Spotted.Services.Me.IAudiobookService.Save(AudiobookSaveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Save(
        AudiobookSaveParams parameters,
        CancellationToken cancellationToken = default
    );
}
