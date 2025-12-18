using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Playlists.Tracks;

/// <summary>
/// Either reorder or replace items in a playlist depending on the request's parameters.
/// To reorder items, include `range_start`, `insert_before`, `range_length` and `snapshot_id`
/// in the request's body. To replace items, include `uris` as either a query parameter
/// or in the request's body. Replacing items in a playlist will overwrite its existing
/// items. This operation can be used for replacing or clearing items in a playlist.
/// <br/> **Note**: Replace and reorder are mutually exclusive operations which share
/// the same endpoint, but have different parameters. These operations can't be applied
/// together in a single request.
/// </summary>
public sealed record class TrackUpdateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PlaylistID { get; init; }

    /// <summary>
    /// The position where the items should be inserted.<br/>To reorder the items
    /// to the end of the playlist, simply set _insert_before_ to the position after
    /// the last item.<br/>Examples:<br/>To reorder the first item to the last position
    /// in a playlist with 10 items, set _range_start_ to 0, and _insert_before_ to
    /// 10.<br/>To reorder the last item in a playlist with 10 items to the start
    /// of the playlist, set _range_start_ to 9, and _insert_before_ to 0.
    /// </summary>
    public long? InsertBefore
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "insert_before"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "insert_before", value);
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
        get { return JsonModel.GetNullableStruct<bool>(this.RawBodyData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "published", value);
        }
    }

    /// <summary>
    /// The amount of items to be reordered. Defaults to 1 if not set.<br/>The range
    /// of items to be reordered begins from the _range_start_ position, and includes
    /// the _range_length_ subsequent items.<br/>Example:<br/>To move the items at
    /// index 9-10 to the start of the playlist, _range_start_ is set to 9, and _range_length_
    /// is set to 2.
    /// </summary>
    public long? RangeLength
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "range_length"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "range_length", value);
        }
    }

    /// <summary>
    /// The position of the first item to be reordered.
    /// </summary>
    public long? RangeStart
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawBodyData, "range_start"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "range_start", value);
        }
    }

    /// <summary>
    /// The playlist's snapshot ID against which you want to make the changes.
    /// </summary>
    public string? SnapshotID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawBodyData, "snapshot_id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "snapshot_id", value);
        }
    }

    public IReadOnlyList<string>? Uris
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawBodyData, "uris"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawBodyData, "uris", value);
        }
    }

    public TrackUpdateParams() { }

    public TrackUpdateParams(TrackUpdateParams trackUpdateParams)
        : base(trackUpdateParams)
    {
        this._rawBodyData = [.. trackUpdateParams._rawBodyData];
    }

    public TrackUpdateParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TrackUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static TrackUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/playlists/{0}/tracks", this.PlaylistID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
