using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<ArtistObject, ArtistObjectFromRaw>))]
public sealed record class ArtistObject : ModelBase
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// artist.
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
    /// Known external URLs for this artist.
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
    /// Information about the followers of the artist.
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
    /// A list of the genres the artist is associated with. If not yet classified,
    /// the array is empty.
    /// </summary>
    public IReadOnlyList<string>? Genres
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "genres"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "genres", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the artist.
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
    /// Images of the artist in various sizes, widest first.
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
    /// The name of the artist.
    /// </summary>
    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    /// <summary>
    /// The popularity of the artist. The value will be between 0 and 100, with 100
    /// being the most popular. The artist's popularity is calculated from the popularity
    /// of all the artist's tracks.
    /// </summary>
    public long? Popularity
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "popularity"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "popularity", value);
        }
    }

    /// <summary>
    /// The object type.
    /// </summary>
    public ApiEnum<string, global::Spotted.Models.Type>? Type
    {
        get
        {
            return ModelBase.GetNullableClass<ApiEnum<string, global::Spotted.Models.Type>>(
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
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// artist.
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
        this.Followers?.Validate();
        _ = this.Genres;
        _ = this.Href;
        foreach (var item in this.Images ?? [])
        {
            item.Validate();
        }
        _ = this.Name;
        _ = this.Popularity;
        this.Type?.Validate();
        _ = this.Uri;
    }

    public ArtistObject() { }

    public ArtistObject(ArtistObject artistObject)
        : base(artistObject) { }

    public ArtistObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtistObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ArtistObjectFromRaw.FromRawUnchecked"/>
    public static ArtistObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ArtistObjectFromRaw : IFromRaw<ArtistObject>
{
    /// <inheritdoc/>
    public ArtistObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ArtistObject.FromRawUnchecked(rawData);
}

/// <summary>
/// The object type.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Artist,
}

sealed class TypeConverter : JsonConverter<global::Spotted.Models.Type>
{
    public override global::Spotted.Models.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "artist" => global::Spotted.Models.Type.Artist,
            _ => (global::Spotted.Models.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Type.Artist => "artist",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
