using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Playlists;

[JsonConverter(
    typeof(JsonModelConverter<PlaylistRetrieveResponse, PlaylistRetrieveResponseFromRaw>)
)]
public sealed record class PlaylistRetrieveResponse : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// playlist.
    /// </summary>
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// `true` if the owner allows other users to modify the playlist.
    /// </summary>
    public bool? Collaborative
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "collaborative"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "collaborative", value);
        }
    }

    /// <summary>
    /// The playlist description. _Only returned for modified, verified playlists,
    /// otherwise_ `null`.
    /// </summary>
    public string? Description
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "description"); }
        init { JsonModel.Set(this._rawData, "description", value); }
    }

    /// <summary>
    /// Known external URLs for this playlist.
    /// </summary>
    public ExternalURLObject? ExternalURLs
    {
        get { return JsonModel.GetNullableClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "external_urls", value);
        }
    }

    /// <summary>
    /// Information about the followers of the playlist.
    /// </summary>
    public FollowersObject? Followers
    {
        get { return JsonModel.GetNullableClass<FollowersObject>(this.RawData, "followers"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "followers", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the playlist.
    /// </summary>
    public string? Href
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "href", value);
        }
    }

    /// <summary>
    /// Images for the playlist. The array may be empty or contain up to three images.
    /// The images are returned by size in descending order. See [Working with Playlists](/documentation/web-api/concepts/playlists).
    /// _**Note**: If returned, the source URL for the image (`url`) is temporary
    /// and will expire in less than a day._
    /// </summary>
    public IReadOnlyList<ImageObject>? Images
    {
        get { return JsonModel.GetNullableClass<List<ImageObject>>(this.RawData, "images"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "images", value);
        }
    }

    /// <summary>
    /// The name of the playlist.
    /// </summary>
    public string? Name
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// The user who owns the playlist
    /// </summary>
    public global::Spotted.Models.Playlists.Owner? Owner
    {
        get
        {
            return JsonModel.GetNullableClass<global::Spotted.Models.Playlists.Owner>(
                this.RawData,
                "owner"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "owner", value);
        }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// The version identifier for the current playlist. Can be supplied in other
    /// requests to target a specific playlist version
    /// </summary>
    public string? SnapshotID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "snapshot_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "snapshot_id", value);
        }
    }

    /// <summary>
    /// The tracks of the playlist.
    /// </summary>
    public PlaylistRetrieveResponseTracks? Tracks
    {
        get
        {
            return JsonModel.GetNullableClass<PlaylistRetrieveResponseTracks>(
                this.RawData,
                "tracks"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "tracks", value);
        }
    }

    /// <summary>
    /// The object type: "playlist"
    /// </summary>
    public string? Type
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// playlist.
    /// </summary>
    public string? Uri
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Collaborative;
        _ = this.Description;
        this.ExternalURLs?.Validate();
        this.Followers?.Validate();
        _ = this.Href;
        foreach (var item in this.Images ?? [])
        {
            item.Validate();
        }
        _ = this.Name;
        this.Owner?.Validate();
        _ = this.Published;
        _ = this.SnapshotID;
        this.Tracks?.Validate();
        _ = this.Type;
        _ = this.Uri;
    }

    public PlaylistRetrieveResponse() { }

    public PlaylistRetrieveResponse(PlaylistRetrieveResponse playlistRetrieveResponse)
        : base(playlistRetrieveResponse) { }

    public PlaylistRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaylistRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PlaylistRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaylistRetrieveResponseFromRaw : IFromRawJson<PlaylistRetrieveResponse>
{
    /// <inheritdoc/>
    public PlaylistRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlaylistRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The user who owns the playlist
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Spotted.Models.Playlists.Owner,
        global::Spotted.Models.Playlists.OwnerFromRaw
    >)
)]
public sealed record class Owner : JsonModel
{
    /// <summary>
    /// The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for
    /// this user.
    /// </summary>
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    public ExternalURLObject? ExternalURLs
    {
        get { return JsonModel.GetNullableClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "external_urls", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint for this user.
    /// </summary>
    public string? Href
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "href", value);
        }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public ApiEnum<string, PlaylistUserObjectType>? Type
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, PlaylistUserObjectType>>(
                this.RawData,
                "type"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for this
    /// user.
    /// </summary>
    public string? Uri
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "uri", value);
        }
    }

    /// <summary>
    /// The name displayed on the user's profile. `null` if not available.
    /// </summary>
    public string? DisplayName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "display_name"); }
        init { JsonModel.Set(this._rawData, "display_name", value); }
    }

    public static implicit operator PlaylistUserObject(
        global::Spotted.Models.Playlists.Owner owner
    ) =>
        new()
        {
            ID = owner.ID,
            ExternalURLs = owner.ExternalURLs,
            Href = owner.Href,
            Published = owner.Published,
            Type = owner.Type,
            Uri = owner.Uri,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.ExternalURLs?.Validate();
        _ = this.Href;
        _ = this.Published;
        this.Type?.Validate();
        _ = this.Uri;
        _ = this.DisplayName;
    }

    public Owner() { }

    public Owner(global::Spotted.Models.Playlists.Owner owner)
        : base(owner) { }

    public Owner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Owner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Spotted.Models.Playlists.OwnerFromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Playlists.Owner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OwnerFromRaw : IFromRawJson<global::Spotted.Models.Playlists.Owner>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Playlists.Owner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Playlists.Owner.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Spotted.Models.Playlists.IntersectionMember1,
        global::Spotted.Models.Playlists.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The name displayed on the user's profile. `null` if not available.
    /// </summary>
    public string? DisplayName
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "display_name"); }
        init { JsonModel.Set(this._rawData, "display_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayName;
    }

    public IntersectionMember1() { }

    public IntersectionMember1(
        global::Spotted.Models.Playlists.IntersectionMember1 intersectionMember1
    )
        : base(intersectionMember1) { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Spotted.Models.Playlists.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Playlists.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw
    : IFromRawJson<global::Spotted.Models.Playlists.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Playlists.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Playlists.IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The tracks of the playlist.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        PlaylistRetrieveResponseTracks,
        PlaylistRetrieveResponseTracksFromRaw
    >)
)]
public sealed record class PlaylistRetrieveResponseTracks : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "href"); }
        init { JsonModel.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "limit"); }
        init { JsonModel.Set(this._rawData, "limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "next"); }
        init { JsonModel.Set(this._rawData, "next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "offset"); }
        init { JsonModel.Set(this._rawData, "offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "previous"); }
        init { JsonModel.Set(this._rawData, "previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return JsonModel.GetNotNullStruct<long>(this.RawData, "total"); }
        init { JsonModel.Set(this._rawData, "total", value); }
    }

    public IReadOnlyList<PlaylistTrackObject>? Items
    {
        get { return JsonModel.GetNullableClass<List<PlaylistTrackObject>>(this.RawData, "items"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "items", value);
        }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Href;
        _ = this.Limit;
        _ = this.Next;
        _ = this.Offset;
        _ = this.Previous;
        _ = this.Total;
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
    }

    public PlaylistRetrieveResponseTracks() { }

    public PlaylistRetrieveResponseTracks(
        PlaylistRetrieveResponseTracks playlistRetrieveResponseTracks
    )
        : base(playlistRetrieveResponseTracks) { }

    public PlaylistRetrieveResponseTracks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistRetrieveResponseTracks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaylistRetrieveResponseTracksFromRaw.FromRawUnchecked"/>
    public static PlaylistRetrieveResponseTracks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaylistRetrieveResponseTracksFromRaw : IFromRawJson<PlaylistRetrieveResponseTracks>
{
    /// <inheritdoc/>
    public PlaylistRetrieveResponseTracks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlaylistRetrieveResponseTracks.FromRawUnchecked(rawData);
}
