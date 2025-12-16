using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(ModelConverter<ExternalURLObject, ExternalURLObjectFromRaw>))]
public sealed record class ExternalURLObject : ModelBase
{
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
    /// The [Spotify URL](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// object.
    /// </summary>
    public string? Spotify
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "spotify"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "spotify", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Published;
        _ = this.Spotify;
    }

    public ExternalURLObject() { }

    public ExternalURLObject(ExternalURLObject externalURLObject)
        : base(externalURLObject) { }

    public ExternalURLObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalURLObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalURLObjectFromRaw.FromRawUnchecked"/>
    public static ExternalURLObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalURLObjectFromRaw : IFromRaw<ExternalURLObject>
{
    /// <inheritdoc/>
    public ExternalURLObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExternalURLObject.FromRawUnchecked(rawData);
}
