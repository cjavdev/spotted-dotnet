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
