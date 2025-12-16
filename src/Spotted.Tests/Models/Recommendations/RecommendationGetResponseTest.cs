using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Recommendations;

namespace Spotted.Tests.Models.Recommendations;

public class RecommendationGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecommendationGetResponse
        {
            Seeds =
            [
                new()
                {
                    ID = "id",
                    AfterFilteringSize = 0,
                    AfterRelinkingSize = 0,
                    Href = "href",
                    InitialPoolSize = 0,
                    Published = true,
                    Type = "type",
                },
            ],
            Tracks =
            [
                new()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalIDs = new()
                    {
                        Ean = "ean",
                        Isrc = "isrc",
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        List<Seed> expectedSeeds =
        [
            new()
            {
                ID = "id",
                AfterFilteringSize = 0,
                AfterRelinkingSize = 0,
                Href = "href",
                InitialPoolSize = 0,
                Published = true,
                Type = "type",
            },
        ];
        List<TrackObject> expectedTracks =
        [
            new()
            {
                ID = "id",
                Album = new()
                {
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Reason.Market },
                },
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Published = true,
                        Type = SimplifiedArtistObjectType.Artist,
                        Uri = "uri",
                    },
                ],
                AvailableMarkets = ["string"],
                DiscNumber = 0,
                DurationMs = 0,
                Explicit = true,
                ExternalIDs = new()
                {
                    Ean = "ean",
                    Isrc = "isrc",
                    Published = true,
                    Upc = "upc",
                },
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
                Popularity = 0,
                PreviewURL = "preview_url",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                TrackNumber = 0,
                Type = TrackObjectType.Track,
                Uri = "uri",
            },
        ];
        bool expectedPublished = true;

        Assert.Equal(expectedSeeds.Count, model.Seeds.Count);
        for (int i = 0; i < expectedSeeds.Count; i++)
        {
            Assert.Equal(expectedSeeds[i], model.Seeds[i]);
        }
        Assert.Equal(expectedTracks.Count, model.Tracks.Count);
        for (int i = 0; i < expectedTracks.Count; i++)
        {
            Assert.Equal(expectedTracks[i], model.Tracks[i]);
        }
        Assert.Equal(expectedPublished, model.Published);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecommendationGetResponse
        {
            Seeds =
            [
                new()
                {
                    ID = "id",
                    AfterFilteringSize = 0,
                    AfterRelinkingSize = 0,
                    Href = "href",
                    InitialPoolSize = 0,
                    Published = true,
                    Type = "type",
                },
            ],
            Tracks =
            [
                new()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalIDs = new()
                    {
                        Ean = "ean",
                        Isrc = "isrc",
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RecommendationGetResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecommendationGetResponse
        {
            Seeds =
            [
                new()
                {
                    ID = "id",
                    AfterFilteringSize = 0,
                    AfterRelinkingSize = 0,
                    Href = "href",
                    InitialPoolSize = 0,
                    Published = true,
                    Type = "type",
                },
            ],
            Tracks =
            [
                new()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalIDs = new()
                    {
                        Ean = "ean",
                        Isrc = "isrc",
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RecommendationGetResponse>(json);
        Assert.NotNull(deserialized);

        List<Seed> expectedSeeds =
        [
            new()
            {
                ID = "id",
                AfterFilteringSize = 0,
                AfterRelinkingSize = 0,
                Href = "href",
                InitialPoolSize = 0,
                Published = true,
                Type = "type",
            },
        ];
        List<TrackObject> expectedTracks =
        [
            new()
            {
                ID = "id",
                Album = new()
                {
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Reason.Market },
                },
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Published = true,
                        Type = SimplifiedArtistObjectType.Artist,
                        Uri = "uri",
                    },
                ],
                AvailableMarkets = ["string"],
                DiscNumber = 0,
                DurationMs = 0,
                Explicit = true,
                ExternalIDs = new()
                {
                    Ean = "ean",
                    Isrc = "isrc",
                    Published = true,
                    Upc = "upc",
                },
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
                Popularity = 0,
                PreviewURL = "preview_url",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                TrackNumber = 0,
                Type = TrackObjectType.Track,
                Uri = "uri",
            },
        ];
        bool expectedPublished = true;

        Assert.Equal(expectedSeeds.Count, deserialized.Seeds.Count);
        for (int i = 0; i < expectedSeeds.Count; i++)
        {
            Assert.Equal(expectedSeeds[i], deserialized.Seeds[i]);
        }
        Assert.Equal(expectedTracks.Count, deserialized.Tracks.Count);
        for (int i = 0; i < expectedTracks.Count; i++)
        {
            Assert.Equal(expectedTracks[i], deserialized.Tracks[i]);
        }
        Assert.Equal(expectedPublished, deserialized.Published);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecommendationGetResponse
        {
            Seeds =
            [
                new()
                {
                    ID = "id",
                    AfterFilteringSize = 0,
                    AfterRelinkingSize = 0,
                    Href = "href",
                    InitialPoolSize = 0,
                    Published = true,
                    Type = "type",
                },
            ],
            Tracks =
            [
                new()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalIDs = new()
                    {
                        Ean = "ean",
                        Isrc = "isrc",
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
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
        var model = new RecommendationGetResponse
        {
            Seeds =
            [
                new()
                {
                    ID = "id",
                    AfterFilteringSize = 0,
                    AfterRelinkingSize = 0,
                    Href = "href",
                    InitialPoolSize = 0,
                    Published = true,
                    Type = "type",
                },
            ],
            Tracks =
            [
                new()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalIDs = new()
                    {
                        Ean = "ean",
                        Isrc = "isrc",
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecommendationGetResponse
        {
            Seeds =
            [
                new()
                {
                    ID = "id",
                    AfterFilteringSize = 0,
                    AfterRelinkingSize = 0,
                    Href = "href",
                    InitialPoolSize = 0,
                    Published = true,
                    Type = "type",
                },
            ],
            Tracks =
            [
                new()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalIDs = new()
                    {
                        Ean = "ean",
                        Isrc = "isrc",
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RecommendationGetResponse
        {
            Seeds =
            [
                new()
                {
                    ID = "id",
                    AfterFilteringSize = 0,
                    AfterRelinkingSize = 0,
                    Href = "href",
                    InitialPoolSize = 0,
                    Published = true,
                    Type = "type",
                },
            ],
            Tracks =
            [
                new()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalIDs = new()
                    {
                        Ean = "ean",
                        Isrc = "isrc",
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecommendationGetResponse
        {
            Seeds =
            [
                new()
                {
                    ID = "id",
                    AfterFilteringSize = 0,
                    AfterRelinkingSize = 0,
                    Href = "href",
                    InitialPoolSize = 0,
                    Published = true,
                    Type = "type",
                },
            ],
            Tracks =
            [
                new()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["string"],
                    DiscNumber = 0,
                    DurationMs = 0,
                    Explicit = true,
                    ExternalIDs = new()
                    {
                        Ean = "ean",
                        Isrc = "isrc",
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            ],

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        model.Validate();
    }
}

public class SeedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Seed
        {
            ID = "id",
            AfterFilteringSize = 0,
            AfterRelinkingSize = 0,
            Href = "href",
            InitialPoolSize = 0,
            Published = true,
            Type = "type",
        };

        string expectedID = "id";
        long expectedAfterFilteringSize = 0;
        long expectedAfterRelinkingSize = 0;
        string expectedHref = "href";
        long expectedInitialPoolSize = 0;
        bool expectedPublished = true;
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAfterFilteringSize, model.AfterFilteringSize);
        Assert.Equal(expectedAfterRelinkingSize, model.AfterRelinkingSize);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedInitialPoolSize, model.InitialPoolSize);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Seed
        {
            ID = "id",
            AfterFilteringSize = 0,
            AfterRelinkingSize = 0,
            Href = "href",
            InitialPoolSize = 0,
            Published = true,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Seed>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Seed
        {
            ID = "id",
            AfterFilteringSize = 0,
            AfterRelinkingSize = 0,
            Href = "href",
            InitialPoolSize = 0,
            Published = true,
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Seed>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedAfterFilteringSize = 0;
        long expectedAfterRelinkingSize = 0;
        string expectedHref = "href";
        long expectedInitialPoolSize = 0;
        bool expectedPublished = true;
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAfterFilteringSize, deserialized.AfterFilteringSize);
        Assert.Equal(expectedAfterRelinkingSize, deserialized.AfterRelinkingSize);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedInitialPoolSize, deserialized.InitialPoolSize);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Seed
        {
            ID = "id",
            AfterFilteringSize = 0,
            AfterRelinkingSize = 0,
            Href = "href",
            InitialPoolSize = 0,
            Published = true,
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Seed { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AfterFilteringSize);
        Assert.False(model.RawData.ContainsKey("afterFilteringSize"));
        Assert.Null(model.AfterRelinkingSize);
        Assert.False(model.RawData.ContainsKey("afterRelinkingSize"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.InitialPoolSize);
        Assert.False(model.RawData.ContainsKey("initialPoolSize"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Seed { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Seed
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AfterFilteringSize = null,
            AfterRelinkingSize = null,
            Href = null,
            InitialPoolSize = null,
            Published = null,
            Type = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AfterFilteringSize);
        Assert.False(model.RawData.ContainsKey("afterFilteringSize"));
        Assert.Null(model.AfterRelinkingSize);
        Assert.False(model.RawData.ContainsKey("afterRelinkingSize"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.InitialPoolSize);
        Assert.False(model.RawData.ContainsKey("initialPoolSize"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Seed
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AfterFilteringSize = null,
            AfterRelinkingSize = null,
            Href = null,
            InitialPoolSize = null,
            Published = null,
            Type = null,
        };

        model.Validate();
    }
}
