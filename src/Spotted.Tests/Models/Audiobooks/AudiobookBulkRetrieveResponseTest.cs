using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Audiobooks;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Audiobooks;

public class AudiobookBulkRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudiobookBulkRetrieveResponse
        {
            Audiobooks =
            [
                new()
                {
                    ID = "id",
                    Authors = [new() { Name = "name", Published = true }],
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
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Narrators = [new() { Name = "name", Published = true }],
                    Publisher = "publisher",
                    TotalChapters = 0,
                    Uri = "uri",
                    Edition = "Unabridged",
                    Published = true,
                    Chapters = new()
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
                                ID = "5Xt5DXGzch68nYYamXrNxZ",
                                AudioPreviewURL =
                                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                                ChapterNumber = 1,
                                Description =
                                    "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                                DurationMs = 1686230,
                                Explicit = true,
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                                HTMLDescription =
                                    "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                                IsPlayable = true,
                                Languages = ["fr", "en"],
                                Name =
                                    "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                                ReleaseDate = "1981-12-15",
                                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                                AvailableMarkets = ["string"],
                                Published = true,
                                Restrictions = new() { Published = true, Reason = "reason" },
                                ResumePoint = new()
                                {
                                    FullyPlayed = true,
                                    Published = true,
                                    ResumePositionMs = 0,
                                },
                            },
                        ],
                        Published = true,
                    },
                },
            ],
        };

        List<Audiobook> expectedAudiobooks =
        [
            new()
            {
                ID = "id",
                Authors = [new() { Name = "name", Published = true }],
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                        Published = true,
                    },
                ],
                Languages = ["string"],
                MediaType = "media_type",
                Name = "name",
                Narrators = [new() { Name = "name", Published = true }],
                Publisher = "publisher",
                TotalChapters = 0,
                Uri = "uri",
                Edition = "Unabridged",
                Published = true,
                Chapters = new()
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
                            ID = "5Xt5DXGzch68nYYamXrNxZ",
                            AudioPreviewURL =
                                "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                            ChapterNumber = 1,
                            Description =
                                "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                            DurationMs = 1686230,
                            Explicit = true,
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                            HTMLDescription =
                                "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                            IsPlayable = true,
                            Languages = ["fr", "en"],
                            Name =
                                "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                            ReleaseDate = "1981-12-15",
                            ReleaseDatePrecision = ReleaseDatePrecision.Day,
                            Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                            AvailableMarkets = ["string"],
                            Published = true,
                            Restrictions = new() { Published = true, Reason = "reason" },
                            ResumePoint = new()
                            {
                                FullyPlayed = true,
                                Published = true,
                                ResumePositionMs = 0,
                            },
                        },
                    ],
                    Published = true,
                },
            },
        ];

        Assert.Equal(expectedAudiobooks.Count, model.Audiobooks.Count);
        for (int i = 0; i < expectedAudiobooks.Count; i++)
        {
            Assert.Equal(expectedAudiobooks[i], model.Audiobooks[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudiobookBulkRetrieveResponse
        {
            Audiobooks =
            [
                new()
                {
                    ID = "id",
                    Authors = [new() { Name = "name", Published = true }],
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
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Narrators = [new() { Name = "name", Published = true }],
                    Publisher = "publisher",
                    TotalChapters = 0,
                    Uri = "uri",
                    Edition = "Unabridged",
                    Published = true,
                    Chapters = new()
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
                                ID = "5Xt5DXGzch68nYYamXrNxZ",
                                AudioPreviewURL =
                                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                                ChapterNumber = 1,
                                Description =
                                    "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                                DurationMs = 1686230,
                                Explicit = true,
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                                HTMLDescription =
                                    "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                                IsPlayable = true,
                                Languages = ["fr", "en"],
                                Name =
                                    "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                                ReleaseDate = "1981-12-15",
                                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                                AvailableMarkets = ["string"],
                                Published = true,
                                Restrictions = new() { Published = true, Reason = "reason" },
                                ResumePoint = new()
                                {
                                    FullyPlayed = true,
                                    Published = true,
                                    ResumePositionMs = 0,
                                },
                            },
                        ],
                        Published = true,
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudiobookBulkRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudiobookBulkRetrieveResponse
        {
            Audiobooks =
            [
                new()
                {
                    ID = "id",
                    Authors = [new() { Name = "name", Published = true }],
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
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Narrators = [new() { Name = "name", Published = true }],
                    Publisher = "publisher",
                    TotalChapters = 0,
                    Uri = "uri",
                    Edition = "Unabridged",
                    Published = true,
                    Chapters = new()
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
                                ID = "5Xt5DXGzch68nYYamXrNxZ",
                                AudioPreviewURL =
                                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                                ChapterNumber = 1,
                                Description =
                                    "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                                DurationMs = 1686230,
                                Explicit = true,
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                                HTMLDescription =
                                    "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                                IsPlayable = true,
                                Languages = ["fr", "en"],
                                Name =
                                    "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                                ReleaseDate = "1981-12-15",
                                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                                AvailableMarkets = ["string"],
                                Published = true,
                                Restrictions = new() { Published = true, Reason = "reason" },
                                ResumePoint = new()
                                {
                                    FullyPlayed = true,
                                    Published = true,
                                    ResumePositionMs = 0,
                                },
                            },
                        ],
                        Published = true,
                    },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudiobookBulkRetrieveResponse>(element);
        Assert.NotNull(deserialized);

        List<Audiobook> expectedAudiobooks =
        [
            new()
            {
                ID = "id",
                Authors = [new() { Name = "name", Published = true }],
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                        Published = true,
                    },
                ],
                Languages = ["string"],
                MediaType = "media_type",
                Name = "name",
                Narrators = [new() { Name = "name", Published = true }],
                Publisher = "publisher",
                TotalChapters = 0,
                Uri = "uri",
                Edition = "Unabridged",
                Published = true,
                Chapters = new()
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
                            ID = "5Xt5DXGzch68nYYamXrNxZ",
                            AudioPreviewURL =
                                "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                            ChapterNumber = 1,
                            Description =
                                "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                            DurationMs = 1686230,
                            Explicit = true,
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                            HTMLDescription =
                                "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                            IsPlayable = true,
                            Languages = ["fr", "en"],
                            Name =
                                "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                            ReleaseDate = "1981-12-15",
                            ReleaseDatePrecision = ReleaseDatePrecision.Day,
                            Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                            AvailableMarkets = ["string"],
                            Published = true,
                            Restrictions = new() { Published = true, Reason = "reason" },
                            ResumePoint = new()
                            {
                                FullyPlayed = true,
                                Published = true,
                                ResumePositionMs = 0,
                            },
                        },
                    ],
                    Published = true,
                },
            },
        ];

        Assert.Equal(expectedAudiobooks.Count, deserialized.Audiobooks.Count);
        for (int i = 0; i < expectedAudiobooks.Count; i++)
        {
            Assert.Equal(expectedAudiobooks[i], deserialized.Audiobooks[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudiobookBulkRetrieveResponse
        {
            Audiobooks =
            [
                new()
                {
                    ID = "id",
                    Authors = [new() { Name = "name", Published = true }],
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
                    Languages = ["string"],
                    MediaType = "media_type",
                    Name = "name",
                    Narrators = [new() { Name = "name", Published = true }],
                    Publisher = "publisher",
                    TotalChapters = 0,
                    Uri = "uri",
                    Edition = "Unabridged",
                    Published = true,
                    Chapters = new()
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
                                ID = "5Xt5DXGzch68nYYamXrNxZ",
                                AudioPreviewURL =
                                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                                ChapterNumber = 1,
                                Description =
                                    "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                                DurationMs = 1686230,
                                Explicit = true,
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                                HTMLDescription =
                                    "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                                IsPlayable = true,
                                Languages = ["fr", "en"],
                                Name =
                                    "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                                ReleaseDate = "1981-12-15",
                                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                                AvailableMarkets = ["string"],
                                Published = true,
                                Restrictions = new() { Published = true, Reason = "reason" },
                                ResumePoint = new()
                                {
                                    FullyPlayed = true,
                                    Published = true,
                                    ResumePositionMs = 0,
                                },
                            },
                        ],
                        Published = true,
                    },
                },
            ],
        };

        model.Validate();
    }
}

