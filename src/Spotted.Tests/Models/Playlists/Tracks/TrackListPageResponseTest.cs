using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Playlists.Tracks;

namespace Spotted.Tests.Models.Playlists.Tracks;

public class TrackListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrackListPageResponse
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
                    AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new TrackObject()
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
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
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
                            Upc = "upc",
                        },
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        IsLocal = true,
                        IsPlayable = true,
                        LinkedFrom = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = "type",
                            Uri = "uri",
                        },
                        Name = "name",
                        Popularity = 0,
                        PreviewURL = "preview_url",
                        Restrictions = new() { Reason = "reason" },
                        TrackNumber = 0,
                        Type = TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<PlaylistTrackObject> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AddedBy = new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Type = PlaylistUserObjectType.User,
                    Uri = "uri",
                },
                IsLocal = true,
                Track = new TrackObject()
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
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = SimplifiedArtistObjectType.Artist,
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
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Restrictions = new() { Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
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
                        Upc = "upc",
                    },
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    IsLocal = true,
                    IsPlayable = true,
                    LinkedFrom = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = "type",
                        Uri = "uri",
                    },
                    Name = "name",
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Restrictions = new() { Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            },
        ];

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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TrackListPageResponse
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
                    AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new TrackObject()
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
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
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
                            Upc = "upc",
                        },
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        IsLocal = true,
                        IsPlayable = true,
                        LinkedFrom = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = "type",
                            Uri = "uri",
                        },
                        Name = "name",
                        Popularity = 0,
                        PreviewURL = "preview_url",
                        Restrictions = new() { Reason = "reason" },
                        TrackNumber = 0,
                        Type = TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrackListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrackListPageResponse
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
                    AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new TrackObject()
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
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
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
                            Upc = "upc",
                        },
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        IsLocal = true,
                        IsPlayable = true,
                        LinkedFrom = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = "type",
                            Uri = "uri",
                        },
                        Name = "name",
                        Popularity = 0,
                        PreviewURL = "preview_url",
                        Restrictions = new() { Reason = "reason" },
                        TrackNumber = 0,
                        Type = TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrackListPageResponse>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<PlaylistTrackObject> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AddedBy = new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Type = PlaylistUserObjectType.User,
                    Uri = "uri",
                },
                IsLocal = true,
                Track = new TrackObject()
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
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = SimplifiedArtistObjectType.Artist,
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
                        ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Restrictions = new() { Reason = Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
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
                        Upc = "upc",
                    },
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    IsLocal = true,
                    IsPlayable = true,
                    LinkedFrom = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = "type",
                        Uri = "uri",
                    },
                    Name = "name",
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Restrictions = new() { Reason = "reason" },
                    TrackNumber = 0,
                    Type = TrackObjectType.Track,
                    Uri = "uri",
                },
            },
        ];

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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TrackListPageResponse
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
                    AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new TrackObject()
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
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
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
                            Upc = "upc",
                        },
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        IsLocal = true,
                        IsPlayable = true,
                        LinkedFrom = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = "type",
                            Uri = "uri",
                        },
                        Name = "name",
                        Popularity = 0,
                        PreviewURL = "preview_url",
                        Restrictions = new() { Reason = "reason" },
                        TrackNumber = 0,
                        Type = TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TrackListPageResponse
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
        var model = new TrackListPageResponse
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
        var model = new TrackListPageResponse
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
        var model = new TrackListPageResponse
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
