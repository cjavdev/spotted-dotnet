using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Albums;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Albums;

public class AlbumRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AlbumRetrieveResponse
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            ExternalIDs = new()
            {
                Ean = "ean",
                Isrc = "isrc",
                Published = true,
                Upc = "upc",
            },
            Genres = ["string"],
            Label = "label",
            Popularity = 0,
            Published = true,
            Restrictions = new() { Published = true, Reason = Models::Reason.Market },
            Tracks = new()
            {
                Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
                Limit = 20,
                Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
                Offset = 0,
                Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
                Total = 4,
                Items =
                [
                    new()
                    {
                        ID = "id",
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["string"],
                        DiscNumber = 0,
                        DurationMs = 0,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        IsLocal = true,
                        IsPlayable = true,
                        LinkedFrom = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Published = true,
                            Type = "type",
                            Uri = "uri",
                        },
                        Name = "name",
                        PreviewURL = "preview_url",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        TrackNumber = 0,
                        Type = "type",
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
        };

        string expectedID = "2up3OPMp9Tb4dAKM2erWXQ";
        ApiEnum<string, AlbumType> expectedAlbumType = AlbumType.Compilation;
        List<string> expectedAvailableMarkets = ["CA", "BR", "IT"];
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        string expectedHref = "href";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        string expectedName = "name";
        string expectedReleaseDate = "1981-12";
        ApiEnum<string, ReleaseDatePrecision> expectedReleaseDatePrecision =
            ReleaseDatePrecision.Year;
        long expectedTotalTracks = 9;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"album\"");
        string expectedUri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ";
        List<Models::SimplifiedArtistObject> expectedArtists =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "href",
                Name = "name",
                Published = true,
                Type = Models::SimplifiedArtistObjectType.Artist,
                Uri = "uri",
            },
        ];
        List<Models::CopyrightObject> expectedCopyrights =
        [
            new()
            {
                Published = true,
                Text = "text",
                Type = "type",
            },
        ];
        Models::ExternalIDObject expectedExternalIDs = new()
        {
            Ean = "ean",
            Isrc = "isrc",
            Published = true,
            Upc = "upc",
        };
        List<string> expectedGenres = ["string"];
        string expectedLabel = "label";
        long expectedPopularity = 0;
        bool expectedPublished = true;
        Models::AlbumRestrictionObject expectedRestrictions = new()
        {
            Published = true,
            Reason = Models::Reason.Market,
        };
        AlbumRetrieveResponseTracks expectedTracks = new()
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,
            Items =
            [
                new()
                {
                    ID = "id",
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    IsLocal = true,
                    IsPlayable = true,
                    LinkedFrom = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Published = true,
                        Type = "type",
                        Uri = "uri",
                    },
                    Name = "name",
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = "type",
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAlbumType, model.AlbumType);
        Assert.Equal(expectedAvailableMarkets.Count, model.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], model.AvailableMarkets[i]);
        }
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedReleaseDate, model.ReleaseDate);
        Assert.Equal(expectedReleaseDatePrecision, model.ReleaseDatePrecision);
        Assert.Equal(expectedTotalTracks, model.TotalTracks);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUri, model.Uri);
        Assert.NotNull(model.Artists);
        Assert.Equal(expectedArtists.Count, model.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], model.Artists[i]);
        }
        Assert.NotNull(model.Copyrights);
        Assert.Equal(expectedCopyrights.Count, model.Copyrights.Count);
        for (int i = 0; i < expectedCopyrights.Count; i++)
        {
            Assert.Equal(expectedCopyrights[i], model.Copyrights[i]);
        }
        Assert.Equal(expectedExternalIDs, model.ExternalIDs);
        Assert.NotNull(model.Genres);
        Assert.Equal(expectedGenres.Count, model.Genres.Count);
        for (int i = 0; i < expectedGenres.Count; i++)
        {
            Assert.Equal(expectedGenres[i], model.Genres[i]);
        }
        Assert.Equal(expectedLabel, model.Label);
        Assert.Equal(expectedPopularity, model.Popularity);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedRestrictions, model.Restrictions);
        Assert.Equal(expectedTracks, model.Tracks);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AlbumRetrieveResponse
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            ExternalIDs = new()
            {
                Ean = "ean",
                Isrc = "isrc",
                Published = true,
                Upc = "upc",
            },
            Genres = ["string"],
            Label = "label",
            Popularity = 0,
            Published = true,
            Restrictions = new() { Published = true, Reason = Models::Reason.Market },
            Tracks = new()
            {
                Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
                Limit = 20,
                Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
                Offset = 0,
                Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
                Total = 4,
                Items =
                [
                    new()
                    {
                        ID = "id",
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["string"],
                        DiscNumber = 0,
                        DurationMs = 0,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        IsLocal = true,
                        IsPlayable = true,
                        LinkedFrom = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Published = true,
                            Type = "type",
                            Uri = "uri",
                        },
                        Name = "name",
                        PreviewURL = "preview_url",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        TrackNumber = 0,
                        Type = "type",
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AlbumRetrieveResponse
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            ExternalIDs = new()
            {
                Ean = "ean",
                Isrc = "isrc",
                Published = true,
                Upc = "upc",
            },
            Genres = ["string"],
            Label = "label",
            Popularity = 0,
            Published = true,
            Restrictions = new() { Published = true, Reason = Models::Reason.Market },
            Tracks = new()
            {
                Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
                Limit = 20,
                Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
                Offset = 0,
                Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
                Total = 4,
                Items =
                [
                    new()
                    {
                        ID = "id",
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["string"],
                        DiscNumber = 0,
                        DurationMs = 0,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        IsLocal = true,
                        IsPlayable = true,
                        LinkedFrom = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Published = true,
                            Type = "type",
                            Uri = "uri",
                        },
                        Name = "name",
                        PreviewURL = "preview_url",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        TrackNumber = 0,
                        Type = "type",
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        string expectedID = "2up3OPMp9Tb4dAKM2erWXQ";
        ApiEnum<string, AlbumType> expectedAlbumType = AlbumType.Compilation;
        List<string> expectedAvailableMarkets = ["CA", "BR", "IT"];
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        string expectedHref = "href";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        string expectedName = "name";
        string expectedReleaseDate = "1981-12";
        ApiEnum<string, ReleaseDatePrecision> expectedReleaseDatePrecision =
            ReleaseDatePrecision.Year;
        long expectedTotalTracks = 9;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"album\"");
        string expectedUri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ";
        List<Models::SimplifiedArtistObject> expectedArtists =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "href",
                Name = "name",
                Published = true,
                Type = Models::SimplifiedArtistObjectType.Artist,
                Uri = "uri",
            },
        ];
        List<Models::CopyrightObject> expectedCopyrights =
        [
            new()
            {
                Published = true,
                Text = "text",
                Type = "type",
            },
        ];
        Models::ExternalIDObject expectedExternalIDs = new()
        {
            Ean = "ean",
            Isrc = "isrc",
            Published = true,
            Upc = "upc",
        };
        List<string> expectedGenres = ["string"];
        string expectedLabel = "label";
        long expectedPopularity = 0;
        bool expectedPublished = true;
        Models::AlbumRestrictionObject expectedRestrictions = new()
        {
            Published = true,
            Reason = Models::Reason.Market,
        };
        AlbumRetrieveResponseTracks expectedTracks = new()
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,
            Items =
            [
                new()
                {
                    ID = "id",
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    IsLocal = true,
                    IsPlayable = true,
                    LinkedFrom = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Published = true,
                        Type = "type",
                        Uri = "uri",
                    },
                    Name = "name",
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = "type",
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAlbumType, deserialized.AlbumType);
        Assert.Equal(expectedAvailableMarkets.Count, deserialized.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], deserialized.AvailableMarkets[i]);
        }
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedReleaseDate, deserialized.ReleaseDate);
        Assert.Equal(expectedReleaseDatePrecision, deserialized.ReleaseDatePrecision);
        Assert.Equal(expectedTotalTracks, deserialized.TotalTracks);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.NotNull(deserialized.Artists);
        Assert.Equal(expectedArtists.Count, deserialized.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], deserialized.Artists[i]);
        }
        Assert.NotNull(deserialized.Copyrights);
        Assert.Equal(expectedCopyrights.Count, deserialized.Copyrights.Count);
        for (int i = 0; i < expectedCopyrights.Count; i++)
        {
            Assert.Equal(expectedCopyrights[i], deserialized.Copyrights[i]);
        }
        Assert.Equal(expectedExternalIDs, deserialized.ExternalIDs);
        Assert.NotNull(deserialized.Genres);
        Assert.Equal(expectedGenres.Count, deserialized.Genres.Count);
        for (int i = 0; i < expectedGenres.Count; i++)
        {
            Assert.Equal(expectedGenres[i], deserialized.Genres[i]);
        }
        Assert.Equal(expectedLabel, deserialized.Label);
        Assert.Equal(expectedPopularity, deserialized.Popularity);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedRestrictions, deserialized.Restrictions);
        Assert.Equal(expectedTracks, deserialized.Tracks);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AlbumRetrieveResponse
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            Copyrights =
            [
                new()
                {
                    Published = true,
                    Text = "text",
                    Type = "type",
                },
            ],
            ExternalIDs = new()
            {
                Ean = "ean",
                Isrc = "isrc",
                Published = true,
                Upc = "upc",
            },
            Genres = ["string"],
            Label = "label",
            Popularity = 0,
            Published = true,
            Restrictions = new() { Published = true, Reason = Models::Reason.Market },
            Tracks = new()
            {
                Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
                Limit = 20,
                Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
                Offset = 0,
                Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
                Total = 4,
                Items =
                [
                    new()
                    {
                        ID = "id",
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["string"],
                        DiscNumber = 0,
                        DurationMs = 0,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        IsLocal = true,
                        IsPlayable = true,
                        LinkedFrom = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Published = true,
                            Type = "type",
                            Uri = "uri",
                        },
                        Name = "name",
                        PreviewURL = "preview_url",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        TrackNumber = 0,
                        Type = "type",
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AlbumRetrieveResponse
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
        };

        Assert.Null(model.Artists);
        Assert.False(model.RawData.ContainsKey("artists"));
        Assert.Null(model.Copyrights);
        Assert.False(model.RawData.ContainsKey("copyrights"));
        Assert.Null(model.ExternalIDs);
        Assert.False(model.RawData.ContainsKey("external_ids"));
        Assert.Null(model.Genres);
        Assert.False(model.RawData.ContainsKey("genres"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.Popularity);
        Assert.False(model.RawData.ContainsKey("popularity"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
        Assert.Null(model.Tracks);
        Assert.False(model.RawData.ContainsKey("tracks"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AlbumRetrieveResponse
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AlbumRetrieveResponse
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",

            // Null should be interpreted as omitted for these properties
            Artists = null,
            Copyrights = null,
            ExternalIDs = null,
            Genres = null,
            Label = null,
            Popularity = null,
            Published = null,
            Restrictions = null,
            Tracks = null,
        };

        Assert.Null(model.Artists);
        Assert.False(model.RawData.ContainsKey("artists"));
        Assert.Null(model.Copyrights);
        Assert.False(model.RawData.ContainsKey("copyrights"));
        Assert.Null(model.ExternalIDs);
        Assert.False(model.RawData.ContainsKey("external_ids"));
        Assert.Null(model.Genres);
        Assert.False(model.RawData.ContainsKey("genres"));
        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
        Assert.Null(model.Popularity);
        Assert.False(model.RawData.ContainsKey("popularity"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
        Assert.Null(model.Tracks);
        Assert.False(model.RawData.ContainsKey("tracks"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AlbumRetrieveResponse
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",

            // Null should be interpreted as omitted for these properties
            Artists = null,
            Copyrights = null,
            ExternalIDs = null,
            Genres = null,
            Label = null,
            Popularity = null,
            Published = null,
            Restrictions = null,
            Tracks = null,
        };

        model.Validate();
    }
}

public class AlbumTypeTest : TestBase
{
    [Theory]
    [InlineData(AlbumType.Album)]
    [InlineData(AlbumType.Single)]
    [InlineData(AlbumType.Compilation)]
    public void Validation_Works(AlbumType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlbumType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AlbumType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlbumType.Album)]
    [InlineData(AlbumType.Single)]
    [InlineData(AlbumType.Compilation)]
    public void SerializationRoundtrip_Works(AlbumType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlbumType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AlbumType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AlbumType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AlbumType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ReleaseDatePrecisionTest : TestBase
{
    [Theory]
    [InlineData(ReleaseDatePrecision.Year)]
    [InlineData(ReleaseDatePrecision.Month)]
    [InlineData(ReleaseDatePrecision.Day)]
    public void Validation_Works(ReleaseDatePrecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReleaseDatePrecision> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReleaseDatePrecision>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReleaseDatePrecision.Year)]
    [InlineData(ReleaseDatePrecision.Month)]
    [InlineData(ReleaseDatePrecision.Day)]
    public void SerializationRoundtrip_Works(ReleaseDatePrecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReleaseDatePrecision> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReleaseDatePrecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReleaseDatePrecision>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReleaseDatePrecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class AlbumRetrieveResponseTracksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AlbumRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,
            Items =
            [
                new()
                {
                    ID = "id",
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    IsLocal = true,
                    IsPlayable = true,
                    LinkedFrom = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Published = true,
                        Type = "type",
                        Uri = "uri",
                    },
                    Name = "name",
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = "type",
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::SimplifiedTrackObject> expectedItems =
        [
            new()
            {
                ID = "id",
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Published = true,
                        Type = Models::SimplifiedArtistObjectType.Artist,
                        Uri = "uri",
                    },
                ],
                AvailableMarkets = ["string"],
                DiscNumber = 0,
                DurationMs = 0,
                Explicit = true,
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "href",
                IsLocal = true,
                IsPlayable = true,
                LinkedFrom = new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Published = true,
                    Type = "type",
                    Uri = "uri",
                },
                Name = "name",
                PreviewURL = "preview_url",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                TrackNumber = 0,
                Type = "type",
                Uri = "uri",
            },
        ];
        bool expectedPublished = true;

        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedPrevious, model.Previous);
        Assert.Equal(expectedTotal, model.Total);
        Assert.NotNull(model.Items);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPublished, model.Published);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AlbumRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,
            Items =
            [
                new()
                {
                    ID = "id",
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    IsLocal = true,
                    IsPlayable = true,
                    LinkedFrom = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Published = true,
                        Type = "type",
                        Uri = "uri",
                    },
                    Name = "name",
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = "type",
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumRetrieveResponseTracks>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AlbumRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,
            Items =
            [
                new()
                {
                    ID = "id",
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    IsLocal = true,
                    IsPlayable = true,
                    LinkedFrom = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Published = true,
                        Type = "type",
                        Uri = "uri",
                    },
                    Name = "name",
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = "type",
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumRetrieveResponseTracks>(element);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::SimplifiedTrackObject> expectedItems =
        [
            new()
            {
                ID = "id",
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Published = true,
                        Type = Models::SimplifiedArtistObjectType.Artist,
                        Uri = "uri",
                    },
                ],
                AvailableMarkets = ["string"],
                DiscNumber = 0,
                DurationMs = 0,
                Explicit = true,
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "href",
                IsLocal = true,
                IsPlayable = true,
                LinkedFrom = new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Published = true,
                    Type = "type",
                    Uri = "uri",
                },
                Name = "name",
                PreviewURL = "preview_url",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                TrackNumber = 0,
                Type = "type",
                Uri = "uri",
            },
        ];
        bool expectedPublished = true;

        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedPrevious, deserialized.Previous);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.NotNull(deserialized.Items);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPublished, deserialized.Published);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AlbumRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,
            Items =
            [
                new()
                {
                    ID = "id",
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    IsLocal = true,
                    IsPlayable = true,
                    LinkedFrom = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Published = true,
                        Type = "type",
                        Uri = "uri",
                    },
                    Name = "name",
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = "type",
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AlbumRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AlbumRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AlbumRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,

            // Null should be interpreted as omitted for these properties
            Items = null,
            Published = null,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AlbumRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,

            // Null should be interpreted as omitted for these properties
            Items = null,
            Published = null,
        };

        model.Validate();
    }
}
