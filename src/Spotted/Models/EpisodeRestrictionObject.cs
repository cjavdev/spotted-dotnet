using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(
    typeof(JsonModelConverter<EpisodeRestrictionObject, EpisodeRestrictionObjectFromRaw>)
)]
public sealed record class EpisodeRestrictionObject : JsonModel
{
    /// <summary>
    /// The playlist's public/private status (if it should be added to the user's
    /// profile or not): `true` the playlist will be public, `false` the playlist
    /// will be private, `null` the playlist status is not relevant. For more about
    /// public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Published
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "published", value);
        }
    }

    /// <summary>
    /// The reason for the restriction. Supported values: - `market` - The content
    /// item is not available in the given market. - `product` - The content item
    /// is not available for the user's subscription type. - `explicit` - The content
    /// item is explicit and the user's account is set to not play explicit content.
    ///
    /// <para>Additional reasons may be added in the future. **Note**: If you use
    /// this field, make sure that your application safely handles unknown values. </para>
    /// </summary>
    public string? Reason
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "reason"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Published;
        _ = this.Reason;
    }

    public EpisodeRestrictionObject() { }

    public EpisodeRestrictionObject(EpisodeRestrictionObject episodeRestrictionObject)
        : base(episodeRestrictionObject) { }

    public EpisodeRestrictionObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EpisodeRestrictionObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EpisodeRestrictionObjectFromRaw.FromRawUnchecked"/>
    public static EpisodeRestrictionObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EpisodeRestrictionObjectFromRaw : IFromRawJson<EpisodeRestrictionObject>
{
    /// <inheritdoc/>
    public EpisodeRestrictionObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EpisodeRestrictionObject.FromRawUnchecked(rawData);
}
