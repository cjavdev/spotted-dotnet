using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<CopyrightObject, CopyrightObjectFromRaw>))]
public sealed record class CopyrightObject : ModelBase
{
    /// <summary>
    /// The copyright text for this content.
    /// </summary>
    public string? Text
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "text"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "text", value);
        }
    }

    /// <summary>
    /// The type of copyright: `C` = the copyright, `P` = the sound recording (performance)
    /// copyright.
    /// </summary>
    public string? Type
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Text;
        _ = this.Type;
    }

    public CopyrightObject() { }

    public CopyrightObject(CopyrightObject copyrightObject)
        : base(copyrightObject) { }

    public CopyrightObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CopyrightObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CopyrightObjectFromRaw.FromRawUnchecked"/>
    public static CopyrightObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CopyrightObjectFromRaw : IFromRaw<CopyrightObject>
{
    /// <inheritdoc/>
    public CopyrightObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        CopyrightObject.FromRawUnchecked(rawData);
}
