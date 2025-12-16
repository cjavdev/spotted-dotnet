using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class SimplifiedTrackObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SimplifiedTrackObject
        {
            ID = "id",
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
        };

        string expectedID = "id";
        List<SimplifiedArtistObject> expectedArtists =
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
        ];
        List<string> expectedAvailableMarkets = ["string"];
        long expectedDiscNumber = 0;
        long expectedDurationMs = 0;
        bool expectedExplicit = true;
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        bool expectedIsLocal = true;
        bool expectedIsPlayable = true;
        LinkedTrackObject expectedLinkedFrom = new()
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = "type",
            Uri = "uri",
        };
        string expectedName = "name";
        string expectedPreviewURL = "preview_url";
        bool expectedPublished = true;
        TrackRestrictionObject expectedRestrictions = new() { Published = true, Reason = "reason" };
        long expectedTrackNumber = 0;
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Artists);
        Assert.Equal(expectedArtists.Count, model.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], model.Artists[i]);
        }
        Assert.NotNull(model.AvailableMarkets);
        Assert.Equal(expectedAvailableMarkets.Count, model.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], model.AvailableMarkets[i]);
        }
        Assert.Equal(expectedDiscNumber, model.DiscNumber);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedExplicit, model.Explicit);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedIsLocal, model.IsLocal);
        Assert.Equal(expectedIsPlayable, model.IsPlayable);
        Assert.Equal(expectedLinkedFrom, model.LinkedFrom);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPreviewURL, model.PreviewURL);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedRestrictions, model.Restrictions);
        Assert.Equal(expectedTrackNumber, model.TrackNumber);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SimplifiedTrackObject
        {
            ID = "id",
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SimplifiedTrackObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SimplifiedTrackObject
        {
            ID = "id",
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SimplifiedTrackObject>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<SimplifiedArtistObject> expectedArtists =
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
        ];
        List<string> expectedAvailableMarkets = ["string"];
        long expectedDiscNumber = 0;
        long expectedDurationMs = 0;
        bool expectedExplicit = true;
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        bool expectedIsLocal = true;
        bool expectedIsPlayable = true;
        LinkedTrackObject expectedLinkedFrom = new()
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = "type",
            Uri = "uri",
        };
        string expectedName = "name";
        string expectedPreviewURL = "preview_url";
        bool expectedPublished = true;
        TrackRestrictionObject expectedRestrictions = new() { Published = true, Reason = "reason" };
        long expectedTrackNumber = 0;
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Artists);
        Assert.Equal(expectedArtists.Count, deserialized.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], deserialized.Artists[i]);
        }
        Assert.NotNull(deserialized.AvailableMarkets);
        Assert.Equal(expectedAvailableMarkets.Count, deserialized.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], deserialized.AvailableMarkets[i]);
        }
        Assert.Equal(expectedDiscNumber, deserialized.DiscNumber);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedExplicit, deserialized.Explicit);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedIsLocal, deserialized.IsLocal);
        Assert.Equal(expectedIsPlayable, deserialized.IsPlayable);
        Assert.Equal(expectedLinkedFrom, deserialized.LinkedFrom);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPreviewURL, deserialized.PreviewURL);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedRestrictions, deserialized.Restrictions);
        Assert.Equal(expectedTrackNumber, deserialized.TrackNumber);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SimplifiedTrackObject
        {
            ID = "id",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SimplifiedTrackObject { PreviewURL = "preview_url" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Artists);
        Assert.False(model.RawData.ContainsKey("artists"));
        Assert.Null(model.AvailableMarkets);
        Assert.False(model.RawData.ContainsKey("available_markets"));
        Assert.Null(model.DiscNumber);
        Assert.False(model.RawData.ContainsKey("disc_number"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.Explicit);
        Assert.False(model.RawData.ContainsKey("explicit"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.IsLocal);
        Assert.False(model.RawData.ContainsKey("is_local"));
        Assert.Null(model.IsPlayable);
        Assert.False(model.RawData.ContainsKey("is_playable"));
        Assert.Null(model.LinkedFrom);
        Assert.False(model.RawData.ContainsKey("linked_from"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
        Assert.Null(model.TrackNumber);
        Assert.False(model.RawData.ContainsKey("track_number"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SimplifiedTrackObject { PreviewURL = "preview_url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SimplifiedTrackObject
        {
            PreviewURL = "preview_url",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Artists = null,
            AvailableMarkets = null,
            DiscNumber = null,
            DurationMs = null,
            Explicit = null,
            ExternalURLs = null,
            Href = null,
            IsLocal = null,
            IsPlayable = null,
            LinkedFrom = null,
            Name = null,
            Published = null,
            Restrictions = null,
            TrackNumber = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Artists);
        Assert.False(model.RawData.ContainsKey("artists"));
        Assert.Null(model.AvailableMarkets);
        Assert.False(model.RawData.ContainsKey("available_markets"));
        Assert.Null(model.DiscNumber);
        Assert.False(model.RawData.ContainsKey("disc_number"));
        Assert.Null(model.DurationMs);
        Assert.False(model.RawData.ContainsKey("duration_ms"));
        Assert.Null(model.Explicit);
        Assert.False(model.RawData.ContainsKey("explicit"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.IsLocal);
        Assert.False(model.RawData.ContainsKey("is_local"));
        Assert.Null(model.IsPlayable);
        Assert.False(model.RawData.ContainsKey("is_playable"));
        Assert.Null(model.LinkedFrom);
        Assert.False(model.RawData.ContainsKey("linked_from"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
        Assert.Null(model.TrackNumber);
        Assert.False(model.RawData.ContainsKey("track_number"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SimplifiedTrackObject
        {
            PreviewURL = "preview_url",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Artists = null,
            AvailableMarkets = null,
            DiscNumber = null,
            DurationMs = null,
            Explicit = null,
            ExternalURLs = null,
            Href = null,
            IsLocal = null,
            IsPlayable = null,
            LinkedFrom = null,
            Name = null,
            Published = null,
            Restrictions = null,
            TrackNumber = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SimplifiedTrackObject
        {
            ID = "id",
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
            Published = true,
            Restrictions = new() { Published = true, Reason = "reason" },
            TrackNumber = 0,
            Type = "type",
            Uri = "uri",
        };

        Assert.Null(model.PreviewURL);
        Assert.False(model.RawData.ContainsKey("preview_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SimplifiedTrackObject
        {
            ID = "id",
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
            Published = true,
            Restrictions = new() { Published = true, Reason = "reason" },
            TrackNumber = 0,
            Type = "type",
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SimplifiedTrackObject
        {
            ID = "id",
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
            Published = true,
            Restrictions = new() { Published = true, Reason = "reason" },
            TrackNumber = 0,
            Type = "type",
            Uri = "uri",

            PreviewURL = null,
        };

        Assert.Null(model.PreviewURL);
        Assert.True(model.RawData.ContainsKey("preview_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SimplifiedTrackObject
        {
            ID = "id",
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
            Published = true,
            Restrictions = new() { Published = true, Reason = "reason" },
            TrackNumber = 0,
            Type = "type",
            Uri = "uri",

            PreviewURL = null,
        };

        model.Validate();
    }
}
