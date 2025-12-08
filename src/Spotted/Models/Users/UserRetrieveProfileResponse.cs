using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Users;

[JsonConverter(
    typeof(ModelConverter<UserRetrieveProfileResponse, UserRetrieveProfileResponseFromRaw>)
)]
public sealed record class UserRetrieveProfileResponse : ModelBase
{
    /// <summary>
    /// The [Spotify user ID](/documentation/web-api/concepts/spotify-uris-ids) for
    /// this user.
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
    /// The name displayed on the user's profile. `null` if not available.
    /// </summary>
    public string? DisplayName
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "display_name"); }
        init { ModelBase.Set(this._rawData, "display_name", value); }
    }

    /// <summary>
    /// Known public external URLs for this user.
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
    /// Information about the followers of this user.
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
    /// The object type.
    /// </summary>
    public ApiEnum<string, global::Spotted.Models.Users.Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, global::Spotted.Models.Users.Type>>(
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

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for this
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
        _ = this.DisplayName;
        this.ExternalURLs?.Validate();
        this.Followers?.Validate();
        _ = this.Href;
        foreach (var item in this.Images ?? [])
        {
            item.Validate();
        }
        this.Type?.Validate();
        _ = this.Uri;
    }

    public UserRetrieveProfileResponse() { }

    public UserRetrieveProfileResponse(UserRetrieveProfileResponse userRetrieveProfileResponse)
        : base(userRetrieveProfileResponse) { }

    public UserRetrieveProfileResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveProfileResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class UserRetrieveProfileResponseFromRaw : IFromRaw<UserRetrieveProfileResponse>
{
    /// <inheritdoc/>
    public UserRetrieveProfileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserRetrieveProfileResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The object type.
/// </summary>
[JsonConverter(typeof(global::Spotted.Models.Users.TypeConverter))]
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
