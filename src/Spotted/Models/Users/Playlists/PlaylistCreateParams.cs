using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Spotted.Core;

namespace Spotted.Models.Users.Playlists;

/// <summary>
/// Create a playlist for a Spotify user. (The playlist will be empty until you [add
/// tracks](/documentation/web-api/reference/add-tracks-to-playlist).) Each user
/// is generally limited to a maximum of 11000 playlists.
/// </summary>
public sealed record class PlaylistCreateParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? UserID { get; init; }

    /// <summary>
    /// The name for the new playlist, for example `"Your Coolest Playlist"`. This
    /// name does not need to be unique; a user may have several playlists with the
    /// same name.
    /// </summary>
    public required string Name
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "name"); }
        init { ModelBase.Set(this._rawBodyData, "name", value); }
    }

    /// <summary>
    /// Defaults to `false`. If `true` the playlist will be collaborative. _**Note**:
    /// to create a collaborative playlist you must also set `public` to `false`.
    /// To create collaborative playlists you must have granted `playlist-modify-private`
    /// and `playlist-modify-public` [scopes](/documentation/web-api/concepts/scopes/#list-of-scopes)._
    /// </summary>
    public bool? Collaborative
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "collaborative"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "collaborative", value);
        }
    }

    /// <summary>
    /// value for playlist description as displayed in Spotify Clients and in the
    /// Web API.
    /// </summary>
    public string? Description
    {
        get { return ModelBase.GetNullableClass<string>(this.RawBodyData, "description"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "description", value);
        }
    }

    /// <summary>
    /// Defaults to `true`. The playlist's public/private status (if it should be
    /// added to the user's profile or not): `true` the playlist will be public,
    /// `false` the playlist will be private. To be able to create private playlists,
    /// the user must have granted the `playlist-modify-private` [scope](/documentation/web-api/concepts/scopes/#list-of-scopes).
    /// For more about public/private status, see [Working with Playlists](/documentation/web-api/concepts/playlists)
    /// </summary>
    public bool? Public
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "public"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "public", value);
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
        get { return ModelBase.GetNullableStruct<bool>(this.RawBodyData, "published"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "published", value);
        }
    }

    public PlaylistCreateParams() { }

    public PlaylistCreateParams(PlaylistCreateParams playlistCreateParams)
        : base(playlistCreateParams)
    {
        this._rawBodyData = [.. playlistCreateParams._rawBodyData];
    }

    public PlaylistCreateParams(
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
    PlaylistCreateParams(
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

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static PlaylistCreateParams FromRawUnchecked(
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
                + string.Format("/users/{0}/playlists", this.UserID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
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
