using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Me.Shows;

namespace Spotted.Services.Me;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IShowService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    global::Spotted.Services.Me.IShowService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Get a list of shows saved in the current Spotify user's library. Optional
    /// parameters can be used to limit the number of shows returned.
    /// </summary>
    Task<ShowListPageResponse> List(
        ShowListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Check if one or more shows is already saved in the current Spotify user's
    /// library.
    /// </summary>
    Task<List<bool>> Check(
        ShowCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete one or more shows from current Spotify user's library.
    /// </summary>
    Task Remove(ShowRemoveParams? parameters = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Save one or more shows to current Spotify user's library.
    /// </summary>
    Task Save(ShowSaveParams? parameters = null, CancellationToken cancellationToken = default);
}
