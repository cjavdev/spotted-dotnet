using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Player;

[JsonConverter(
    typeof(JsonModelConverter<
        PlayerListRecentlyPlayedResponse,
        PlayerListRecentlyPlayedResponseFromRaw
    >)
)]
public sealed record class PlayerListRecentlyPlayedResponse : JsonModel
{
    /// <summary>
    /// The context the track was played from.
    /// </summary>
    public ContextObject? Context
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContextObject>("context");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("context", value);
        }
    }

    /// <summary>
    /// The date and time the track was played.
    /// </summary>
    public DateTimeOffset? PlayedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("played_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("played_at", value);
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
    /// The track the user listened to.
    /// </summary>
    public TrackObject? Track
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TrackObject>("track");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("track", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Context?.Validate();
        _ = this.PlayedAt;
        _ = this.Published;
        this.Track?.Validate();
    }

    public PlayerListRecentlyPlayedResponse() { }

    public PlayerListRecentlyPlayedResponse(
        PlayerListRecentlyPlayedResponse playerListRecentlyPlayedResponse
    )
        : base(playerListRecentlyPlayedResponse) { }

    public PlayerListRecentlyPlayedResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PlayerListRecentlyPlayedResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PlayerListRecentlyPlayedResponseFromRaw.FromRawUnchecked"/>
    public static PlayerListRecentlyPlayedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PlayerListRecentlyPlayedResponseFromRaw : IFromRawJson<PlayerListRecentlyPlayedResponse>
{
    /// <inheritdoc/>
    public PlayerListRecentlyPlayedResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PlayerListRecentlyPlayedResponse.FromRawUnchecked(rawData);
}
