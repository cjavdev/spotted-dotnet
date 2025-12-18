using System.Text.Json;
using Spotted.Exceptions;
using Spotted.Models;
using Spotted.Models.AudioAnalysis;
using Albums = Spotted.Models.Albums;
using Artists = Spotted.Models.Artists;
using Audiobooks = Spotted.Models.Audiobooks;
using AudioFeatures = Spotted.Models.AudioFeatures;
using Browse = Spotted.Models.Browse;
using Chapters = Spotted.Models.Chapters;
using Following = Spotted.Models.Me.Following;
using Search = Spotted.Models.Search;
using Users = Spotted.Models.Users;

namespace Spotted.Core;

/// <summary>
/// The base class for all API objects with properties.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class ModelBase
{
    protected ModelBase(ModelBase modelBase)
    {
        // Nothing to copy. Just so that subclasses can define copy constructors.
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, Reason>(),
            new ApiEnumConverter<string, Type>(),
            new ApiEnumConverter<string, ReleaseDatePrecision>(),
            new ApiEnumConverter<string, PlaylistUserObjectType>(),
            new ApiEnumConverter<string, SimplifiedArtistObjectType>(),
            new ApiEnumConverter<string, SimplifiedEpisodeObjectReleaseDatePrecision>(),
            new ApiEnumConverter<string, AlbumType>(),
            new ApiEnumConverter<string, AlbumReleaseDatePrecision>(),
            new ApiEnumConverter<string, TrackObjectType>(),
            new ApiEnumConverter<string, Albums::AlbumType>(),
            new ApiEnumConverter<string, Albums::ReleaseDatePrecision>(),
            new ApiEnumConverter<string, Albums::AlbumAlbumType>(),
            new ApiEnumConverter<string, Albums::AlbumReleaseDatePrecision>(),
            new ApiEnumConverter<string, Artists::AlbumGroup>(),
            new ApiEnumConverter<string, Artists::AlbumType>(),
            new ApiEnumConverter<string, Artists::ReleaseDatePrecision>(),
            new ApiEnumConverter<string, Audiobooks::ReleaseDatePrecision>(),
            new ApiEnumConverter<string, global::Spotted.Models.Me.Albums.AlbumType>(),
            new ApiEnumConverter<string, global::Spotted.Models.Me.Albums.ReleaseDatePrecision>(),
            new ApiEnumConverter<string, Following::Type>(),
            new ApiEnumConverter<string, Chapters::ReleaseDatePrecision>(),
            new ApiEnumConverter<string, Chapters::ChapterReleaseDatePrecision>(),
            new ApiEnumConverter<string, Search::AlbumType>(),
            new ApiEnumConverter<string, Search::ReleaseDatePrecision>(),
            new ApiEnumConverter<string, Search::Type>(),
            new ApiEnumConverter<string, Search::IncludeExternal>(),
            new ApiEnumConverter<string, Users::Type>(),
            new ApiEnumConverter<string, Browse::AlbumType>(),
            new ApiEnumConverter<string, Browse::ReleaseDatePrecision>(),
            new ApiEnumConverter<string, AudioFeatures::Type>(),
            new ApiEnumConverter<string, AudioFeatures::AudioFeatureType>(),
            new ApiEnumConverter<double, Mode>(),
        },
    };

    private protected static readonly JsonSerializerOptions ToStringSerializerOptions = new(
        SerializerOptions
    )
    {
        WriteIndented = true,
    };

    /// <summary>
    /// Validates that all required fields are set and that each field's value is of the expected type.
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="SpottedInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public abstract void Validate();
}
