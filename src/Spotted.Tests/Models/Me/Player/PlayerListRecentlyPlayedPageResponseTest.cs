using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerListRecentlyPlayedPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponse
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    Context = new()
                    {
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = "type",
                        Uri = "uri",
                    },
                    PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Track = new()
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
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        Cursors expectedCursors = new() { After = "after", Before = "before" };
        string expectedHref = "href";
        List<PlayerListRecentlyPlayedPageResponseItem> expectedItems =
        [
            new()
            {
                Context = new()
                {
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Type = "type",
                    Uri = "uri",
                },
                PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Track = new()
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
        long expectedLimit = 0;
        string expectedNext = "next";
        long expectedTotal = 0;

        Assert.Equal(expectedCursors, model.Cursors);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponse
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    Context = new()
                    {
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = "type",
                        Uri = "uri",
                    },
                    PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Track = new()
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
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlayerListRecentlyPlayedPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponse
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    Context = new()
                    {
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = "type",
                        Uri = "uri",
                    },
                    PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Track = new()
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
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlayerListRecentlyPlayedPageResponse>(json);
        Assert.NotNull(deserialized);

        Cursors expectedCursors = new() { After = "after", Before = "before" };
        string expectedHref = "href";
        List<PlayerListRecentlyPlayedPageResponseItem> expectedItems =
        [
            new()
            {
                Context = new()
                {
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Type = "type",
                    Uri = "uri",
                },
                PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Track = new()
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
        long expectedLimit = 0;
        string expectedNext = "next";
        long expectedTotal = 0;

        Assert.Equal(expectedCursors, deserialized.Cursors);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponse
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    Context = new()
                    {
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = "type",
                        Uri = "uri",
                    },
                    PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Track = new()
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
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponse { };

        Assert.Null(model.Cursors);
        Assert.False(model.RawData.ContainsKey("cursors"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Next);
        Assert.False(model.RawData.ContainsKey("next"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponse
        {
            // Null should be interpreted as omitted for these properties
            Cursors = null,
            Href = null,
            Items = null,
            Limit = null,
            Next = null,
            Total = null,
        };

        Assert.Null(model.Cursors);
        Assert.False(model.RawData.ContainsKey("cursors"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.Limit);
        Assert.False(model.RawData.ContainsKey("limit"));
        Assert.Null(model.Next);
        Assert.False(model.RawData.ContainsKey("next"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponse
        {
            // Null should be interpreted as omitted for these properties
            Cursors = null,
            Href = null,
            Items = null,
            Limit = null,
            Next = null,
            Total = null,
        };

        model.Validate();
    }
}

public class CursorsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        string expectedAfter = "after";
        string expectedBefore = "before";

        Assert.Equal(expectedAfter, model.After);
        Assert.Equal(expectedBefore, model.Before);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Cursors>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Cursors>(json);
        Assert.NotNull(deserialized);

        string expectedAfter = "after";
        string expectedBefore = "before";

        Assert.Equal(expectedAfter, deserialized.After);
        Assert.Equal(expectedBefore, deserialized.Before);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cursors { After = "after", Before = "before" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Cursors { };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Cursors { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Cursors
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
        };

        Assert.Null(model.After);
        Assert.False(model.RawData.ContainsKey("after"));
        Assert.Null(model.Before);
        Assert.False(model.RawData.ContainsKey("before"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Cursors
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
        };

        model.Validate();
    }
}

public class PlayerListRecentlyPlayedPageResponseItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponseItem
        {
            Context = new()
            {
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = "type",
                Uri = "uri",
            },
            PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Track = new()
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
        };

        ContextObject expectedContext = new()
        {
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = "type",
            Uri = "uri",
        };
        DateTimeOffset expectedPlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        TrackObject expectedTrack = new()
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        };

        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedPlayedAt, model.PlayedAt);
        Assert.Equal(expectedTrack, model.Track);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponseItem
        {
            Context = new()
            {
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = "type",
                Uri = "uri",
            },
            PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Track = new()
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlayerListRecentlyPlayedPageResponseItem>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponseItem
        {
            Context = new()
            {
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = "type",
                Uri = "uri",
            },
            PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Track = new()
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlayerListRecentlyPlayedPageResponseItem>(
            json
        );
        Assert.NotNull(deserialized);

        ContextObject expectedContext = new()
        {
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = "type",
            Uri = "uri",
        };
        DateTimeOffset expectedPlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        TrackObject expectedTrack = new()
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        };

        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedPlayedAt, deserialized.PlayedAt);
        Assert.Equal(expectedTrack, deserialized.Track);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponseItem
        {
            Context = new()
            {
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = "type",
                Uri = "uri",
            },
            PlayedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Track = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponseItem { };

        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.PlayedAt);
        Assert.False(model.RawData.ContainsKey("played_at"));
        Assert.Null(model.Track);
        Assert.False(model.RawData.ContainsKey("track"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponseItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponseItem
        {
            // Null should be interpreted as omitted for these properties
            Context = null,
            PlayedAt = null,
            Track = null,
        };

        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.PlayedAt);
        Assert.False(model.RawData.ContainsKey("played_at"));
        Assert.Null(model.Track);
        Assert.False(model.RawData.ContainsKey("track"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlayerListRecentlyPlayedPageResponseItem
        {
            // Null should be interpreted as omitted for these properties
            Context = null,
            PlayedAt = null,
            Track = null,
        };

        model.Validate();
    }
}
