using System;
using System.Threading;
using System.Threading.Tasks;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Tracks;

namespace Spotted.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITrackService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITrackServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrackService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get Spotify catalog information for a single track identified by its unique
    /// Spotify ID.
    /// </summary>
    Task<TrackObject> Retrieve(
        TrackRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TrackRetrieveParams, CancellationToken)"/>
    Task<TrackObject> Retrieve(
        string id,
        TrackRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Spotify catalog information for multiple tracks based on their Spotify IDs.
    /// </summary>
    [Obsolete("deprecated")]
    Task<TrackBulkRetrieveResponse> BulkRetrieve(
        TrackBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITrackService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITrackServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITrackServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /tracks/{id}`, but is otherwise the
    /// same as <see cref="ITrackService.Retrieve(TrackRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TrackObject>> Retrieve(
        TrackRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(TrackRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<TrackObject>> Retrieve(
        string id,
        TrackRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /tracks`, but is otherwise the
    /// same as <see cref="ITrackService.BulkRetrieve(TrackBulkRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("deprecated")]
    Task<HttpResponse<TrackBulkRetrieveResponse>> BulkRetrieve(
        TrackBulkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
