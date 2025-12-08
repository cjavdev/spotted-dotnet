using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me;

[JsonConverter(typeof(ModelConverter<MeRetrieveResponse, MeRetrieveResponseFromRaw>))]
public sealed record class MeRetrieveResponse : ModelBase
{
    /// <summary>
    /// The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for
    /// the user.
    /// </summary>
    public string? ID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
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
        get { return ModelBase.GetNullableClass<string>(this.RawData, "country"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "country", value);
        }
    }

    /// <summary>
    /// The name displayed on the user's profile. `null` if not available.
    /// </summary>
    public string? DisplayName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "display_name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "display_name", value);
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
        get { return ModelBase.GetNullableClass<string>(this.RawData, "email"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "email", value);
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
            return ModelBase.GetNullableClass<ExplicitContent>(this.RawData, "explicit_content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "explicit_content", value);
        }
    }

    /// <summary>
    /// Known external URLs for this user.
    /// </summary>
    public ExternalURLObject? ExternalURLs
    {
        get { return ModelBase.GetNullableClass<ExternalURLObject>(this.RawData, "external_urls"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "external_urls", value);
        }
    }

    /// <summary>
    /// Information about the followers of the user.
    /// </summary>
    public FollowersObject? Followers
    {
        get { return ModelBase.GetNullableClass<FollowersObject>(this.RawData, "followers"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "followers", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint for this user.
    /// </summary>
    public string? Href
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "href", value);
        }
    }

    /// <summary>
    /// The user's profile image.
    /// </summary>
    public IReadOnlyList<ImageObject>? Images
    {
        get { return ModelBase.GetNullableClass<List<ImageObject>>(this.RawData, "images"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "images", value);
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
        get { return ModelBase.GetNullableClass<string>(this.RawData, "product"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "product", value);
        }
    }

    /// <summary>
    /// The object type: "user"
    /// </summary>
    public string? Type
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// user.
    /// </summary>
    public string? Uri
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "uri", value);
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
        this.ExternalURLs?.Validate();
        this.Followers?.Validate();
        _ = this.Href;
        foreach (var item in this.Images ?? [])
        {
            item.Validate();
        }
        _ = this.Product;
        _ = this.Type;
        _ = this.Uri;
    }

    public MeRetrieveResponse() { }

    public MeRetrieveResponse(MeRetrieveResponse meRetrieveResponse)
        : base(meRetrieveResponse) { }

    public MeRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class MeRetrieveResponseFromRaw : IFromRaw<MeRetrieveResponse>
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
[JsonConverter(typeof(ModelConverter<ExplicitContent, ExplicitContentFromRaw>))]
public sealed record class ExplicitContent : ModelBase
{
    /// <summary>
    /// When `true`, indicates that explicit content should not be played.
    /// </summary>
    public bool? FilterEnabled
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "filter_enabled"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "filter_enabled", value);
        }
    }

    /// <summary>
    /// When `true`, indicates that the explicit content setting is locked and can't
    /// be changed by the user.
    /// </summary>
    public bool? FilterLocked
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "filter_locked"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "filter_locked", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FilterEnabled;
        _ = this.FilterLocked;
    }

    public ExplicitContent() { }

    public ExplicitContent(ExplicitContent explicitContent)
        : base(explicitContent) { }

    public ExplicitContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExplicitContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExplicitContentFromRaw.FromRawUnchecked"/>
    public static ExplicitContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExplicitContentFromRaw : IFromRaw<ExplicitContent>
{
    /// <inheritdoc/>
    public ExplicitContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExplicitContent.FromRawUnchecked(rawData);
}
