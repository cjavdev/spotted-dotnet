using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<AuthorObject, AuthorObjectFromRaw>))]
public sealed record class AuthorObject : ModelBase
{
    /// <summary>
    /// The name of the author.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
    }

    public AuthorObject() { }

    public AuthorObject(AuthorObject authorObject)
        : base(authorObject) { }

    public AuthorObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthorObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthorObjectFromRaw.FromRawUnchecked"/>
    public static AuthorObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AuthorObjectFromRaw : IFromRaw<AuthorObject>
{
    /// <inheritdoc/>
    public AuthorObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AuthorObject.FromRawUnchecked(rawData);
}
