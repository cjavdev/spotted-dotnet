using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Playlists.Images;

namespace Spotted.Services.Playlists;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IImageService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IImageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Replace the image used to represent a specific playlist.
    /// </summary>
    Task<HttpResponse> Update(
        ImageUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ImageUpdateParams, CancellationToken)"/>
    Task<HttpResponse> Update(
        string playlistID,
        BinaryContent body,
        ImageUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the current image associated with a specific playlist.
    /// </summary>
    Task<List<ImageObject>> List(
        ImageListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ImageListParams, CancellationToken)"/>
    Task<List<ImageObject>> List(
        string playlistID,
        ImageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
