using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<SimplifiedArtistObject, SimplifiedArtistObjectFromRaw>))]
public sealed record class SimplifiedArtistObject : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// artist.
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
    /// Known external URLs for this artist.
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
    /// A link to the Web API endpoint providing full details of the artist.
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
    /// The name of the artist.
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
    public ApiEnum<string, SimplifiedArtistObjectType>? Type
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, SimplifiedArtistObjectType>>(
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
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// artist.
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
        this.ExternalURLs?.Validate();
        _ = this.Href;
        _ = this.Name;
        _ = this.Published;
        this.Type?.Validate();
        _ = this.Uri;
    }

    public SimplifiedArtistObject() { }

    public SimplifiedArtistObject(SimplifiedArtistObject simplifiedArtistObject)
        : base(simplifiedArtistObject) { }

    public SimplifiedArtistObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SimplifiedArtistObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SimplifiedArtistObjectFromRaw.FromRawUnchecked"/>
    public static SimplifiedArtistObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SimplifiedArtistObjectFromRaw : IFromRawJson<SimplifiedArtistObject>
{
    /// <inheritdoc/>
    public SimplifiedArtistObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SimplifiedArtistObject.FromRawUnchecked(rawData);
}

/// <summary>
/// The object type.
/// </summary>
[JsonConverter(typeof(SimplifiedArtistObjectTypeConverter))]
public enum SimplifiedArtistObjectType
{
    Artist,
}

sealed class SimplifiedArtistObjectTypeConverter : JsonConverter<SimplifiedArtistObjectType>
{
    public override SimplifiedArtistObjectType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "artist" => SimplifiedArtistObjectType.Artist,
            _ => (SimplifiedArtistObjectType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimplifiedArtistObjectType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SimplifiedArtistObjectType.Artist => "artist",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
