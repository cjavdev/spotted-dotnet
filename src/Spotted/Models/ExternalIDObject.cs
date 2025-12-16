using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<ExternalIDObject, ExternalIDObjectFromRaw>))]
public sealed record class ExternalIDObject : ModelBase
{
    /// <summary>
    /// [International Article Number](http://en.wikipedia.org/wiki/International_Article_Number_%28EAN%29)
    /// </summary>
    public string? Ean
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "ean"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "ean", value);
        }
    }

    /// <summary>
    /// [International Standard Recording Code](http://en.wikipedia.org/wiki/International_Standard_Recording_Code)
    /// </summary>
    public string? Isrc
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "isrc"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "isrc", value);
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

    /// <summary>
    /// [Universal Product Code](http://en.wikipedia.org/wiki/Universal_Product_Code)
    /// </summary>
    public string? Upc
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "upc"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "upc", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Ean;
        _ = this.Isrc;
        _ = this.Published;
        _ = this.Upc;
    }

    public ExternalIDObject() { }

    public ExternalIDObject(ExternalIDObject externalIDObject)
        : base(externalIDObject) { }

    public ExternalIDObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalIDObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalIDObjectFromRaw.FromRawUnchecked"/>
    public static ExternalIDObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalIDObjectFromRaw : IFromRaw<ExternalIDObject>
{
    /// <inheritdoc/>
    public ExternalIDObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExternalIDObject.FromRawUnchecked(rawData);
}
