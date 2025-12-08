using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Shows;

namespace Spotted.Tests.Models.Shows;

public class ShowBulkRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShowBulkRetrieveResponse
        {
            Shows =
            [
                new()
                {
                    ID = "id",
                    AvailableMarkets = ["string"],
                    Copyrights = [new() { Text = "text", Type = "type" }],
                    Description = "description",
                    Explicit = true,
                    ExternalURLs = new() { Spotify = "spotify" },
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
                        },
                    ],
                    IsExternallyHosted = true,
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Publisher = "publisher",
                    TotalEpisodes = 0,
                    Uri = "uri",
                },
            ],
        };

        List<ShowBase> expectedShows =
        [
            new()
            {
                ID = "id",
                AvailableMarkets = ["string"],
                Copyrights = [new() { Text = "text", Type = "type" }],
                Description = "description",
                Explicit = true,
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                HTMLDescription = "html_description",
                Images =
                [
                    new()
                    {
                        Height = 300,
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                    },
                ],
                IsExternallyHosted = true,
                Languages = ["string"],
                MediaType = "media_type",
                Name = "name",
                Publisher = "publisher",
                TotalEpisodes = 0,
                Uri = "uri",
            },
        ];

        Assert.Equal(expectedShows.Count, model.Shows.Count);
        for (int i = 0; i < expectedShows.Count; i++)
        {
            Assert.Equal(expectedShows[i], model.Shows[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShowBulkRetrieveResponse
        {
            Shows =
            [
                new()
                {
                    ID = "id",
                    AvailableMarkets = ["string"],
                    Copyrights = [new() { Text = "text", Type = "type" }],
                    Description = "description",
                    Explicit = true,
                    ExternalURLs = new() { Spotify = "spotify" },
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
                        },
                    ],
                    IsExternallyHosted = true,
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Publisher = "publisher",
                    TotalEpisodes = 0,
                    Uri = "uri",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShowBulkRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShowBulkRetrieveResponse
        {
            Shows =
            [
                new()
                {
                    ID = "id",
                    AvailableMarkets = ["string"],
                    Copyrights = [new() { Text = "text", Type = "type" }],
                    Description = "description",
                    Explicit = true,
                    ExternalURLs = new() { Spotify = "spotify" },
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
                        },
                    ],
                    IsExternallyHosted = true,
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Publisher = "publisher",
                    TotalEpisodes = 0,
                    Uri = "uri",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ShowBulkRetrieveResponse>(json);
        Assert.NotNull(deserialized);

        List<ShowBase> expectedShows =
        [
            new()
            {
                ID = "id",
                AvailableMarkets = ["string"],
                Copyrights = [new() { Text = "text", Type = "type" }],
                Description = "description",
                Explicit = true,
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                HTMLDescription = "html_description",
                Images =
                [
                    new()
                    {
                        Height = 300,
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                    },
                ],
                IsExternallyHosted = true,
                Languages = ["string"],
                MediaType = "media_type",
                Name = "name",
                Publisher = "publisher",
                TotalEpisodes = 0,
                Uri = "uri",
            },
        ];

        Assert.Equal(expectedShows.Count, deserialized.Shows.Count);
        for (int i = 0; i < expectedShows.Count; i++)
        {
            Assert.Equal(expectedShows[i], deserialized.Shows[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShowBulkRetrieveResponse
        {
            Shows =
            [
                new()
                {
                    ID = "id",
                    AvailableMarkets = ["string"],
                    Copyrights = [new() { Text = "text", Type = "type" }],
                    Description = "description",
                    Explicit = true,
                    ExternalURLs = new() { Spotify = "spotify" },
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
                        },
                    ],
                    IsExternallyHosted = true,
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Publisher = "publisher",
                    TotalEpisodes = 0,
                    Uri = "uri",
                },
            ],
        };

        model.Validate();
    }
}
