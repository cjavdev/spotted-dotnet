using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Users.Playlists;

[JsonConverter(typeof(JsonModelConverter<PlaylistCreateResponse, PlaylistCreateResponseFromRaw>))]
public sealed record class PlaylistCreateResponse : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// playlist.
    /// </summary>
    public string? ID
    {
        get { return this._rawData.GetNullableClass<string>("id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// `true` if the owner allows other users to modify the playlist.
    /// </summary>
    public bool? Collaborative
    {
        get { return this._rawData.GetNullableStruct<bool>("collaborative"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("collaborative", value);
        }
    }

    /// <summary>
    /// The playlist description. _Only returned for modified, verified playlists,
    /// otherwise_ `null`.
    /// </summary>
    public string? Description
    {
        get { return this._rawData.GetNullableClass<string>("description"); }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Known external URLs for this playlist.
    /// </summary>
    public ExternalUrlObject? ExternalUrls
    {
        get { return this._rawData.GetNullableClass<ExternalUrlObject>("external_urls"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("external_urls", value);
        }
    }

    /// <summary>
    /// Information about the followers of the playlist.
    /// </summary>
    public FollowersObject? Followers
    {
        get { return this._rawData.GetNullableClass<FollowersObject>("followers"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("followers", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the playlist.
    /// </summary>
    public string? Href
    {
        get { return this._rawData.GetNullableClass<string>("href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("href", value);
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
        get { return this._rawData.GetNullableStruct<ImmutableArray<ImageObject>>("images"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ImageObject>?>(
                "images",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The name of the playlist.
    /// </summary>
    public string? Name
    {
        get { return this._rawData.GetNullableClass<string>("name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The user who owns the playlist
    /// </summary>
    public global::Spotted.Models.Users.Playlists.Owner? Owner
    {
        get
        {
            return this._rawData.GetNullableClass<global::Spotted.Models.Users.Playlists.Owner>(
                "owner"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("owner", value);
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
        get { return this._rawData.GetNullableStruct<bool>("published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <summary>
    /// The version identifier for the current playlist. Can be supplied in other
    /// requests to target a specific playlist version
    /// </summary>
    public string? SnapshotID
    {
        get { return this._rawData.GetNullableClass<string>("snapshot_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("snapshot_id", value);
        }
    }

    /// <summary>
    /// The tracks of the playlist.
    /// </summary>
    public PlaylistCreateResponseTracks? Tracks
    {
        get { return this._rawData.GetNullableClass<PlaylistCreateResponseTracks>("tracks"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tracks", value);
        }
    }

    /// <summary>
    /// The object type: "playlist"
    /// </summary>
    public string? Type
    {
        get { return this._rawData.GetNullableClass<string>("type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// playlist.
    /// </summary>
    public string? Uri
    {
        get { return this._rawData.GetNullableClass<string>("uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Collaborative;
        _ = this.Description;
        this.ExternalUrls?.Validate();
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

    public PlaylistCreateResponse() { }

    public PlaylistCreateResponse(PlaylistCreateResponse playlistCreateResponse)
        : base(playlistCreateResponse) { }

    public PlaylistCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaylistCreateResponseFromRaw.FromRawUnchecked"/>
    public static PlaylistCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaylistCreateResponseFromRaw : IFromRawJson<PlaylistCreateResponse>
{
    /// <inheritdoc/>
    public PlaylistCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlaylistCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The user who owns the playlist
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        global::Spotted.Models.Users.Playlists.Owner,
        global::Spotted.Models.Users.Playlists.OwnerFromRaw
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
        get { return this._rawData.GetNullableClass<string>("id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public ExternalUrlObject? ExternalUrls
    {
        get { return this._rawData.GetNullableClass<ExternalUrlObject>("external_urls"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("external_urls", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint for this user.
    /// </summary>
    public string? Href
    {
        get { return this._rawData.GetNullableClass<string>("href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("href", value);
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
        get { return this._rawData.GetNullableStruct<bool>("published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
        }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public ApiEnum<string, PlaylistUserObjectType>? Type
    {
        get
        {
            return this._rawData.GetNullableClass<ApiEnum<string, PlaylistUserObjectType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for this
    /// user.
    /// </summary>
    public string? Uri
    {
        get { return this._rawData.GetNullableClass<string>("uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <summary>
    /// The name displayed on the user's profile. `null` if not available.
    /// </summary>
    public string? DisplayName
    {
        get { return this._rawData.GetNullableClass<string>("display_name"); }
        init { this._rawData.Set("display_name", value); }
    }

    public static implicit operator PlaylistUserObject(
        global::Spotted.Models.Users.Playlists.Owner owner
    ) =>
        new()
        {
            ID = owner.ID,
            ExternalUrls = owner.ExternalUrls,
            Href = owner.Href,
            Published = owner.Published,
            Type = owner.Type,
            Uri = owner.Uri,
        };

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.ExternalUrls?.Validate();
        _ = this.Href;
        _ = this.Published;
        this.Type?.Validate();
        _ = this.Uri;
        _ = this.DisplayName;
    }

    public Owner() { }

    public Owner(global::Spotted.Models.Users.Playlists.Owner owner)
        : base(owner) { }

    public Owner(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Owner(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Spotted.Models.Users.Playlists.OwnerFromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Users.Playlists.Owner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OwnerFromRaw : IFromRawJson<global::Spotted.Models.Users.Playlists.Owner>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Users.Playlists.Owner FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Users.Playlists.Owner.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        global::Spotted.Models.Users.Playlists.IntersectionMember1,
        global::Spotted.Models.Users.Playlists.IntersectionMember1FromRaw
    >)
)]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The name displayed on the user's profile. `null` if not available.
    /// </summary>
    public string? DisplayName
    {
        get { return this._rawData.GetNullableClass<string>("display_name"); }
        init { this._rawData.Set("display_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayName;
    }

    public IntersectionMember1() { }

    public IntersectionMember1(
        global::Spotted.Models.Users.Playlists.IntersectionMember1 intersectionMember1
    )
        : base(intersectionMember1) { }

    public IntersectionMember1(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="global::Spotted.Models.Users.Playlists.IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static global::Spotted.Models.Users.Playlists.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw
    : IFromRawJson<global::Spotted.Models.Users.Playlists.IntersectionMember1>
{
    /// <inheritdoc/>
    public global::Spotted.Models.Users.Playlists.IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => global::Spotted.Models.Users.Playlists.IntersectionMember1.FromRawUnchecked(rawData);
}

/// <summary>
/// The tracks of the playlist.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<PlaylistCreateResponseTracks, PlaylistCreateResponseTracksFromRaw>)
)]
public sealed record class PlaylistCreateResponseTracks : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint returning the full result of the request
    /// </summary>
    public required string Href
    {
        get { return this._rawData.GetNotNullClass<string>("href"); }
        init { this._rawData.Set("href", value); }
    }

    /// <summary>
    /// The maximum number of items in the response (as set in the query or by default).
    /// </summary>
    public required long Limit
    {
        get { return this._rawData.GetNotNullStruct<long>("limit"); }
        init { this._rawData.Set("limit", value); }
    }

    /// <summary>
    /// URL to the next page of items. ( `null` if none)
    /// </summary>
    public required string? Next
    {
        get { return this._rawData.GetNullableClass<string>("next"); }
        init { this._rawData.Set("next", value); }
    }

    /// <summary>
    /// The offset of the items returned (as set in the query or by default)
    /// </summary>
    public required long Offset
    {
        get { return this._rawData.GetNotNullStruct<long>("offset"); }
        init { this._rawData.Set("offset", value); }
    }

    /// <summary>
    /// URL to the previous page of items. ( `null` if none)
    /// </summary>
    public required string? Previous
    {
        get { return this._rawData.GetNullableClass<string>("previous"); }
        init { this._rawData.Set("previous", value); }
    }

    /// <summary>
    /// The total number of items available to return.
    /// </summary>
    public required long Total
    {
        get { return this._rawData.GetNotNullStruct<long>("total"); }
        init { this._rawData.Set("total", value); }
    }

    public IReadOnlyList<PlaylistTrackObject>? Items
    {
        get
        {
            return this._rawData.GetNullableStruct<ImmutableArray<PlaylistTrackObject>>("items");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<PlaylistTrackObject>?>(
                "items",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
        get { return this._rawData.GetNullableStruct<bool>("published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("published", value);
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

    public PlaylistCreateResponseTracks() { }

    public PlaylistCreateResponseTracks(PlaylistCreateResponseTracks playlistCreateResponseTracks)
        : base(playlistCreateResponseTracks) { }

    public PlaylistCreateResponseTracks(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistCreateResponseTracks(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaylistCreateResponseTracksFromRaw.FromRawUnchecked"/>
    public static PlaylistCreateResponseTracks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaylistCreateResponseTracksFromRaw : IFromRawJson<PlaylistCreateResponseTracks>
{
    /// <inheritdoc/>
    public PlaylistCreateResponseTracks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlaylistCreateResponseTracks.FromRawUnchecked(rawData);
}
