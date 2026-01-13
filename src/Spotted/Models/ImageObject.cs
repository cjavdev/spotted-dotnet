using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<ImageObject, ImageObjectFromRaw>))]
public sealed record class ImageObject : JsonModel
{
    /// <summary>
    /// The image height in pixels.
    /// </summary>
    public required long? Height
    {
        get { return this._rawData.GetNullableStruct<long>("height"); }
        init { this._rawData.Set("height", value); }
    }

    /// <summary>
    /// The source URL of the image.
    /// </summary>
    public required string Url
    {
        get { return this._rawData.GetNotNullClass<string>("url"); }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// The image width in pixels.
    /// </summary>
    public required long? Width
    {
        get { return this._rawData.GetNullableStruct<long>("width"); }
        init { this._rawData.Set("width", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Height;
        _ = this.Url;
        _ = this.Width;
        _ = this.Published;
    }

    public ImageObject() { }

    public ImageObject(ImageObject imageObject)
        : base(imageObject) { }

    public ImageObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageObjectFromRaw.FromRawUnchecked"/>
    public static ImageObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageObjectFromRaw : IFromRawJson<ImageObject>
{
    /// <inheritdoc/>
    public ImageObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ImageObject.FromRawUnchecked(rawData);
}