public class AudiobookTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Audiobook
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Edition = "Unabridged",
            Published = true,
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        string expectedID = "id";
        List<Models::AuthorObject> expectedAuthors = [new() { Name = "name", Published = true }];
        List<string> expectedAvailableMarkets = ["string"];
        List<Models::CopyrightObject> expectedCopyrights =
        [
            new()
            {
                Published = true,
                Text = "text",
                Type = "type",
            },
        ];
        string expectedDescription = "description";
        bool expectedExplicit = true;
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        string expectedHref = "href";
        string expectedHTMLDescription = "html_description";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        List<string> expectedLanguages = ["string"];
        string expectedMediaType = "media_type";
        string expectedName = "name";
        List<Models::NarratorObject> expectedNarrators =
        [
            new() { Name = "name", Published = true },
        ];
        string expectedPublisher = "publisher";
        long expectedTotalChapters = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"audiobook\"");
        string expectedUri = "uri";
        string expectedEdition = "Unabridged";
        bool expectedPublished = true;
        AudiobookIntersectionMember1Chapters expectedChapters = new()
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
                    ID = "5Xt5DXGzch68nYYamXrNxZ",
                    AudioPreviewURL =
                        "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                    ChapterNumber = 1,
                    Description =
                        "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                    DurationMs = 1686230,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                    HTMLDescription =
                        "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                    ReleaseDate = "1981-12-15",
                    ReleaseDatePrecision = ReleaseDatePrecision.Day,
                    Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                    AvailableMarkets = ["string"],
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    ResumePoint = new()
                    {
                        FullyPlayed = true,
                        Published = true,
                        ResumePositionMs = 0,
                    },
                },
            ],
            Published = true,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAuthors.Count, model.Authors.Count);
        for (int i = 0; i < expectedAuthors.Count; i++)
        {
            Assert.Equal(expectedAuthors[i], model.Authors[i]);
        }
        Assert.Equal(expectedAvailableMarkets.Count, model.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], model.AvailableMarkets[i]);
        }
        Assert.Equal(expectedCopyrights.Count, model.Copyrights.Count);
        for (int i = 0; i < expectedCopyrights.Count; i++)
        {
            Assert.Equal(expectedCopyrights[i], model.Copyrights[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExplicit, model.Explicit);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedHTMLDescription, model.HTMLDescription);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
        Assert.Equal(expectedMediaType, model.MediaType);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNarrators.Count, model.Narrators.Count);
        for (int i = 0; i < expectedNarrators.Count; i++)
        {
            Assert.Equal(expectedNarrators[i], model.Narrators[i]);
        }
        Assert.Equal(expectedPublisher, model.Publisher);
        Assert.Equal(expectedTotalChapters, model.TotalChapters);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUri, model.Uri);
        Assert.Equal(expectedEdition, model.Edition);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedChapters, model.Chapters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Audiobook
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Edition = "Unabridged",
            Published = true,
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Audiobook>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Audiobook
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Edition = "Unabridged",
            Published = true,
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Audiobook>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<Models::AuthorObject> expectedAuthors = [new() { Name = "name", Published = true }];
        List<string> expectedAvailableMarkets = ["string"];
        List<Models::CopyrightObject> expectedCopyrights =
        [
            new()
            {
                Published = true,
                Text = "text",
                Type = "type",
            },
        ];
        string expectedDescription = "description";
        bool expectedExplicit = true;
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        string expectedHref = "href";
        string expectedHTMLDescription = "html_description";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
                Published = true,
            },
        ];
        List<string> expectedLanguages = ["string"];
        string expectedMediaType = "media_type";
        string expectedName = "name";
        List<Models::NarratorObject> expectedNarrators =
        [
            new() { Name = "name", Published = true },
        ];
        string expectedPublisher = "publisher";
        long expectedTotalChapters = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"audiobook\"");
        string expectedUri = "uri";
        string expectedEdition = "Unabridged";
        bool expectedPublished = true;
        AudiobookIntersectionMember1Chapters expectedChapters = new()
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
                    ID = "5Xt5DXGzch68nYYamXrNxZ",
                    AudioPreviewURL =
                        "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                    ChapterNumber = 1,
                    Description =
                        "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                    DurationMs = 1686230,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                    HTMLDescription =
                        "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                    ReleaseDate = "1981-12-15",
                    ReleaseDatePrecision = ReleaseDatePrecision.Day,
                    Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                    AvailableMarkets = ["string"],
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    ResumePoint = new()
                    {
                        FullyPlayed = true,
                        Published = true,
                        ResumePositionMs = 0,
                    },
                },
            ],
            Published = true,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAuthors.Count, deserialized.Authors.Count);
        for (int i = 0; i < expectedAuthors.Count; i++)
        {
            Assert.Equal(expectedAuthors[i], deserialized.Authors[i]);
        }
        Assert.Equal(expectedAvailableMarkets.Count, deserialized.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], deserialized.AvailableMarkets[i]);
        }
        Assert.Equal(expectedCopyrights.Count, deserialized.Copyrights.Count);
        for (int i = 0; i < expectedCopyrights.Count; i++)
        {
            Assert.Equal(expectedCopyrights[i], deserialized.Copyrights[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExplicit, deserialized.Explicit);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedHTMLDescription, deserialized.HTMLDescription);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
        Assert.Equal(expectedMediaType, deserialized.MediaType);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNarrators.Count, deserialized.Narrators.Count);
        for (int i = 0; i < expectedNarrators.Count; i++)
        {
            Assert.Equal(expectedNarrators[i], deserialized.Narrators[i]);
        }
        Assert.Equal(expectedPublisher, deserialized.Publisher);
        Assert.Equal(expectedTotalChapters, deserialized.TotalChapters);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.Equal(expectedEdition, deserialized.Edition);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedChapters, deserialized.Chapters);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Audiobook
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Edition = "Unabridged",
            Published = true,
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Audiobook
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        Assert.Null(model.Edition);
        Assert.False(model.RawData.ContainsKey("edition"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Audiobook
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Audiobook
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },

            // Null should be interpreted as omitted for these properties
            Edition = null,
            Published = null,
        };

        Assert.Null(model.Edition);
        Assert.False(model.RawData.ContainsKey("edition"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Audiobook
        {
            ID = "id",
            Authors = [new() { Name = "name", Published = true }],
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                    Width = 300,
                    Published = true,
                },
            ],
            Languages = ["string"],
            MediaType = "media_type",
            Name = "name",
            Narrators = [new() { Name = "name", Published = true }],
            Publisher = "publisher",
            TotalChapters = 0,
            Uri = "uri",
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },

            // Null should be interpreted as omitted for these properties
            Edition = null,
            Published = null,
        };

        model.Validate();
    }
}

