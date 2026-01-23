using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models;

[JsonConverter(typeof(JsonModelConverter<PlaylistTracksRefObject, PlaylistTracksRefObjectFromRaw>))]
public sealed record class PlaylistTracksRefObject : JsonModel
{
    /// <summary>
    /// A link to the Web API endpoint where full details of the playlist's tracks
    /// can be retrieved.
    /// </summary>
    public string? Href
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("href");
        }
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
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("published");
        }
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
    /// Number of tracks in the playlist.
    /// </summary>
    public long? Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("total");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("total", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Href;
        _ = this.Published;
        _ = this.Total;
    }

    public PlaylistTracksRefObject() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PlaylistTracksRefObject(PlaylistTracksRefObject playlistTracksRefObject)
        : base(playlistTracksRefObject) { }
#pragma warning restore CS8618

    public PlaylistTracksRefObject(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlaylistTracksRefObject(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlaylistTracksRefObjectFromRaw.FromRawUnchecked"/>
    public static PlaylistTracksRefObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlaylistTracksRefObjectFromRaw : IFromRawJson<PlaylistTracksRefObject>
{
    /// <inheritdoc/>
    public PlaylistTracksRefObject FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlaylistTracksRefObject.FromRawUnchecked(rawData);
}
