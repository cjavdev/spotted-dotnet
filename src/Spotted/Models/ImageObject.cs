using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<ImageObject, ImageObjectFromRaw>))]
public sealed record class ImageObject : ModelBase
{
    /// <summary>
    /// The image height in pixels.
    /// </summary>
    public required long? Height
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "height"); }
        init { ModelBase.Set(this._rawData, "height", value); }
    }

    /// <summary>
    /// The source URL of the image.
    /// </summary>
    public required string URL
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "url"); }
        init { ModelBase.Set(this._rawData, "url", value); }
    }

    /// <summary>
    /// The image width in pixels.
    /// </summary>
    public required long? Width
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "width"); }
        init { ModelBase.Set(this._rawData, "width", value); }
    }

    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "published", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.URL;
        _ = this.Width;
        _ = this.Published;
    }

    public ImageObject() { }

    public ImageObject(ImageObject imageObject)
        : base(imageObject) { }

    public ImageObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageObjectFromRaw.FromRawUnchecked"/>
    public static ImageObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageObjectFromRaw : IFromRaw<ImageObject>
{
    /// <inheritdoc/>
    public ImageObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageObject.FromRawUnchecked(rawData);
}
