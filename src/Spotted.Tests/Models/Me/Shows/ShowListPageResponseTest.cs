using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Me.Shows;

namespace Spotted.Tests.Models.Me.Shows;

public class ShowListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShowListPageResponse
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
                    Published = true,
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
        List<ShowListResponse> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Published = true,
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
        var model = new ShowListPageResponse
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
                    Published = true,
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
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShowListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShowListPageResponse
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
                    Published = true,
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
                },
            ],
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShowListPageResponse>(element);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<ShowListResponse> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Published = true,
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
        var model = new ShowListPageResponse
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
                    Published = true,
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
                },
            ],
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ShowListPageResponse
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
        var model = new ShowListPageResponse
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
        var model = new ShowListPageResponse
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
        var model = new ShowListPageResponse
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
