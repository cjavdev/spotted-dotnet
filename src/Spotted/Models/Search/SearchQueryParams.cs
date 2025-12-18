using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Search;

/// <summary>
/// Get Spotify catalog information about albums, artists, playlists, tracks, shows,
/// episodes or audiobooks that match a keyword string. Audiobooks are only available
/// within the US, UK, Canada, Ireland, New Zealand and Australia markets.
/// </summary>
public sealed record class SearchQueryParams : ParamsBase
{
    /// <summary>
    /// Your search query.
    ///
    /// <para>You can narrow down your search using field filters. The available filters
    /// are `album`, `artist`, `track`, `year`, `upc`, `tag:hipster`, `tag:new`,
    /// `isrc`, and `genre`. Each field filter only applies to certain result types.</para>
    ///
    /// <para>The `artist` and `year` filters can be used while searching albums,
    /// artists and tracks. You can filter on a single `year` or a range (e.g. 1955-1960).<br
    /// /> The `album` filter can be used while searching albums and tracks.<br />
    /// The `genre` filter can be used while searching artists and tracks.<br /> The
    /// `isrc` and `track` filters can be used while searching tracks.<br /> The
    /// `upc`, `tag:new` and `tag:hipster` filters can only be used while searching
    /// albums. The `tag:new` filter will return albums released in the past two weeks
    /// and `tag:hipster` can be used to return only albums with the lowest 10% popularity.<br
    /// /> </para>
    /// </summary>
    public required string Q
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawQueryData, "q"); }
        init { JsonModel.Set(this._rawQueryData, "q", value); }
    }

    /// <summary>
    /// A comma-separated list of item types to search across. Search results include
    /// hits from all the specified item types. For example: `q=abacab&type=album,track`
    /// returns both albums and tracks matching "abacab".
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, global::Spotted.Models.Search.Type>> Type
    {
        get
        {
            return JsonModel.GetNotNullClass<
                List<ApiEnum<string, global::Spotted.Models.Search.Type>>
            >(this.RawQueryData, "type");
        }
        init { JsonModel.Set(this._rawQueryData, "type", value); }
    }

    /// <summary>
    /// If `include_external=audio` is specified it signals that the client can play
    /// externally hosted audio content, and marks the content as playable in the
    /// response. By default externally hosted audio content is marked as unplayable
    /// in the response.
    /// </summary>
    public ApiEnum<string, IncludeExternal>? IncludeExternal
    {
        get
        {
            return JsonModel.GetNullableClass<ApiEnum<string, IncludeExternal>>(
                this.RawQueryData,
                "include_external"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "include_external", value);
        }
    }

    /// <summary>
    /// The maximum number of results to return in each item type.
    /// </summary>
    public long? Limit
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "limit"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "limit", value);
        }
    }

    /// <summary>
    /// An [ISO 3166-1 alpha-2 country code](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2).
    ///   If a country code is specified, only content that is available in that market
    /// will be returned.<br/>   If a valid user access token is specified in the
    /// request header, the country associated with   the user account will take
    /// priority over this parameter.<br/>   _**Note**: If neither market or user
    /// country are provided, the content is considered unavailable for the client._<br/>
    ///   Users can view the country that is associated with their account in the
    /// [account settings](https://www.spotify.com/account/overview/).
    /// </summary>
    public string? Market
    {
        get { return JsonModel.GetNullableClass<string>(this.RawQueryData, "market"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "market", value);
        }
    }

    /// <summary>
    /// The index of the first result to return. Use with limit to get the next page
    /// of search results.
    /// </summary>
    public long? Offset
    {
        get { return JsonModel.GetNullableStruct<long>(this.RawQueryData, "offset"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawQueryData, "offset", value);
        }
    }

    public SearchQueryParams() { }

    public SearchQueryParams(SearchQueryParams searchQueryParams)
        : base(searchQueryParams) { }

    public SearchQueryParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SearchQueryParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson.FromRawUnchecked"/>
    public static SearchQueryParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        );
    }

    public override System::Uri Url(ClientOptions options)
    {
        return new System::UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/search")
        {
            Query = this.QueryString(options),
        }.Uri;
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

[JsonConverter(typeof(global::Spotted.Models.Search.TypeConverter))]
public enum Type
{
    Album,
    Artist,
    Playlist,
    Track,
    Show,
    Episode,
    Audiobook,
}

sealed class TypeConverter : JsonConverter<global::Spotted.Models.Search.Type>
{
    public override global::Spotted.Models.Search.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "album" => global::Spotted.Models.Search.Type.Album,
            "artist" => global::Spotted.Models.Search.Type.Artist,
            "playlist" => global::Spotted.Models.Search.Type.Playlist,
            "track" => global::Spotted.Models.Search.Type.Track,
            "show" => global::Spotted.Models.Search.Type.Show,
            "episode" => global::Spotted.Models.Search.Type.Episode,
            "audiobook" => global::Spotted.Models.Search.Type.Audiobook,
            _ => (global::Spotted.Models.Search.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Search.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Search.Type.Album => "album",
                global::Spotted.Models.Search.Type.Artist => "artist",
                global::Spotted.Models.Search.Type.Playlist => "playlist",
                global::Spotted.Models.Search.Type.Track => "track",
                global::Spotted.Models.Search.Type.Show => "show",
                global::Spotted.Models.Search.Type.Episode => "episode",
                global::Spotted.Models.Search.Type.Audiobook => "audiobook",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// If `include_external=audio` is specified it signals that the client can play externally
/// hosted audio content, and marks the content as playable in the response. By default
/// externally hosted audio content is marked as unplayable in the response.
/// </summary>
[JsonConverter(typeof(IncludeExternalConverter))]
public enum IncludeExternal
{
    Audio,
}

sealed class IncludeExternalConverter : JsonConverter<IncludeExternal>
{
    public override IncludeExternal Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "audio" => IncludeExternal.Audio,
            _ => (IncludeExternal)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IncludeExternal value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                IncludeExternal.Audio => "audio",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
