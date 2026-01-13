using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<PlaylistUserObject, PlaylistUserObjectFromRaw>))]
public sealed record class PlaylistUserObject : JsonModel
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

    /// <summary>
    /// Known public external URLs for this user.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.ExternalUrls?.Validate();
        _ = this.Href;
        _ = this.Published;
        this.Type?.Validate();
        _ = this.Uri;
    }

    public PlaylistUserObject() { }

    public PlaylistUserObject(PlaylistUserObject playlistUserObject)
        : base(playlistUserObject) { }

    public PlaylistUserObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistUserObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class PlaylistUserObjectFromRaw : IFromRawJson<PlaylistUserObject>
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
