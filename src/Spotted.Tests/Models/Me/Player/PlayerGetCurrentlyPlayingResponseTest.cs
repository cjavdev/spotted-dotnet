using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerGetCurrentlyPlayingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlayerGetCurrentlyPlayingResponse
        {
            Actions = new()
            {
                InterruptingPlayback = true,
                Pausing = true,
                Resuming = true,
                Seeking = true,
                SkippingNext = true,
                SkippingPrev = true,
                TogglingRepeatContext = true,
                TogglingRepeatTrack = true,
                TogglingShuffle = true,
                TransferringPlayback = true,
            },
            Context = new()
            {
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = "type",
                Uri = "uri",
            },
            CurrentlyPlayingType = "currently_playing_type",
            IsPlaying = true,
            Item = new TrackObject()
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
            ProgressMs = 0,
            Timestamp = 0,
        };

        Actions expectedActions = new()
        {
            InterruptingPlayback = true,
            Pausing = true,
            Resuming = true,
            Seeking = true,
            SkippingNext = true,
            SkippingPrev = true,
            TogglingRepeatContext = true,
            TogglingRepeatTrack = true,
            TogglingShuffle = true,
            TransferringPlayback = true,
        };
        ContextObject expectedContext = new()
        {
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = "type",
            Uri = "uri",
        };
        string expectedCurrentlyPlayingType = "currently_playing_type";
        bool expectedIsPlaying = true;
        Item expectedItem = new TrackObject()
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
        long expectedProgressMs = 0;
        long expectedTimestamp = 0;

        Assert.Equal(expectedActions, model.Actions);
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedCurrentlyPlayingType, model.CurrentlyPlayingType);
        Assert.Equal(expectedIsPlaying, model.IsPlaying);
        Assert.Equal(expectedItem, model.Item);
        Assert.Equal(expectedProgressMs, model.ProgressMs);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlayerGetCurrentlyPlayingResponse
        {
            Actions = new()
            {
                InterruptingPlayback = true,
                Pausing = true,
                Resuming = true,
                Seeking = true,
                SkippingNext = true,
                SkippingPrev = true,
                TogglingRepeatContext = true,
                TogglingRepeatTrack = true,
                TogglingShuffle = true,
                TransferringPlayback = true,
            },
            Context = new()
            {
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = "type",
                Uri = "uri",
            },
            CurrentlyPlayingType = "currently_playing_type",
            IsPlaying = true,
            Item = new TrackObject()
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
            ProgressMs = 0,
            Timestamp = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlayerGetCurrentlyPlayingResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlayerGetCurrentlyPlayingResponse
        {
            Actions = new()
            {
                InterruptingPlayback = true,
                Pausing = true,
                Resuming = true,
                Seeking = true,
                SkippingNext = true,
                SkippingPrev = true,
                TogglingRepeatContext = true,
                TogglingRepeatTrack = true,
                TogglingShuffle = true,
                TransferringPlayback = true,
            },
            Context = new()
            {
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = "type",
                Uri = "uri",
            },
            CurrentlyPlayingType = "currently_playing_type",
            IsPlaying = true,
            Item = new TrackObject()
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
            ProgressMs = 0,
            Timestamp = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlayerGetCurrentlyPlayingResponse>(json);
        Assert.NotNull(deserialized);

        Actions expectedActions = new()
        {
            InterruptingPlayback = true,
            Pausing = true,
            Resuming = true,
            Seeking = true,
            SkippingNext = true,
            SkippingPrev = true,
            TogglingRepeatContext = true,
            TogglingRepeatTrack = true,
            TogglingShuffle = true,
            TransferringPlayback = true,
        };
        ContextObject expectedContext = new()
        {
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = "type",
            Uri = "uri",
        };
        string expectedCurrentlyPlayingType = "currently_playing_type";
        bool expectedIsPlaying = true;
        Item expectedItem = new TrackObject()
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
        long expectedProgressMs = 0;
        long expectedTimestamp = 0;

        Assert.Equal(expectedActions, deserialized.Actions);
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedCurrentlyPlayingType, deserialized.CurrentlyPlayingType);
        Assert.Equal(expectedIsPlaying, deserialized.IsPlaying);
        Assert.Equal(expectedItem, deserialized.Item);
        Assert.Equal(expectedProgressMs, deserialized.ProgressMs);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlayerGetCurrentlyPlayingResponse
        {
            Actions = new()
            {
                InterruptingPlayback = true,
                Pausing = true,
                Resuming = true,
                Seeking = true,
                SkippingNext = true,
                SkippingPrev = true,
                TogglingRepeatContext = true,
                TogglingRepeatTrack = true,
                TogglingShuffle = true,
                TransferringPlayback = true,
            },
            Context = new()
            {
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = "type",
                Uri = "uri",
            },
            CurrentlyPlayingType = "currently_playing_type",
            IsPlaying = true,
            Item = new TrackObject()
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
            ProgressMs = 0,
            Timestamp = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlayerGetCurrentlyPlayingResponse { };

        Assert.Null(model.Actions);
        Assert.False(model.RawData.ContainsKey("actions"));
        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.CurrentlyPlayingType);
        Assert.False(model.RawData.ContainsKey("currently_playing_type"));
        Assert.Null(model.IsPlaying);
        Assert.False(model.RawData.ContainsKey("is_playing"));
        Assert.Null(model.Item);
        Assert.False(model.RawData.ContainsKey("item"));
        Assert.Null(model.ProgressMs);
        Assert.False(model.RawData.ContainsKey("progress_ms"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlayerGetCurrentlyPlayingResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PlayerGetCurrentlyPlayingResponse
        {
            // Null should be interpreted as omitted for these properties
            Actions = null,
            Context = null,
            CurrentlyPlayingType = null,
            IsPlaying = null,
            Item = null,
            ProgressMs = null,
            Timestamp = null,
        };

        Assert.Null(model.Actions);
        Assert.False(model.RawData.ContainsKey("actions"));
        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.CurrentlyPlayingType);
        Assert.False(model.RawData.ContainsKey("currently_playing_type"));
        Assert.Null(model.IsPlaying);
        Assert.False(model.RawData.ContainsKey("is_playing"));
        Assert.Null(model.Item);
        Assert.False(model.RawData.ContainsKey("item"));
        Assert.Null(model.ProgressMs);
        Assert.False(model.RawData.ContainsKey("progress_ms"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlayerGetCurrentlyPlayingResponse
        {
            // Null should be interpreted as omitted for these properties
            Actions = null,
            Context = null,
            CurrentlyPlayingType = null,
            IsPlaying = null,
            Item = null,
            ProgressMs = null,
            Timestamp = null,
        };

        model.Validate();
    }
}

public class ActionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Actions
        {
            InterruptingPlayback = true,
            Pausing = true,
            Resuming = true,
            Seeking = true,
            SkippingNext = true,
            SkippingPrev = true,
            TogglingRepeatContext = true,
            TogglingRepeatTrack = true,
            TogglingShuffle = true,
            TransferringPlayback = true,
        };

        bool expectedInterruptingPlayback = true;
        bool expectedPausing = true;
        bool expectedResuming = true;
        bool expectedSeeking = true;
        bool expectedSkippingNext = true;
        bool expectedSkippingPrev = true;
        bool expectedTogglingRepeatContext = true;
        bool expectedTogglingRepeatTrack = true;
        bool expectedTogglingShuffle = true;
        bool expectedTransferringPlayback = true;

        Assert.Equal(expectedInterruptingPlayback, model.InterruptingPlayback);
        Assert.Equal(expectedPausing, model.Pausing);
        Assert.Equal(expectedResuming, model.Resuming);
        Assert.Equal(expectedSeeking, model.Seeking);
        Assert.Equal(expectedSkippingNext, model.SkippingNext);
        Assert.Equal(expectedSkippingPrev, model.SkippingPrev);
        Assert.Equal(expectedTogglingRepeatContext, model.TogglingRepeatContext);
        Assert.Equal(expectedTogglingRepeatTrack, model.TogglingRepeatTrack);
        Assert.Equal(expectedTogglingShuffle, model.TogglingShuffle);
        Assert.Equal(expectedTransferringPlayback, model.TransferringPlayback);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Actions
        {
            InterruptingPlayback = true,
            Pausing = true,
            Resuming = true,
            Seeking = true,
            SkippingNext = true,
            SkippingPrev = true,
            TogglingRepeatContext = true,
            TogglingRepeatTrack = true,
            TogglingShuffle = true,
            TransferringPlayback = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Actions>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Actions
        {
            InterruptingPlayback = true,
            Pausing = true,
            Resuming = true,
            Seeking = true,
            SkippingNext = true,
            SkippingPrev = true,
            TogglingRepeatContext = true,
            TogglingRepeatTrack = true,
            TogglingShuffle = true,
            TransferringPlayback = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Actions>(json);
        Assert.NotNull(deserialized);

        bool expectedInterruptingPlayback = true;
        bool expectedPausing = true;
        bool expectedResuming = true;
        bool expectedSeeking = true;
        bool expectedSkippingNext = true;
        bool expectedSkippingPrev = true;
        bool expectedTogglingRepeatContext = true;
        bool expectedTogglingRepeatTrack = true;
        bool expectedTogglingShuffle = true;
        bool expectedTransferringPlayback = true;

        Assert.Equal(expectedInterruptingPlayback, deserialized.InterruptingPlayback);
        Assert.Equal(expectedPausing, deserialized.Pausing);
        Assert.Equal(expectedResuming, deserialized.Resuming);
        Assert.Equal(expectedSeeking, deserialized.Seeking);
        Assert.Equal(expectedSkippingNext, deserialized.SkippingNext);
        Assert.Equal(expectedSkippingPrev, deserialized.SkippingPrev);
        Assert.Equal(expectedTogglingRepeatContext, deserialized.TogglingRepeatContext);
        Assert.Equal(expectedTogglingRepeatTrack, deserialized.TogglingRepeatTrack);
        Assert.Equal(expectedTogglingShuffle, deserialized.TogglingShuffle);
        Assert.Equal(expectedTransferringPlayback, deserialized.TransferringPlayback);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Actions
        {
            InterruptingPlayback = true,
            Pausing = true,
            Resuming = true,
            Seeking = true,
            SkippingNext = true,
            SkippingPrev = true,
            TogglingRepeatContext = true,
            TogglingRepeatTrack = true,
            TogglingShuffle = true,
            TransferringPlayback = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Actions { };

        Assert.Null(model.InterruptingPlayback);
        Assert.False(model.RawData.ContainsKey("interrupting_playback"));
        Assert.Null(model.Pausing);
        Assert.False(model.RawData.ContainsKey("pausing"));
        Assert.Null(model.Resuming);
        Assert.False(model.RawData.ContainsKey("resuming"));
        Assert.Null(model.Seeking);
        Assert.False(model.RawData.ContainsKey("seeking"));
        Assert.Null(model.SkippingNext);
        Assert.False(model.RawData.ContainsKey("skipping_next"));
        Assert.Null(model.SkippingPrev);
        Assert.False(model.RawData.ContainsKey("skipping_prev"));
        Assert.Null(model.TogglingRepeatContext);
        Assert.False(model.RawData.ContainsKey("toggling_repeat_context"));
        Assert.Null(model.TogglingRepeatTrack);
        Assert.False(model.RawData.ContainsKey("toggling_repeat_track"));
        Assert.Null(model.TogglingShuffle);
        Assert.False(model.RawData.ContainsKey("toggling_shuffle"));
        Assert.Null(model.TransferringPlayback);
        Assert.False(model.RawData.ContainsKey("transferring_playback"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Actions { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Actions
        {
            // Null should be interpreted as omitted for these properties
            InterruptingPlayback = null,
            Pausing = null,
            Resuming = null,
            Seeking = null,
            SkippingNext = null,
            SkippingPrev = null,
            TogglingRepeatContext = null,
            TogglingRepeatTrack = null,
            TogglingShuffle = null,
            TransferringPlayback = null,
        };

        Assert.Null(model.InterruptingPlayback);
        Assert.False(model.RawData.ContainsKey("interrupting_playback"));
        Assert.Null(model.Pausing);
        Assert.False(model.RawData.ContainsKey("pausing"));
        Assert.Null(model.Resuming);
        Assert.False(model.RawData.ContainsKey("resuming"));
        Assert.Null(model.Seeking);
        Assert.False(model.RawData.ContainsKey("seeking"));
        Assert.Null(model.SkippingNext);
        Assert.False(model.RawData.ContainsKey("skipping_next"));
        Assert.Null(model.SkippingPrev);
        Assert.False(model.RawData.ContainsKey("skipping_prev"));
        Assert.Null(model.TogglingRepeatContext);
        Assert.False(model.RawData.ContainsKey("toggling_repeat_context"));
        Assert.Null(model.TogglingRepeatTrack);
        Assert.False(model.RawData.ContainsKey("toggling_repeat_track"));
        Assert.Null(model.TogglingShuffle);
        Assert.False(model.RawData.ContainsKey("toggling_shuffle"));
        Assert.Null(model.TransferringPlayback);
        Assert.False(model.RawData.ContainsKey("transferring_playback"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Actions
        {
            // Null should be interpreted as omitted for these properties
            InterruptingPlayback = null,
            Pausing = null,
            Resuming = null,
            Seeking = null,
            SkippingNext = null,
            SkippingPrev = null,
            TogglingRepeatContext = null,
            TogglingRepeatTrack = null,
            TogglingShuffle = null,
            TransferringPlayback = null,
        };

        model.Validate();
    }
}
