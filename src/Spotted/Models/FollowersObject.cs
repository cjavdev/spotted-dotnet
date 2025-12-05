using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<FollowersObject, FollowersObjectFromRaw>))]
public sealed record class FollowersObject : ModelBase
{
    /// <summary>
    /// This will always be set to null, as the Web API does not support it at the
    /// moment.
    /// </summary>
    public string? Href
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "href"); }
        init { ModelBase.Set(this._rawData, "href", value); }
    }

    /// <summary>
    /// The total number of followers.
    /// </summary>
    public long? Total
    {
        get { return ModelBase.GetNullableStruct<long>(this.RawData, "total"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "total", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Href;
        _ = this.Total;
    }

    public FollowersObject() { }

    public FollowersObject(FollowersObject followersObject)
        : base(followersObject) { }

    public FollowersObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowersObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FollowersObjectFromRaw.FromRawUnchecked"/>
    public static FollowersObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FollowersObjectFromRaw : IFromRaw<FollowersObject>
{
    /// <inheritdoc/>
    public FollowersObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FollowersObject.FromRawUnchecked(rawData);
}
