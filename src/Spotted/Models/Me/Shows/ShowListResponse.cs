using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;

namespace Spotted.Models.Me.Shows;

[JsonConverter(typeof(JsonModelConverter<ShowListResponse, ShowListResponseFromRaw>))]
public sealed record class ShowListResponse : JsonModel
{
    /// <summary>
    /// The date and time the show was saved. Timestamps are returned in ISO 8601
    /// format as Coordinated Universal Time (UTC) with a zero offset: YYYY-MM-DDTHH:MM:SSZ.
    /// If the time is imprecise (for example, the date/time of an album release),
    /// an additional field indicates the precision; see for example, release_date
    /// in an album object.
    /// </summary>
    public DateTimeOffset? AddedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("added_at");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("added_at", value);
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
    /// Information about the show.
    /// </summary>
    public ShowBase? Show
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShowBase>("show");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("show", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddedAt;
        _ = this.Published;
        this.Show?.Validate();
    }

    public ShowListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShowListResponse(ShowListResponse showListResponse)
        : base(showListResponse) { }
#pragma warning restore CS8618

    public ShowListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ShowListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ShowListResponseFromRaw.FromRawUnchecked"/>
    public static ShowListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ShowListResponseFromRaw : IFromRawJson<ShowListResponse>
{
    /// <inheritdoc/>
    public ShowListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ShowListResponse.FromRawUnchecked(rawData);
}
