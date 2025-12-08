using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Me.Following;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Me.Following;

public class FollowingBulkRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FollowingBulkRetrieveResponse
        {
            Artists = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                Href = "href",
                Items =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Followers = new() { Href = "href", Total = 0 },
                        Genres = ["Prog rock", "Grunge"],
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
                        Popularity = 0,
                        Type = Models::Type.Artist,
                        Uri = "uri",
                    },
                ],
                Limit = 0,
                Next = "next",
                Total = 0,
            },
        };

        FollowingBulkRetrieveResponseArtists expectedArtists = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Followers = new() { Href = "href", Total = 0 },
                    Genres = ["Prog rock", "Grunge"],
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
                    Popularity = 0,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        Assert.Equal(expectedArtists, model.Artists);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FollowingBulkRetrieveResponse
        {
            Artists = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                Href = "href",
                Items =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Followers = new() { Href = "href", Total = 0 },
                        Genres = ["Prog rock", "Grunge"],
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
                        Popularity = 0,
                        Type = Models::Type.Artist,
                        Uri = "uri",
                    },
                ],
                Limit = 0,
                Next = "next",
                Total = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FollowingBulkRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FollowingBulkRetrieveResponse
        {
            Artists = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                Href = "href",
                Items =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Followers = new() { Href = "href", Total = 0 },
                        Genres = ["Prog rock", "Grunge"],
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
                        Popularity = 0,
                        Type = Models::Type.Artist,
                        Uri = "uri",
                    },
                ],
                Limit = 0,
                Next = "next",
                Total = 0,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FollowingBulkRetrieveResponse>(json);
        Assert.NotNull(deserialized);

        FollowingBulkRetrieveResponseArtists expectedArtists = new()
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Followers = new() { Href = "href", Total = 0 },
                    Genres = ["Prog rock", "Grunge"],
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
                    Popularity = 0,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        Assert.Equal(expectedArtists, deserialized.Artists);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FollowingBulkRetrieveResponse
        {
            Artists = new()
            {
                Cursors = new() { After = "after", Before = "before" },
                Href = "href",
                Items =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Followers = new() { Href = "href", Total = 0 },
                        Genres = ["Prog rock", "Grunge"],
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
                        Popularity = 0,
                        Type = Models::Type.Artist,
                        Uri = "uri",
                    },
                ],
                Limit = 0,
                Next = "next",
                Total = 0,
            },
        };

        model.Validate();
    }
}

public class FollowingBulkRetrieveResponseArtistsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FollowingBulkRetrieveResponseArtists
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Followers = new() { Href = "href", Total = 0 },
                    Genres = ["Prog rock", "Grunge"],
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
                    Popularity = 0,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        Cursors expectedCursors = new() { After = "after", Before = "before" };
        string expectedHref = "href";
        List<Models::ArtistObject> expectedItems =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Followers = new() { Href = "href", Total = 0 },
                Genres = ["Prog rock", "Grunge"],
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
                Popularity = 0,
                Type = Models::Type.Artist,
                Uri = "uri",
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
        var model = new FollowingBulkRetrieveResponseArtists
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Followers = new() { Href = "href", Total = 0 },
                    Genres = ["Prog rock", "Grunge"],
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
                    Popularity = 0,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FollowingBulkRetrieveResponseArtists>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FollowingBulkRetrieveResponseArtists
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Followers = new() { Href = "href", Total = 0 },
                    Genres = ["Prog rock", "Grunge"],
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
                    Popularity = 0,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Limit = 0,
            Next = "next",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FollowingBulkRetrieveResponseArtists>(json);
        Assert.NotNull(deserialized);

        Cursors expectedCursors = new() { After = "after", Before = "before" };
        string expectedHref = "href";
        List<Models::ArtistObject> expectedItems =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Followers = new() { Href = "href", Total = 0 },
                Genres = ["Prog rock", "Grunge"],
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
                Popularity = 0,
                Type = Models::Type.Artist,
                Uri = "uri",
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
        var model = new FollowingBulkRetrieveResponseArtists
        {
            Cursors = new() { After = "after", Before = "before" },
            Href = "href",
            Items =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Followers = new() { Href = "href", Total = 0 },
                    Genres = ["Prog rock", "Grunge"],
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
                    Popularity = 0,
                    Type = Models::Type.Artist,
                    Uri = "uri",
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
        var model = new FollowingBulkRetrieveResponseArtists { };

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
        var model = new FollowingBulkRetrieveResponseArtists { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FollowingBulkRetrieveResponseArtists
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
        var model = new FollowingBulkRetrieveResponseArtists
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
