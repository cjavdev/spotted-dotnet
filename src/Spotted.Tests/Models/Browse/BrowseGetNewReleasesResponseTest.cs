using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Browse;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Browse;

public class BrowseGetNewReleasesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowseGetNewReleasesResponse
        {
            Albums = new()
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
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = ReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Restrictions = new() { Reason = Models::Reason.Market },
                    },
                ],
            },
        };

        BrowseGetNewReleasesResponseAlbums expectedAlbums = new()
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                        },
                    ],
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Restrictions = new() { Reason = Models::Reason.Market },
                },
            ],
        };

        Assert.Equal(expectedAlbums, model.Albums);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowseGetNewReleasesResponse
        {
            Albums = new()
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
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = ReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Restrictions = new() { Reason = Models::Reason.Market },
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowseGetNewReleasesResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowseGetNewReleasesResponse
        {
            Albums = new()
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
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = ReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Restrictions = new() { Reason = Models::Reason.Market },
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowseGetNewReleasesResponse>(json);
        Assert.NotNull(deserialized);

        BrowseGetNewReleasesResponseAlbums expectedAlbums = new()
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                        },
                    ],
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Restrictions = new() { Reason = Models::Reason.Market },
                },
            ],
        };

        Assert.Equal(expectedAlbums, deserialized.Albums);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowseGetNewReleasesResponse
        {
            Albums = new()
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
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Images =
                        [
                            new()
                            {
                                Height = 300,
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                            },
                        ],
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = ReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Restrictions = new() { Reason = Models::Reason.Market },
                    },
                ],
            },
        };

        model.Validate();
    }
}

public class BrowseGetNewReleasesResponseAlbumsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowseGetNewReleasesResponseAlbums
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                        },
                    ],
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Restrictions = new() { Reason = Models::Reason.Market },
                },
            ],
        };

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Item> expectedItems =
        [
            new()
            {
                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                AlbumType = AlbumType.Compilation,
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Type = Models::SimplifiedArtistObjectType.Artist,
                        Uri = "uri",
                    },
                ],
                AvailableMarkets = ["CA", "BR", "IT"],
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Images =
                [
                    new()
                    {
                        Height = 300,
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                    },
                ],
                Name = "name",
                ReleaseDate = "1981-12",
                ReleaseDatePrecision = ReleaseDatePrecision.Year,
                TotalTracks = 9,
                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                Restrictions = new() { Reason = Models::Reason.Market },
            },
        ];

        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedPrevious, model.Previous);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowseGetNewReleasesResponseAlbums
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                        },
                    ],
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Restrictions = new() { Reason = Models::Reason.Market },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowseGetNewReleasesResponseAlbums>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowseGetNewReleasesResponseAlbums
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                        },
                    ],
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Restrictions = new() { Reason = Models::Reason.Market },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowseGetNewReleasesResponseAlbums>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Item> expectedItems =
        [
            new()
            {
                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                AlbumType = AlbumType.Compilation,
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Type = Models::SimplifiedArtistObjectType.Artist,
                        Uri = "uri",
                    },
                ],
                AvailableMarkets = ["CA", "BR", "IT"],
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Images =
                [
                    new()
                    {
                        Height = 300,
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                    },
                ],
                Name = "name",
                ReleaseDate = "1981-12",
                ReleaseDatePrecision = ReleaseDatePrecision.Year,
                TotalTracks = 9,
                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                Restrictions = new() { Reason = Models::Reason.Market },
            },
        ];

        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedPrevious, deserialized.Previous);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowseGetNewReleasesResponseAlbums
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                        },
                    ],
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Restrictions = new() { Reason = Models::Reason.Market },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowseGetNewReleasesResponseAlbums
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowseGetNewReleasesResponseAlbums
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
        var model = new BrowseGetNewReleasesResponseAlbums
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,

            // Null should be interpreted as omitted for these properties
            Items = null,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowseGetNewReleasesResponseAlbums
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,

            // Null should be interpreted as omitted for these properties
            Items = null,
        };

        model.Validate();
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Restrictions = new() { Reason = Models::Reason.Market },
        };

        string expectedID = "2up3OPMp9Tb4dAKM2erWXQ";
        ApiEnum<string, AlbumType> expectedAlbumType = AlbumType.Compilation;
        List<Models::SimplifiedArtistObject> expectedArtists =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Name = "name",
                Type = Models::SimplifiedArtistObjectType.Artist,
                Uri = "uri",
            },
        ];
        List<string> expectedAvailableMarkets = ["CA", "BR", "IT"];
        Models::ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        string expectedHref = "href";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        string expectedName = "name";
        string expectedReleaseDate = "1981-12";
        ApiEnum<string, ReleaseDatePrecision> expectedReleaseDatePrecision =
            ReleaseDatePrecision.Year;
        long expectedTotalTracks = 9;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"album\"");
        string expectedUri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ";
        Models::AlbumRestrictionObject expectedRestrictions = new()
        {
            Reason = Models::Reason.Market,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAlbumType, model.AlbumType);
        Assert.Equal(expectedArtists.Count, model.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], model.Artists[i]);
        }
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
        Assert.Equal(expectedRestrictions, model.Restrictions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Restrictions = new() { Reason = Models::Reason.Market },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Restrictions = new() { Reason = Models::Reason.Market },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);
        Assert.NotNull(deserialized);

        string expectedID = "2up3OPMp9Tb4dAKM2erWXQ";
        ApiEnum<string, AlbumType> expectedAlbumType = AlbumType.Compilation;
        List<Models::SimplifiedArtistObject> expectedArtists =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Name = "name",
                Type = Models::SimplifiedArtistObjectType.Artist,
                Uri = "uri",
            },
        ];
        List<string> expectedAvailableMarkets = ["CA", "BR", "IT"];
        Models::ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        string expectedHref = "href";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        string expectedName = "name";
        string expectedReleaseDate = "1981-12";
        ApiEnum<string, ReleaseDatePrecision> expectedReleaseDatePrecision =
            ReleaseDatePrecision.Year;
        long expectedTotalTracks = 9;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"album\"");
        string expectedUri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ";
        Models::AlbumRestrictionObject expectedRestrictions = new()
        {
            Reason = Models::Reason.Market,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAlbumType, deserialized.AlbumType);
        Assert.Equal(expectedArtists.Count, deserialized.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], deserialized.Artists[i]);
        }
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
        Assert.Equal(expectedRestrictions, deserialized.Restrictions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Restrictions = new() { Reason = Models::Reason.Market },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
        };

        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
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
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",

            // Null should be interpreted as omitted for these properties
            Restrictions = null,
        };

        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Images =
            [
                new()
                {
                    Height = 300,
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                },
            ],
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",

            // Null should be interpreted as omitted for these properties
            Restrictions = null,
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
