using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<PlaylistUserObject, PlaylistUserObjectFromRaw>))]
public sealed record class PlaylistUserObject : ModelBase
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
    /// The object type.
    /// </summary>
    public ApiEnum<string, PlaylistUserObjectType>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, PlaylistUserObjectType>>(
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
        this.ExternalURLs?.Validate();
        _ = this.Href;
        this.Type?.Validate();
        _ = this.Uri;
    }

    public PlaylistUserObject() { }

    public PlaylistUserObject(PlaylistUserObject playlistUserObject)
        : base(playlistUserObject) { }

    public PlaylistUserObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistUserObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaylistUserObjectFromRaw.FromRawUnchecked"/>
    public static PlaylistUserObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaylistUserObjectFromRaw : IFromRaw<PlaylistUserObject>
{
    /// <inheritdoc/>
    public PlaylistUserObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PlaylistUserObject.FromRawUnchecked(rawData);
}

/// <summary>
/// The object type.
/// </summary>
[JsonConverter(typeof(PlaylistUserObjectTypeConverter))]
public enum PlaylistUserObjectType
{
    User,
}

sealed class PlaylistUserObjectTypeConverter : JsonConverter<PlaylistUserObjectType>
{
    public override PlaylistUserObjectType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => PlaylistUserObjectType.User,
            _ => (PlaylistUserObjectType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PlaylistUserObjectType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PlaylistUserObjectType.User => "user",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
