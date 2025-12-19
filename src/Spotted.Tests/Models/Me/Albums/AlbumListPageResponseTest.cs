using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Me.Albums;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Me.Albums;

public class AlbumListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AlbumListPageResponse
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
                    Album = new()
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
                                            ExternalURLs = new()
                                            {
                                                Published = true,
                                                Spotify = "spotify",
                                            },
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
                                        ExternalURLs = new()
                                        {
                                            Published = true,
                                            Spotify = "spotify",
                                        },
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
                    },
                    Published = true,
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
        List<AlbumListResponse> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Album = new()
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
                                        ExternalURLs = new()
                                        {
                                            Published = true,
                                            Spotify = "spotify",
                                        },
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
                },
                Published = true,
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
        var model = new AlbumListPageResponse
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
                    Album = new()
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
                                            ExternalURLs = new()
                                            {
                                                Published = true,
                                                Spotify = "spotify",
                                            },
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
                                        ExternalURLs = new()
                                        {
                                            Published = true,
                                            Spotify = "spotify",
                                        },
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
                    },
                    Published = true,
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AlbumListPageResponse
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
                    Album = new()
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
                                            ExternalURLs = new()
                                            {
                                                Published = true,
                                                Spotify = "spotify",
                                            },
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
                                        ExternalURLs = new()
                                        {
                                            Published = true,
                                            Spotify = "spotify",
                                        },
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
                    },
                    Published = true,
                },
            ],
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumListPageResponse>(element);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<AlbumListResponse> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Album = new()
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
                                        ExternalURLs = new()
                                        {
                                            Published = true,
                                            Spotify = "spotify",
                                        },
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
                },
                Published = true,
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
        var model = new AlbumListPageResponse
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
                    Album = new()
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
                                            ExternalURLs = new()
                                            {
                                                Published = true,
                                                Spotify = "spotify",
                                            },
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
                                        ExternalURLs = new()
                                        {
                                            Published = true,
                                            Spotify = "spotify",
                                        },
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
                    },
                    Published = true,
                },
            ],
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AlbumListPageResponse
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
        var model = new AlbumListPageResponse
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
        var model = new AlbumListPageResponse
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
        var model = new AlbumListPageResponse
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
