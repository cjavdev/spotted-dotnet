using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<ChapterRestrictionObject, ChapterRestrictionObjectFromRaw>))]
public sealed record class ChapterRestrictionObject : ModelBase
{
    /// <summary>
    /// The reason for the restriction. Supported values: - `market` - The content
    /// item is not available in the given market. - `product` - The content item
    /// is not available for the user's subscription type. - `explicit` - The content
    /// item is explicit and the user's account is set to not play explicit content.
    /// - `payment_required` - Payment is required to play the content item.
    ///
    /// <para>Additional reasons may be added in the future. **Note**: If you use
    /// this field, make sure that your application safely handles unknown values. </para>
    /// </summary>
    public string? Reason
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "reason"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
    }

    public ChapterRestrictionObject() { }

    public ChapterRestrictionObject(ChapterRestrictionObject chapterRestrictionObject)
        : base(chapterRestrictionObject) { }

    public ChapterRestrictionObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ChapterRestrictionObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChapterRestrictionObjectFromRaw.FromRawUnchecked"/>
    public static ChapterRestrictionObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChapterRestrictionObjectFromRaw : IFromRaw<ChapterRestrictionObject>
{
    /// <inheritdoc/>
    public ChapterRestrictionObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ChapterRestrictionObject.FromRawUnchecked(rawData);
}
