using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<AlbumRestrictionObject, AlbumRestrictionObjectFromRaw>))]
public sealed record class AlbumRestrictionObject : ModelBase
{
    /// <summary>
    /// The reason for the restriction. Albums may be restricted if the content is
    /// not available in a given market, to the user's subscription type, or when
    /// the user's account is set to not play explicit content. Additional reasons
    /// may be added in the future.
    /// </summary>
    public ApiEnum<string, Reason>? Reason
    {
        get { return ModelBase.GetNullableClass<ApiEnum<string, Reason>>(this.RawData, "reason"); }
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
        this.Reason?.Validate();
    }

    public AlbumRestrictionObject() { }

    public AlbumRestrictionObject(AlbumRestrictionObject albumRestrictionObject)
        : base(albumRestrictionObject) { }

    public AlbumRestrictionObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AlbumRestrictionObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AlbumRestrictionObjectFromRaw.FromRawUnchecked"/>
    public static AlbumRestrictionObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AlbumRestrictionObjectFromRaw : IFromRaw<AlbumRestrictionObject>
{
    /// <inheritdoc/>
    public AlbumRestrictionObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AlbumRestrictionObject.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason for the restriction. Albums may be restricted if the content is not
/// available in a given market, to the user's subscription type, or when the user's
/// account is set to not play explicit content. Additional reasons may be added in
/// the future.
/// </summary>
[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    Market,
    Product,
    Explicit,
}

sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "market" => Reason.Market,
            "product" => Reason.Product,
            "explicit" => Reason.Explicit,
            _ => (Reason)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Reason value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Reason.Market => "market",
                Reason.Product => "product",
                Reason.Explicit => "explicit",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
