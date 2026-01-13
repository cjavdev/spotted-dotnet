using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me;

[JsonConverter(typeof(JsonModelConverter<MeRetrieveResponse, MeRetrieveResponseFromRaw>))]
public sealed record class MeRetrieveResponse : JsonModel
{
    /// <summary>
    /// The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for
    /// the user.
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
    /// The country of the user, as set in the user's account profile. An [ISO 3166-1
    /// alpha-2 country code](http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2). _This
    /// field is only available when the current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes)
    /// scope._
    /// </summary>
    public string? Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("country", value);
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
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("display_name", value);
        }
    }

    /// <summary>
    /// The user's email address, as entered by the user when creating their account.
    /// _**Important!** This email address is unverified; there is no proof that
    /// it actually belongs to the user._ _This field is only available when the current
    /// user has granted access to the [user-read-email](/documentation/web-api/concepts/scopes/#list-of-scopes)
    /// scope._
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// The user's explicit content settings. _This field is only available when the
    /// current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes)
    /// scope._
    /// </summary>
    public ExplicitContent? ExplicitContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExplicitContent>("explicit_content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("explicit_content", value);
        }
    }

    /// <summary>
    /// Known external URLs for this user.
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
    /// Information about the followers of the user.
    /// </summary>
    public FollowersObject? Followers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FollowersObject>("followers");
        }
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
    /// The user's profile image.
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
    /// The user's Spotify subscription level: "premium", "free", etc. (The subscription
    /// level "open" can be considered the same as "free".) _This field is only available
    /// when the current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes)
    /// scope._
    /// </summary>
    public string? Product
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("product");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("product", value);
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
    /// The object type: "user"
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Country;
        _ = this.DisplayName;
        _ = this.Email;
        this.ExplicitContent?.Validate();
        this.ExternalUrls?.Validate();
        this.Followers?.Validate();
        _ = this.Href;
        foreach (var item in this.Images ?? [])
        {
            item.Validate();
        }
        _ = this.Product;
        _ = this.Published;
        _ = this.Type;
        _ = this.Uri;
    }

    public MeRetrieveResponse() { }

    public MeRetrieveResponse(MeRetrieveResponse meRetrieveResponse)
        : base(meRetrieveResponse) { }

    public MeRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeRetrieveResponseFromRaw : IFromRawJson<MeRetrieveResponse>
{
    /// <inheritdoc/>
    public MeRetrieveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The user's explicit content settings. _This field is only available when the
/// current user has granted access to the [user-read-private](/documentation/web-api/concepts/scopes/#list-of-scopes)
/// scope._
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ExplicitContent, ExplicitContentFromRaw>))]
public sealed record class ExplicitContent : JsonModel
{
    /// <summary>
    /// When `true`, indicates that explicit content should not be played.
    /// </summary>
    public bool? FilterEnabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("filter_enabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filter_enabled", value);
        }
    }

    /// <summary>
    /// When `true`, indicates that the explicit content setting is locked and can't
    /// be changed by the user.
    /// </summary>
    public bool? FilterLocked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("filter_locked");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filter_locked", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FilterEnabled;
        _ = this.FilterLocked;
        _ = this.Published;
    }

    public ExplicitContent() { }

    public ExplicitContent(ExplicitContent explicitContent)
        : base(explicitContent) { }

    public ExplicitContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExplicitContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExplicitContentFromRaw.FromRawUnchecked"/>
    public static ExplicitContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExplicitContentFromRaw : IFromRawJson<ExplicitContent>
{
    /// <inheritdoc/>
    public ExplicitContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExplicitContent.FromRawUnchecked(rawData);
}