public class AudiobookIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudiobookIntersectionMember1
        {
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        AudiobookIntersectionMember1Chapters expectedChapters = new()
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
                    ID = "5Xt5DXGzch68nYYamXrNxZ",
                    AudioPreviewURL =
                        "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                    ChapterNumber = 1,
                    Description =
                        "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                    DurationMs = 1686230,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                    HTMLDescription =
                        "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                    ReleaseDate = "1981-12-15",
                    ReleaseDatePrecision = ReleaseDatePrecision.Day,
                    Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                    AvailableMarkets = ["string"],
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    ResumePoint = new()
                    {
                        FullyPlayed = true,
                        Published = true,
                        ResumePositionMs = 0,
                    },
                },
            ],
            Published = true,
        };

        Assert.Equal(expectedChapters, model.Chapters);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudiobookIntersectionMember1
        {
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudiobookIntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudiobookIntersectionMember1
        {
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudiobookIntersectionMember1>(element);
        Assert.NotNull(deserialized);

        AudiobookIntersectionMember1Chapters expectedChapters = new()
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
                    ID = "5Xt5DXGzch68nYYamXrNxZ",
                    AudioPreviewURL =
                        "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                    ChapterNumber = 1,
                    Description =
                        "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                    DurationMs = 1686230,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                    HTMLDescription =
                        "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                    ReleaseDate = "1981-12-15",
                    ReleaseDatePrecision = ReleaseDatePrecision.Day,
                    Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                    AvailableMarkets = ["string"],
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    ResumePoint = new()
                    {
                        FullyPlayed = true,
                        Published = true,
                        ResumePositionMs = 0,
                    },
                },
            ],
            Published = true,
        };

        Assert.Equal(expectedChapters, deserialized.Chapters);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudiobookIntersectionMember1
        {
            Chapters = new()
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
                        ID = "5Xt5DXGzch68nYYamXrNxZ",
                        AudioPreviewURL =
                            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                        ChapterNumber = 1,
                        Description =
                            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                        DurationMs = 1686230,
                        Explicit = true,
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                        HTMLDescription =
                            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                        IsPlayable = true,
                        Languages = ["fr", "en"],
                        Name =
                            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                        ReleaseDate = "1981-12-15",
                        ReleaseDatePrecision = ReleaseDatePrecision.Day,
                        Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                        AvailableMarkets = ["string"],
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        ResumePoint = new()
                        {
                            FullyPlayed = true,
                            Published = true,
                            ResumePositionMs = 0,
                        },
                    },
                ],
                Published = true,
            },
        };

        model.Validate();
    }
}

