using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(
    typeof(JsonModelConverter<SimplifiedPlaylistObject, SimplifiedPlaylistObjectFromRaw>)
)]
public sealed record class SimplifiedPlaylistObject : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// playlist.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("collaborative");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Known external URLs for this playlist.
    /// </summary>
    public ExternalUrlObject? ExternalUrls
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalUrlObject>("external_urls");
        }
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
    /// A link to the Web API endpoint providing full details of the playlist.
    /// </summary>
    public string? Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("href");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ImageObject>>("images");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
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
    public Owner? Owner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Owner>("owner");
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("snapshot_id");
        }
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
    /// A collection containing a link ( `href` ) to the Web API endpoint where full
    /// details of the playlist's tracks can be retrieved, along with the `total`
    /// number of tracks in the playlist. Note, a track object may be `null`. This
    /// can happen if a track is no longer available.
    /// </summary>
    public PlaylistTracksRefObject? Tracks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PlaylistTracksRefObject>("tracks");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("type");
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
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// playlist.
    /// </summary>
    public string? Uri
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
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

    public SimplifiedPlaylistObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimplifiedPlaylistObject(SimplifiedPlaylistObject simplifiedPlaylistObject)
        : base(simplifiedPlaylistObject) { }
#pragma warning restore CS8618

    public SimplifiedPlaylistObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SimplifiedPlaylistObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SimplifiedPlaylistObjectFromRaw.FromRawUnchecked"/>
    public static SimplifiedPlaylistObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SimplifiedPlaylistObjectFromRaw : IFromRawJson<SimplifiedPlaylistObject>
{
    /// <inheritdoc/>
    public SimplifiedPlaylistObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SimplifiedPlaylistObject.FromRawUnchecked(rawData);
}

/// <summary>
/// The user who owns the playlist
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Owner, OwnerFromRaw>))]
public sealed record class Owner : JsonModel
{
    /// <summary>
    /// The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for
    /// this user.
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalUrlObject>("external_urls");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("href");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
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
            this._rawData.Freeze();
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("uri");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    public static implicit operator PlaylistUserObject(Owner owner) =>
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Owner(Owner owner)
        : base(owner) { }
#pragma warning restore CS8618

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

    /// <inheritdoc cref="OwnerFromRaw.FromRawUnchecked"/>
    public static Owner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OwnerFromRaw : IFromRawJson<Owner>
{
    /// <inheritdoc/>
    public Owner FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Owner.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// The name displayed on the user's profile. `null` if not available.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DisplayName;
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1(IntersectionMember1 intersectionMember1)
        : base(intersectionMember1) { }
#pragma warning restore CS8618

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

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        IntersectionMember1.FromRawUnchecked(rawData);
}
