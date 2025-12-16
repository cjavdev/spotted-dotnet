using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Albums;

namespace Spotted.Tests.Models.Albums;

public class AlbumListTracksPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AlbumListTracksPageResponse
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
        List<SimplifiedTrackObject> expectedItems =
        [
            new()
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
        var model = new AlbumListTracksPageResponse
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
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumListTracksPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AlbumListTracksPageResponse
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
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumListTracksPageResponse>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<SimplifiedTrackObject> expectedItems =
        [
            new()
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
        var model = new AlbumListTracksPageResponse
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
                },
            ],
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AlbumListTracksPageResponse
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
        var model = new AlbumListTracksPageResponse
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
        var model = new AlbumListTracksPageResponse
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
        var model = new AlbumListTracksPageResponse
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