public class AudiobookIntersectionMember1ChaptersTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudiobookIntersectionMember1Chapters
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
                    ID = "5Xt5DXGzch68nYYamXrNxZ",
                    AudioPreviewURL =
                        "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                    ChapterNumber = 1,
                    Description =
                        "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                    DurationMs = 1686230,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                    HTMLDescription =
                        "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                    ReleaseDate = "1981-12-15",
                    ReleaseDatePrecision = ReleaseDatePrecision.Day,
                    Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                    AvailableMarkets = ["string"],
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    ResumePoint = new()
                    {
                        FullyPlayed = true,
                        Published = true,
                        ResumePositionMs = 0,
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
        List<SimplifiedChapterObject> expectedItems =
        [
            new()
            {
                ID = "5Xt5DXGzch68nYYamXrNxZ",
                AudioPreviewURL =
                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                ChapterNumber = 1,
                Description =
                    "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                DurationMs = 1686230,
                Explicit = true,
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                HTMLDescription =
                    "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                IsPlayable = true,
                Languages = ["fr", "en"],
                Name = "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                ReleaseDate = "1981-12-15",
                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                AvailableMarkets = ["string"],
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                ResumePoint = new()
                {
                    FullyPlayed = true,
                    Published = true,
                    ResumePositionMs = 0,
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
        var model = new AudiobookIntersectionMember1Chapters
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
                    ID = "5Xt5DXGzch68nYYamXrNxZ",
                    AudioPreviewURL =
                        "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                    ChapterNumber = 1,
                    Description =
                        "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                    DurationMs = 1686230,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                    HTMLDescription =
                        "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                    ReleaseDate = "1981-12-15",
                    ReleaseDatePrecision = ReleaseDatePrecision.Day,
                    Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                    AvailableMarkets = ["string"],
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    ResumePoint = new()
                    {
                        FullyPlayed = true,
                        Published = true,
                        ResumePositionMs = 0,
                    },
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudiobookIntersectionMember1Chapters>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudiobookIntersectionMember1Chapters
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
                    ID = "5Xt5DXGzch68nYYamXrNxZ",
                    AudioPreviewURL =
                        "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                    ChapterNumber = 1,
                    Description =
                        "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                    DurationMs = 1686230,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                    HTMLDescription =
                        "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                    ReleaseDate = "1981-12-15",
                    ReleaseDatePrecision = ReleaseDatePrecision.Day,
                    Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                    AvailableMarkets = ["string"],
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    ResumePoint = new()
                    {
                        FullyPlayed = true,
                        Published = true,
                        ResumePositionMs = 0,
                    },
                },
            ],
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudiobookIntersectionMember1Chapters>(
            element
        );
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<SimplifiedChapterObject> expectedItems =
        [
            new()
            {
                ID = "5Xt5DXGzch68nYYamXrNxZ",
                AudioPreviewURL =
                    "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                ChapterNumber = 1,
                Description =
                    "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                DurationMs = 1686230,
                Explicit = true,
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                HTMLDescription =
                    "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                IsPlayable = true,
                Languages = ["fr", "en"],
                Name = "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                ReleaseDate = "1981-12-15",
                ReleaseDatePrecision = ReleaseDatePrecision.Day,
                Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                AvailableMarkets = ["string"],
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                ResumePoint = new()
                {
                    FullyPlayed = true,
                    Published = true,
                    ResumePositionMs = 0,
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
        var model = new AudiobookIntersectionMember1Chapters
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
                    ID = "5Xt5DXGzch68nYYamXrNxZ",
                    AudioPreviewURL =
                        "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17",
                    ChapterNumber = 1,
                    Description =
                        "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n",
                    DurationMs = 1686230,
                    Explicit = true,
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ",
                    HTMLDescription =
                        "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n",
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
                    IsPlayable = true,
                    Languages = ["fr", "en"],
                    Name =
                        "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                    ReleaseDate = "1981-12-15",
                    ReleaseDatePrecision = ReleaseDatePrecision.Day,
                    Uri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr",
                    AvailableMarkets = ["string"],
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    ResumePoint = new()
                    {
                        FullyPlayed = true,
                        Published = true,
                        ResumePositionMs = 0,
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
        var model = new AudiobookIntersectionMember1Chapters
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
        var model = new AudiobookIntersectionMember1Chapters
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
        var model = new AudiobookIntersectionMember1Chapters
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
        var model = new AudiobookIntersectionMember1Chapters
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
