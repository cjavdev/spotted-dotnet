using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Audiobooks;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Audiobooks;

public class SimplifiedChapterObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SimplifiedChapterObject
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
        };

        string expectedID = "5Xt5DXGzch68nYYamXrNxZ";
        string expectedAudioPreviewURL =
            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17";
        long expectedChapterNumber = 1;
        string expectedDescription =
            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n";
        long expectedDurationMs = 1686230;
        bool expectedExplicit = true;
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        string expectedHref = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ";
        string expectedHTMLDescription =
            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n";
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
        bool expectedIsPlayable = true;
        List<string> expectedLanguages = ["fr", "en"];
        string expectedName =
            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n";
        string expectedReleaseDate = "1981-12-15";
        ApiEnum<string, ReleaseDatePrecision> expectedReleaseDatePrecision =
            ReleaseDatePrecision.Day;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"episode\"");
        string expectedUri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr";
        List<string> expectedAvailableMarkets = ["string"];
        bool expectedPublished = true;
        Models::ChapterRestrictionObject expectedRestrictions = new()
        {
            Published = true,
            Reason = "reason",
        };
        Models::ResumePointObject expectedResumePoint = new()
        {
            FullyPlayed = true,
            Published = true,
            ResumePositionMs = 0,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAudioPreviewURL, model.AudioPreviewURL);
        Assert.Equal(expectedChapterNumber, model.ChapterNumber);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedExplicit, model.Explicit);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedHTMLDescription, model.HTMLDescription);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedIsPlayable, model.IsPlayable);
        Assert.Equal(expectedLanguages.Count, model.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], model.Languages[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedReleaseDate, model.ReleaseDate);
        Assert.Equal(expectedReleaseDatePrecision, model.ReleaseDatePrecision);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUri, model.Uri);
        Assert.NotNull(model.AvailableMarkets);
        Assert.Equal(expectedAvailableMarkets.Count, model.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], model.AvailableMarkets[i]);
        }
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedRestrictions, model.Restrictions);
        Assert.Equal(expectedResumePoint, model.ResumePoint);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SimplifiedChapterObject
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SimplifiedChapterObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SimplifiedChapterObject
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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SimplifiedChapterObject>(element);
        Assert.NotNull(deserialized);

        string expectedID = "5Xt5DXGzch68nYYamXrNxZ";
        string expectedAudioPreviewURL =
            "https://p.scdn.co/mp3-preview/2f37da1d4221f40b9d1a98cd191f4d6f1646ad17";
        long expectedChapterNumber = 1;
        string expectedDescription =
            "We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.\n";
        long expectedDurationMs = 1686230;
        bool expectedExplicit = true;
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        string expectedHref = "https://api.spotify.com/v1/episodes/5Xt5DXGzch68nYYamXrNxZ";
        string expectedHTMLDescription =
            "<p>We kept on ascending, with occasional periods of quick descent, but in the main always ascending. Suddenly, I became conscious of the fact that the driver was in the act of pulling up the horses in the courtyard of a vast ruined castle, from whose tall black windows came no ray of light, and whose broken battlements showed a jagged line against the moonlit sky.</p>\n";
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
        bool expectedIsPlayable = true;
        List<string> expectedLanguages = ["fr", "en"];
        string expectedName =
            "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n";
        string expectedReleaseDate = "1981-12-15";
        ApiEnum<string, ReleaseDatePrecision> expectedReleaseDatePrecision =
            ReleaseDatePrecision.Day;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"episode\"");
        string expectedUri = "spotify:episode:0zLhl3WsOCQHbe1BPTiHgr";
        List<string> expectedAvailableMarkets = ["string"];
        bool expectedPublished = true;
        Models::ChapterRestrictionObject expectedRestrictions = new()
        {
            Published = true,
            Reason = "reason",
        };
        Models::ResumePointObject expectedResumePoint = new()
        {
            FullyPlayed = true,
            Published = true,
            ResumePositionMs = 0,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAudioPreviewURL, deserialized.AudioPreviewURL);
        Assert.Equal(expectedChapterNumber, deserialized.ChapterNumber);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedExplicit, deserialized.Explicit);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedHTMLDescription, deserialized.HTMLDescription);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedIsPlayable, deserialized.IsPlayable);
        Assert.Equal(expectedLanguages.Count, deserialized.Languages.Count);
        for (int i = 0; i < expectedLanguages.Count; i++)
        {
            Assert.Equal(expectedLanguages[i], deserialized.Languages[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedReleaseDate, deserialized.ReleaseDate);
        Assert.Equal(expectedReleaseDatePrecision, deserialized.ReleaseDatePrecision);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.NotNull(deserialized.AvailableMarkets);
        Assert.Equal(expectedAvailableMarkets.Count, deserialized.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], deserialized.AvailableMarkets[i]);
        }
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedRestrictions, deserialized.Restrictions);
        Assert.Equal(expectedResumePoint, deserialized.ResumePoint);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SimplifiedChapterObject
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SimplifiedChapterObject
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
        };

        Assert.Null(model.AvailableMarkets);
        Assert.False(model.RawData.ContainsKey("available_markets"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
        Assert.Null(model.ResumePoint);
        Assert.False(model.RawData.ContainsKey("resume_point"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SimplifiedChapterObject
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SimplifiedChapterObject
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

            // Null should be interpreted as omitted for these properties
            AvailableMarkets = null,
            Published = null,
            Restrictions = null,
            ResumePoint = null,
        };

        Assert.Null(model.AvailableMarkets);
        Assert.False(model.RawData.ContainsKey("available_markets"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
        Assert.Null(model.ResumePoint);
        Assert.False(model.RawData.ContainsKey("resume_point"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SimplifiedChapterObject
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

            // Null should be interpreted as omitted for these properties
            AvailableMarkets = null,
            Published = null,
            Restrictions = null,
            ResumePoint = null,
        };

        model.Validate();
    }
}

public class ReleaseDatePrecisionTest : TestBase
{
    [Theory]
    [InlineData(ReleaseDatePrecision.Year)]
    [InlineData(ReleaseDatePrecision.Month)]
    [InlineData(ReleaseDatePrecision.Day)]
    public void Validation_Works(ReleaseDatePrecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReleaseDatePrecision> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReleaseDatePrecision>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ReleaseDatePrecision.Year)]
    [InlineData(ReleaseDatePrecision.Month)]
    [InlineData(ReleaseDatePrecision.Day)]
    public void SerializationRoundtrip_Works(ReleaseDatePrecision rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ReleaseDatePrecision> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReleaseDatePrecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ReleaseDatePrecision>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ReleaseDatePrecision>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
