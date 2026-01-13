using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<LinkedTrackObject, LinkedTrackObjectFromRaw>))]
public sealed record class LinkedTrackObject : JsonModel
{
    /// <summary>
    /// The [Spotify ID](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// track.
    /// </summary>
    public string? ID
    {
        get { return this._rawData.GetNullableClass<string>("id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Known external URLs for this track.
    /// </summary>
    public ExternalUrlObject? ExternalUrls
    {
        get { return this._rawData.GetNullableClass<ExternalUrlObject>("external_urls"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("external_urls", value);
        }
    }

    /// <summary>
    /// A link to the Web API endpoint providing full details of the track.
    /// </summary>
    public string? Href
    {
        get { return this._rawData.GetNullableClass<string>("href"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("href", value);
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
    /// The object type: "track".
    /// </summary>
    public string? Type
    {
        get { return this._rawData.GetNullableClass<string>("type"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// The [Spotify URI](/documentation/web-api/concepts/spotify-uris-ids) for the
    /// track.
    /// </summary>
    public string? Uri
    {
        get { return this._rawData.GetNullableClass<string>("uri"); }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.ExternalUrls?.Validate();
        _ = this.Href;
        _ = this.Published;
        _ = this.Type;
        _ = this.Uri;
    }

    public LinkedTrackObject() { }

    public LinkedTrackObject(LinkedTrackObject linkedTrackObject)
        : base(linkedTrackObject) { }

    public LinkedTrackObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LinkedTrackObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LinkedTrackObjectFromRaw.FromRawUnchecked"/>
    public static LinkedTrackObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LinkedTrackObjectFromRaw : IFromRawJson<LinkedTrackObject>
{
    /// <inheritdoc/>
    public LinkedTrackObject FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LinkedTrackObject.FromRawUnchecked(rawData);
}
