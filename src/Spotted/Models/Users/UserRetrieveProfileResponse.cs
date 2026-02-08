using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Users;

[JsonConverter(
    typeof(JsonModelConverter<UserRetrieveProfileResponse, UserRetrieveProfileResponseFromRaw>)
)]
public sealed record class UserRetrieveProfileResponse : JsonModel
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

    /// <summary>
    /// Known public external URLs for this user.
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
    /// Information about the followers of this user.
    /// </summary>
    [System::Obsolete("deprecated")]
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
    public ApiEnum<string, global::Spotted.Models.Users.Type>? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, global::Spotted.Models.Users.Type>
            >("type");
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DisplayName;
        this.ExternalUrls?.Validate();
        this.Followers?.Validate();
        _ = this.Href;
        foreach (var item in this.Images ?? [])
        {
            item.Validate();
        }
        _ = this.Published;
        this.Type?.Validate();
        _ = this.Uri;
    }

    public UserRetrieveProfileResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveProfileResponse(UserRetrieveProfileResponse userRetrieveProfileResponse)
        : base(userRetrieveProfileResponse) { }
#pragma warning restore CS8618

    public UserRetrieveProfileResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveProfileResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveProfileResponseFromRaw.FromRawUnchecked"/>
    public static UserRetrieveProfileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserRetrieveProfileResponseFromRaw : IFromRawJson<UserRetrieveProfileResponse>
{
    /// <inheritdoc/>
    public UserRetrieveProfileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveProfileResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The object type.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    User,
}

sealed class TypeConverter : JsonConverter<global::Spotted.Models.Users.Type>
{
    public override global::Spotted.Models.Users.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => global::Spotted.Models.Users.Type.User,
            _ => (global::Spotted.Models.Users.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Users.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Users.Type.User => "user",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
