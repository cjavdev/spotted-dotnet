using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<ExternalUrlObject, ExternalUrlObjectFromRaw>))]
public sealed record class ExternalUrlObject : JsonModel
{
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

    /// <summary>
    /// The [Spotify URL](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// object.
    /// </summary>
    public string? Spotify
    {
        get { return this._rawData.GetNullableClass<string>("spotify"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("spotify", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Published;
        _ = this.Spotify;
    }

    public ExternalUrlObject() { }

    public ExternalUrlObject(ExternalUrlObject externalUrlObject)
        : base(externalUrlObject) { }

    public ExternalUrlObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalUrlObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalUrlObjectFromRaw.FromRawUnchecked"/>
    public static ExternalUrlObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalUrlObjectFromRaw : IFromRawJson<ExternalUrlObject>
{
    /// <inheritdoc/>
    public ExternalUrlObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ExternalUrlObject.FromRawUnchecked(rawData);
}
