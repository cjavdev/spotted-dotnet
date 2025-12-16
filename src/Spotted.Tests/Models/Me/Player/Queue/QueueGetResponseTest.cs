using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Me.Player.Queue;

namespace Spotted.Tests.Models.Me.Player.Queue;

public class QueueGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new QueueGetResponse
        {
            CurrentlyPlaying = new TrackObject()
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
            Published = true,
            Queue =
            [
                new TrackObject()
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

        CurrentlyPlaying expectedCurrentlyPlaying = new TrackObject()
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        };
        bool expectedPublished = true;
        List<QueueGetResponseQueue> expectedQueue =
        [
            new TrackObject()
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

        Assert.Equal(expectedCurrentlyPlaying, model.CurrentlyPlaying);
        Assert.Equal(expectedPublished, model.Published);
        Assert.NotNull(model.Queue);
        Assert.Equal(expectedQueue.Count, model.Queue.Count);
        for (int i = 0; i < expectedQueue.Count; i++)
        {
            Assert.Equal(expectedQueue[i], model.Queue[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new QueueGetResponse
        {
            CurrentlyPlaying = new TrackObject()
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
            Published = true,
            Queue =
            [
                new TrackObject()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<QueueGetResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new QueueGetResponse
        {
            CurrentlyPlaying = new TrackObject()
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
            Published = true,
            Queue =
            [
                new TrackObject()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<QueueGetResponse>(json);
        Assert.NotNull(deserialized);

        CurrentlyPlaying expectedCurrentlyPlaying = new TrackObject()
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        };
        bool expectedPublished = true;
        List<QueueGetResponseQueue> expectedQueue =
        [
            new TrackObject()
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

        Assert.Equal(expectedCurrentlyPlaying, deserialized.CurrentlyPlaying);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.NotNull(deserialized.Queue);
        Assert.Equal(expectedQueue.Count, deserialized.Queue.Count);
        for (int i = 0; i < expectedQueue.Count; i++)
        {
            Assert.Equal(expectedQueue[i], deserialized.Queue[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new QueueGetResponse
        {
            CurrentlyPlaying = new TrackObject()
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
            Published = true,
            Queue =
            [
                new TrackObject()
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
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new QueueGetResponse { };

        Assert.Null(model.CurrentlyPlaying);
        Assert.False(model.RawData.ContainsKey("currently_playing"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Queue);
        Assert.False(model.RawData.ContainsKey("queue"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new QueueGetResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new QueueGetResponse
        {
            // Null should be interpreted as omitted for these properties
            CurrentlyPlaying = null,
            Published = null,
            Queue = null,
        };

        Assert.Null(model.CurrentlyPlaying);
        Assert.False(model.RawData.ContainsKey("currently_playing"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Queue);
        Assert.False(model.RawData.ContainsKey("queue"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new QueueGetResponse
        {
            // Null should be interpreted as omitted for these properties
            CurrentlyPlaying = null,
            Published = null,
            Queue = null,
        };

        model.Validate();
    }
}

public class CurrentlyPlayingTest : TestBase
{
    [Fact]
    public void track_objectValidation_Works()
    {
        CurrentlyPlaying value = new(
            new TrackObject()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void episode_objectValidation_Works()
    {
        CurrentlyPlaying value = new(
            new EpisodeObject()
            {
                ID = "5Xt5DXGzch68nYYamXrNxZ",
                AudioPreviewURL =
                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                Description =
                    "A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.\n",
                DurationMs = 1686230,
                Explicit = true,
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                HTMLDescription =
                    "<p>A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.</p>\n",
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
                IsExternallyHosted = true,
                IsPlayable = true,
                Languages = ["fr", "en"],
                Name = "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                ReleaseDate = "1981-12-15",
                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                Show = new()
                {
                    ID = "id",
                    AvailableMarkets = ["string"],
                    Copyrights =
                    [
                        new()
                        {
                            Published = true,
                            Text = "text",
                            Type = "type",
                        },
                    ],
                    Description = "description",
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    HTMLDescription = "html_description",
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
                    IsExternallyHosted = true,
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Publisher = "publisher",
                    TotalEpisodes = 0,
                    Uri = "uri",
                    Published = true,
                },
                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                Language = "en",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                ResumePoint = new()
                {
                    FullyPlayed = true,
                    Published = true,
                    ResumePositionMs = 0,
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void track_objectSerializationRoundtrip_Works()
    {
        CurrentlyPlaying value = new(
            new TrackObject()
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CurrentlyPlaying>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void episode_objectSerializationRoundtrip_Works()
    {
        CurrentlyPlaying value = new(
            new EpisodeObject()
            {
                ID = "5Xt5DXGzch68nYYamXrNxZ",
                AudioPreviewURL =
                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                Description =
                    "A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.\n",
                DurationMs = 1686230,
                Explicit = true,
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                HTMLDescription =
                    "<p>A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.</p>\n",
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
                IsExternallyHosted = true,
                IsPlayable = true,
                Languages = ["fr", "en"],
                Name = "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                ReleaseDate = "1981-12-15",
                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                Show = new()
                {
                    ID = "id",
                    AvailableMarkets = ["string"],
                    Copyrights =
                    [
                        new()
                        {
                            Published = true,
                            Text = "text",
                            Type = "type",
                        },
                    ],
                    Description = "description",
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    HTMLDescription = "html_description",
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
                    IsExternallyHosted = true,
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Publisher = "publisher",
                    TotalEpisodes = 0,
                    Uri = "uri",
                    Published = true,
                },
                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                Language = "en",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                ResumePoint = new()
                {
                    FullyPlayed = true,
                    Published = true,
                    ResumePositionMs = 0,
                },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<CurrentlyPlaying>(json);

        Assert.Equal(value, deserialized);
    }
}

public class QueueGetResponseQueueTest : TestBase
{
    [Fact]
    public void track_objectValidation_Works()
    {
        QueueGetResponseQueue value = new(
            new TrackObject()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void episode_objectValidation_Works()
    {
        QueueGetResponseQueue value = new(
            new EpisodeObject()
            {
                ID = "5Xt5DXGzch68nYYamXrNxZ",
                AudioPreviewURL =
                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                Description =
                    "A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.\n",
                DurationMs = 1686230,
                Explicit = true,
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                HTMLDescription =
                    "<p>A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.</p>\n",
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
                IsExternallyHosted = true,
                IsPlayable = true,
                Languages = ["fr", "en"],
                Name = "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                ReleaseDate = "1981-12-15",
                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                Show = new()
                {
                    ID = "id",
                    AvailableMarkets = ["string"],
                    Copyrights =
                    [
                        new()
                        {
                            Published = true,
                            Text = "text",
                            Type = "type",
                        },
                    ],
                    Description = "description",
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    HTMLDescription = "html_description",
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
                    IsExternallyHosted = true,
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Publisher = "publisher",
                    TotalEpisodes = 0,
                    Uri = "uri",
                    Published = true,
                },
                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                Language = "en",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                ResumePoint = new()
                {
                    FullyPlayed = true,
                    Published = true,
                    ResumePositionMs = 0,
                },
            }
        );
        value.Validate();
    }

    [Fact]
    public void track_objectSerializationRoundtrip_Works()
    {
        QueueGetResponseQueue value = new(
            new TrackObject()
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
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<QueueGetResponseQueue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void episode_objectSerializationRoundtrip_Works()
    {
        QueueGetResponseQueue value = new(
            new EpisodeObject()
            {
                ID = "5Xt5DXGzch68nYYamXrNxZ",
                AudioPreviewURL =
                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                Description =
                    "A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.\n",
                DurationMs = 1686230,
                Explicit = true,
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                HTMLDescription =
                    "<p>A Spotify podcast sharing fresh insights on important topics of the moment—in a way only Spotify can. You’ll hear from experts in the music, podcast and tech industries as we discover and uncover stories about our work and the world around us.</p>\n",
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
                IsExternallyHosted = true,
                IsPlayable = true,
                Languages = ["fr", "en"],
                Name = "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                ReleaseDate = "1981-12-15",
                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                Show = new()
                {
                    ID = "id",
                    AvailableMarkets = ["string"],
                    Copyrights =
                    [
                        new()
                        {
                            Published = true,
                            Text = "text",
                            Type = "type",
                        },
                    ],
                    Description = "description",
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    HTMLDescription = "html_description",
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
                    IsExternallyHosted = true,
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Publisher = "publisher",
                    TotalEpisodes = 0,
                    Uri = "uri",
                    Published = true,
                },
                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                Language = "en",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                ResumePoint = new()
                {
                    FullyPlayed = true,
                    Published = true,
                    ResumePositionMs = 0,
                },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<QueueGetResponseQueue>(json);

        Assert.Equal(value, deserialized);
    }
}
