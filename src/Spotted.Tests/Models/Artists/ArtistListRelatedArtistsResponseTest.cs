using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Artists;

namespace Spotted.Tests.Models.Artists;

public class ArtistListRelatedArtistsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ArtistListRelatedArtistsResponse
        {
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalUrls = new() { Published = true, Spotify = "spotify" },
                    Followers = new()
                    {
                        Href = "href",
                        Published = true,
                        Total = 0,
                    },
                    Genres = ["Prog rock", "Grunge"],
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            Url =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Type.Artist,
                    Uri = "uri",
                },
            ],
        };

        List<ArtistObject> expectedArtists =
        [
            new()
            {
                ID = "id",
                ExternalUrls = new() { Published = true, Spotify = "spotify" },
                Followers = new()
                {
                    Href = "href",
                    Published = true,
                    Total = 0,
                },
                Genres = ["Prog rock", "Grunge"],
                Href = "href",
                Images =
                [
                    new()
                    {
                        Height = 300,
                        Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                        Published = true,
                    },
                ],
                Name = "name",
                Popularity = 0,
                Published = true,
                Type = Type.Artist,
                Uri = "uri",
            },
        ];

        Assert.Equal(expectedArtists.Count, model.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], model.Artists[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ArtistListRelatedArtistsResponse
        {
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalUrls = new() { Published = true, Spotify = "spotify" },
                    Followers = new()
                    {
                        Href = "href",
                        Published = true,
                        Total = 0,
                    },
                    Genres = ["Prog rock", "Grunge"],
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            Url =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Type.Artist,
                    Uri = "uri",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArtistListRelatedArtistsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ArtistListRelatedArtistsResponse
        {
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalUrls = new() { Published = true, Spotify = "spotify" },
                    Followers = new()
                    {
                        Href = "href",
                        Published = true,
                        Total = 0,
                    },
                    Genres = ["Prog rock", "Grunge"],
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            Url =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Type.Artist,
                    Uri = "uri",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ArtistListRelatedArtistsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ArtistObject> expectedArtists =
        [
            new()
            {
                ID = "id",
                ExternalUrls = new() { Published = true, Spotify = "spotify" },
                Followers = new()
                {
                    Href = "href",
                    Published = true,
                    Total = 0,
                },
                Genres = ["Prog rock", "Grunge"],
                Href = "href",
                Images =
                [
                    new()
                    {
                        Height = 300,
                        Url = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                        Published = true,
                    },
                ],
                Name = "name",
                Popularity = 0,
                Published = true,
                Type = Type.Artist,
                Uri = "uri",
            },
        ];

        Assert.Equal(expectedArtists.Count, deserialized.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], deserialized.Artists[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ArtistListRelatedArtistsResponse
        {
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalUrls = new() { Published = true, Spotify = "spotify" },
                    Followers = new()
                    {
                        Href = "href",
                        Published = true,
                        Total = 0,
                    },
                    Genres = ["Prog rock", "Grunge"],
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            Url =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Type.Artist,
                    Uri = "uri",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ArtistListRelatedArtistsResponse
        {
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalUrls = new() { Published = true, Spotify = "spotify" },
                    Followers = new()
                    {
                        Href = "href",
                        Published = true,
                        Total = 0,
                    },
                    Genres = ["Prog rock", "Grunge"],
                    Href = "href",
                    Images =
                    [
                        new()
                        {
                            Height = 300,
                            Url =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Type.Artist,
                    Uri = "uri",
                },
            ],
        };

        ArtistListRelatedArtistsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
