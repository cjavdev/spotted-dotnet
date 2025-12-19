using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Episodes;

[JsonConverter(typeof(JsonModelConverter<EpisodeListResponse, EpisodeListResponseFromRaw>))]
public sealed record class EpisodeListResponse : JsonModel
{
    /// <summary>
    /// The date and time the episode was saved. Timestamps are returned in ISO 8601
    /// format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.
    /// </summary>
    public DateTimeOffset? AddedAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "added_at"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "added_at", value);
        }
    }

    /// <summary>
    /// Information about the episode.
    /// </summary>
    public EpisodeObject? Episode
    {
        get { return JsonModel.GetNullableClass<EpisodeObject>(this.RawData, "episode"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "episode", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddedAt;
        this.Episode?.Validate();
        _ = this.Published;
    }

    public EpisodeListResponse() { }

    public EpisodeListResponse(EpisodeListResponse episodeListResponse)
        : base(episodeListResponse) { }

    public EpisodeListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EpisodeListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EpisodeListResponseFromRaw.FromRawUnchecked"/>
    public static EpisodeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EpisodeListResponseFromRaw : IFromRawJson<EpisodeListResponse>
{
    /// <inheritdoc/>
    public EpisodeListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        EpisodeListResponse.FromRawUnchecked(rawData);
}
