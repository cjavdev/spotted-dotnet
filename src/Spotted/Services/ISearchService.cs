using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Search;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISearchService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISearchService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information about albums, artists, playlists, tracks,
    /// shows, episodes or audiobooks that match a keyword string. Audiobooks are
    /// only available within the US, UK, Canada, Ireland, New Zealand and Australia
    /// markets.
    /// </summary>
    Task<SearchQueryResponse> Query(
        SearchQueryParams parameters,
        CancellationToken cancellationToken = default
    );
}
