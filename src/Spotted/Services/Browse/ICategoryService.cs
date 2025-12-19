using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models.Browse.Categories;

namespace Spotted.Services.Browse;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICategoryService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a single category used to tag items in Spotify (on, for example, the
    /// Spotify player’s “Browse” tab).
    /// </summary>
    Task<CategoryRetrieveResponse> Retrieve(
        CategoryRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CategoryRetrieveParams, CancellationToken)"/>
    Task<CategoryRetrieveResponse> Retrieve(
        string categoryID,
        CategoryRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of categories used to tag items in Spotify (on, for example, the
    /// Spotify player’s “Browse” tab).
    /// </summary>
    Task<CategoryListPage> List(
        CategoryListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of Spotify playlists tagged with a particular category.
    /// </summary>
    [Obsolete("deprecated")]
    Task<CategoryGetPlaylistsResponse> GetPlaylists(
        CategoryGetPlaylistsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetPlaylists(CategoryGetPlaylistsParams, CancellationToken)"/>
    [Obsolete("deprecated")]
    Task<CategoryGetPlaylistsResponse> GetPlaylists(
        string categoryID,
        CategoryGetPlaylistsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
