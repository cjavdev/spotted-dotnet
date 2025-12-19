using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Me.Episodes;

namespace Spotted.Tests.Models.Me.Episodes;

public class EpisodeListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EpisodeListPageResponse
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
                    Episode = new()
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        IsExternallyHosted = true,
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
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
        List<EpisodeListResponse> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Episode = new()
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    IsExternallyHosted = true,
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
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
        var model = new EpisodeListPageResponse
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
                    Episode = new()
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        IsExternallyHosted = true,
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
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
                    },
                    Published = true,
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EpisodeListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EpisodeListPageResponse
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
                    Episode = new()
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        IsExternallyHosted = true,
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
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
                    },
                    Published = true,
                },
            ],
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EpisodeListPageResponse>(element);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<EpisodeListResponse> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Episode = new()
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    IsExternallyHosted = true,
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
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
        var model = new EpisodeListPageResponse
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
                    Episode = new()
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        IsExternallyHosted = true,
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
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
        var model = new EpisodeListPageResponse
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
        var model = new EpisodeListPageResponse
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
        var model = new EpisodeListPageResponse
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
        var model = new EpisodeListPageResponse
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
