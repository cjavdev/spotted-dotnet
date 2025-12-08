using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Spotted.Core;
using Spotted.Exceptions;
using System = System;

namespace Spotted.Models.Me.Following;

/// <summary>
/// Check to see if the current user is following one or more artists or other Spotify
/// users.
/// </summary>
public sealed record class FollowingCheckParams : ParamsBase
{
    /// <summary>
    /// A comma-separated list of the artist or the user [Spotify IDs](/documentation/web-api/concepts/spotify-uris-ids)
    /// to check. For example: `ids=74ASZWbe4lXaubB36ztrGX,08td7MxkoHQkXnWAYD8d6Q`.
    /// A maximum of 50 IDs can be sent in one request.
    /// </summary>
    public required string IDs
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawQueryData, "ids"); }
        init { ModelBase.Set(this._rawQueryData, "ids", value); }
    }

    /// <summary>
    /// The ID type: either `artist` or `user`.
    /// </summary>
    public required ApiEnum<string, global::Spotted.Models.Me.Following.Type> Type
    {
        get
        {
            return ModelBase.GetNotNullClass<
                ApiEnum<string, global::Spotted.Models.Me.Following.Type>
            >(this.RawQueryData, "type");
        }
        init { ModelBase.Set(this._rawQueryData, "type", value); }
    }

    public FollowingCheckParams() { }

    public FollowingCheckParams(FollowingCheckParams followingCheckParams)
        : base(followingCheckParams) { }

    public FollowingCheckParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FollowingCheckParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRaw.FromRawUnchecked"/>
    public static FollowingCheckParams FromRawUnchecked(
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
        return new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/me/following/contains"
        )
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

/// <summary>
/// The ID type: either `artist` or `user`.
/// </summary>
[JsonConverter(typeof(global::Spotted.Models.Me.Following.TypeConverter))]
public enum Type
{
    Artist,
    User,
}

sealed class TypeConverter : JsonConverter<global::Spotted.Models.Me.Following.Type>
{
    public override global::Spotted.Models.Me.Following.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "artist" => global::Spotted.Models.Me.Following.Type.Artist,
            "user" => global::Spotted.Models.Me.Following.Type.User,
            _ => (global::Spotted.Models.Me.Following.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Spotted.Models.Me.Following.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Spotted.Models.Me.Following.Type.Artist => "artist",
                global::Spotted.Models.Me.Following.Type.User => "user",
                _ => throw new SpottedInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
