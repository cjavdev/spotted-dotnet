using System;
using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Models.Playlists;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Playlists;

public class PlaylistRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            ID = "id",
            Collaborative = true,
            Description = "description",
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
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
            Owner = new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = Models::PlaylistUserObjectType.User,
                Uri = "uri",
                DisplayName = "display_name",
            },
            Published = true,
            SnapshotID = "snapshot_id",
            Tracks = new()
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
                        AddedBy = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                        },
                        IsLocal = true,
                        Track = new Models::TrackObject()
                        {
                            ID = "id",
                            Album = new()
                            {
                                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                                AlbumType = Models::AlbumType.Compilation,
                                Artists =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        ExternalURLs = new() { Spotify = "spotify" },
                                        Href = "href",
                                        Name = "name",
                                        Type = Models::SimplifiedArtistObjectType.Artist,
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
                                ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                                TotalTracks = 9,
                                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                                Restrictions = new() { Reason = Models::Reason.Market },
                            },
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            Type = Models::TrackObjectType.Track,
                            Uri = "uri",
                        },
                    },
                ],
            },
            Type = "type",
            Uri = "uri",
        };

        string expectedID = "id";
        bool expectedCollaborative = true;
        string expectedDescription = "description";
        Models::ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        Models::FollowersObject expectedFollowers = new() { Href = "href", Total = 0 };
        string expectedHref = "href";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        string expectedName = "name";
        Owner expectedOwner = new()
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };
        bool expectedPublished = true;
        string expectedSnapshotID = "snapshot_id";
        PlaylistRetrieveResponseTracks expectedTracks = new()
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
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = Models::PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new Models::TrackObject()
                    {
                        ID = "id",
                        Album = new()
                        {
                            ID = "2up3OPMp9Tb4dAKM2erWXQ",
                            AlbumType = Models::AlbumType.Compilation,
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Models::Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
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
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCollaborative, model.Collaborative);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedFollowers, model.Followers);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOwner, model.Owner);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedSnapshotID, model.SnapshotID);
        Assert.Equal(expectedTracks, model.Tracks);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            ID = "id",
            Collaborative = true,
            Description = "description",
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
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
            Owner = new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = Models::PlaylistUserObjectType.User,
                Uri = "uri",
                DisplayName = "display_name",
            },
            Published = true,
            SnapshotID = "snapshot_id",
            Tracks = new()
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
                        AddedBy = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                        },
                        IsLocal = true,
                        Track = new Models::TrackObject()
                        {
                            ID = "id",
                            Album = new()
                            {
                                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                                AlbumType = Models::AlbumType.Compilation,
                                Artists =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        ExternalURLs = new() { Spotify = "spotify" },
                                        Href = "href",
                                        Name = "name",
                                        Type = Models::SimplifiedArtistObjectType.Artist,
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
                                ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                                TotalTracks = 9,
                                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                                Restrictions = new() { Reason = Models::Reason.Market },
                            },
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            Type = Models::TrackObjectType.Track,
                            Uri = "uri",
                        },
                    },
                ],
            },
            Type = "type",
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlaylistRetrieveResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            ID = "id",
            Collaborative = true,
            Description = "description",
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
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
            Owner = new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = Models::PlaylistUserObjectType.User,
                Uri = "uri",
                DisplayName = "display_name",
            },
            Published = true,
            SnapshotID = "snapshot_id",
            Tracks = new()
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
                        AddedBy = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                        },
                        IsLocal = true,
                        Track = new Models::TrackObject()
                        {
                            ID = "id",
                            Album = new()
                            {
                                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                                AlbumType = Models::AlbumType.Compilation,
                                Artists =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        ExternalURLs = new() { Spotify = "spotify" },
                                        Href = "href",
                                        Name = "name",
                                        Type = Models::SimplifiedArtistObjectType.Artist,
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
                                ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                                TotalTracks = 9,
                                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                                Restrictions = new() { Reason = Models::Reason.Market },
                            },
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            Type = Models::TrackObjectType.Track,
                            Uri = "uri",
                        },
                    },
                ],
            },
            Type = "type",
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlaylistRetrieveResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedCollaborative = true;
        string expectedDescription = "description";
        Models::ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        Models::FollowersObject expectedFollowers = new() { Href = "href", Total = 0 };
        string expectedHref = "href";
        List<Models::ImageObject> expectedImages =
        [
            new()
            {
                Height = 300,
                URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                Width = 300,
            },
        ];
        string expectedName = "name";
        Owner expectedOwner = new()
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };
        bool expectedPublished = true;
        string expectedSnapshotID = "snapshot_id";
        PlaylistRetrieveResponseTracks expectedTracks = new()
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
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = Models::PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new Models::TrackObject()
                    {
                        ID = "id",
                        Album = new()
                        {
                            ID = "2up3OPMp9Tb4dAKM2erWXQ",
                            AlbumType = Models::AlbumType.Compilation,
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Models::Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
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
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCollaborative, deserialized.Collaborative);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedFollowers, deserialized.Followers);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOwner, deserialized.Owner);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedSnapshotID, deserialized.SnapshotID);
        Assert.Equal(expectedTracks, deserialized.Tracks);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            ID = "id",
            Collaborative = true,
            Description = "description",
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
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
            Owner = new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = Models::PlaylistUserObjectType.User,
                Uri = "uri",
                DisplayName = "display_name",
            },
            Published = true,
            SnapshotID = "snapshot_id",
            Tracks = new()
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
                        AddedBy = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                        },
                        IsLocal = true,
                        Track = new Models::TrackObject()
                        {
                            ID = "id",
                            Album = new()
                            {
                                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                                AlbumType = Models::AlbumType.Compilation,
                                Artists =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        ExternalURLs = new() { Spotify = "spotify" },
                                        Href = "href",
                                        Name = "name",
                                        Type = Models::SimplifiedArtistObjectType.Artist,
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
                                ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                                TotalTracks = 9,
                                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                                Restrictions = new() { Reason = Models::Reason.Market },
                            },
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            Type = Models::TrackObjectType.Track,
                            Uri = "uri",
                        },
                    },
                ],
            },
            Type = "type",
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlaylistRetrieveResponse { Description = "description" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Collaborative);
        Assert.False(model.RawData.ContainsKey("collaborative"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Images);
        Assert.False(model.RawData.ContainsKey("images"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Owner);
        Assert.False(model.RawData.ContainsKey("owner"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.SnapshotID);
        Assert.False(model.RawData.ContainsKey("snapshot_id"));
        Assert.Null(model.Tracks);
        Assert.False(model.RawData.ContainsKey("tracks"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlaylistRetrieveResponse { Description = "description" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            Description = "description",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Collaborative = null,
            ExternalURLs = null,
            Followers = null,
            Href = null,
            Images = null,
            Name = null,
            Owner = null,
            Published = null,
            SnapshotID = null,
            Tracks = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Collaborative);
        Assert.False(model.RawData.ContainsKey("collaborative"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Followers);
        Assert.False(model.RawData.ContainsKey("followers"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Images);
        Assert.False(model.RawData.ContainsKey("images"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Owner);
        Assert.False(model.RawData.ContainsKey("owner"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.SnapshotID);
        Assert.False(model.RawData.ContainsKey("snapshot_id"));
        Assert.Null(model.Tracks);
        Assert.False(model.RawData.ContainsKey("tracks"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            Description = "description",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Collaborative = null,
            ExternalURLs = null,
            Followers = null,
            Href = null,
            Images = null,
            Name = null,
            Owner = null,
            Published = null,
            SnapshotID = null,
            Tracks = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            ID = "id",
            Collaborative = true,
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
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
            Owner = new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = Models::PlaylistUserObjectType.User,
                Uri = "uri",
                DisplayName = "display_name",
            },
            Published = true,
            SnapshotID = "snapshot_id",
            Tracks = new()
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
                        AddedBy = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                        },
                        IsLocal = true,
                        Track = new Models::TrackObject()
                        {
                            ID = "id",
                            Album = new()
                            {
                                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                                AlbumType = Models::AlbumType.Compilation,
                                Artists =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        ExternalURLs = new() { Spotify = "spotify" },
                                        Href = "href",
                                        Name = "name",
                                        Type = Models::SimplifiedArtistObjectType.Artist,
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
                                ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                                TotalTracks = 9,
                                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                                Restrictions = new() { Reason = Models::Reason.Market },
                            },
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            Type = Models::TrackObjectType.Track,
                            Uri = "uri",
                        },
                    },
                ],
            },
            Type = "type",
            Uri = "uri",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            ID = "id",
            Collaborative = true,
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
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
            Owner = new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = Models::PlaylistUserObjectType.User,
                Uri = "uri",
                DisplayName = "display_name",
            },
            Published = true,
            SnapshotID = "snapshot_id",
            Tracks = new()
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
                        AddedBy = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                        },
                        IsLocal = true,
                        Track = new Models::TrackObject()
                        {
                            ID = "id",
                            Album = new()
                            {
                                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                                AlbumType = Models::AlbumType.Compilation,
                                Artists =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        ExternalURLs = new() { Spotify = "spotify" },
                                        Href = "href",
                                        Name = "name",
                                        Type = Models::SimplifiedArtistObjectType.Artist,
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
                                ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                                TotalTracks = 9,
                                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                                Restrictions = new() { Reason = Models::Reason.Market },
                            },
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            Type = Models::TrackObjectType.Track,
                            Uri = "uri",
                        },
                    },
                ],
            },
            Type = "type",
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            ID = "id",
            Collaborative = true,
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
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
            Owner = new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = Models::PlaylistUserObjectType.User,
                Uri = "uri",
                DisplayName = "display_name",
            },
            Published = true,
            SnapshotID = "snapshot_id",
            Tracks = new()
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
                        AddedBy = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                        },
                        IsLocal = true,
                        Track = new Models::TrackObject()
                        {
                            ID = "id",
                            Album = new()
                            {
                                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                                AlbumType = Models::AlbumType.Compilation,
                                Artists =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        ExternalURLs = new() { Spotify = "spotify" },
                                        Href = "href",
                                        Name = "name",
                                        Type = Models::SimplifiedArtistObjectType.Artist,
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
                                ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                                TotalTracks = 9,
                                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                                Restrictions = new() { Reason = Models::Reason.Market },
                            },
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            Type = Models::TrackObjectType.Track,
                            Uri = "uri",
                        },
                    },
                ],
            },
            Type = "type",
            Uri = "uri",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlaylistRetrieveResponse
        {
            ID = "id",
            Collaborative = true,
            ExternalURLs = new() { Spotify = "spotify" },
            Followers = new() { Href = "href", Total = 0 },
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
            Owner = new()
            {
                ID = "id",
                ExternalURLs = new() { Spotify = "spotify" },
                Href = "href",
                Type = Models::PlaylistUserObjectType.User,
                Uri = "uri",
                DisplayName = "display_name",
            },
            Published = true,
            SnapshotID = "snapshot_id",
            Tracks = new()
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
                        AddedBy = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                        },
                        IsLocal = true,
                        Track = new Models::TrackObject()
                        {
                            ID = "id",
                            Album = new()
                            {
                                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                                AlbumType = Models::AlbumType.Compilation,
                                Artists =
                                [
                                    new()
                                    {
                                        ID = "id",
                                        ExternalURLs = new() { Spotify = "spotify" },
                                        Href = "href",
                                        Name = "name",
                                        Type = Models::SimplifiedArtistObjectType.Artist,
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
                                ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                                TotalTracks = 9,
                                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                                Restrictions = new() { Reason = Models::Reason.Market },
                            },
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            Type = Models::TrackObjectType.Track,
                            Uri = "uri",
                        },
                    },
                ],
            },
            Type = "type",
            Uri = "uri",

            Description = null,
        };

        model.Validate();
    }
}

public class OwnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };

        string expectedID = "id";
        Models::ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        string expectedHref = "href";
        ApiEnum<string, Models::PlaylistUserObjectType> expectedType =
            Models::PlaylistUserObjectType.User;
        string expectedUri = "uri";
        string expectedDisplayName = "display_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
        Assert.Equal(expectedDisplayName, model.DisplayName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Owner>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Owner>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Models::ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        string expectedHref = "href";
        ApiEnum<string, Models::PlaylistUserObjectType> expectedType =
            Models::PlaylistUserObjectType.User;
        string expectedUri = "uri";
        string expectedDisplayName = "display_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Owner { DisplayName = "display_name" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Owner { DisplayName = "display_name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Owner
        {
            DisplayName = "display_name",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Href = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Owner
        {
            DisplayName = "display_name",

            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Href = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",
        };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",

            DisplayName = null,
        };

        Assert.Null(model.DisplayName);
        Assert.True(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = Models::PlaylistUserObjectType.User,
            Uri = "uri",

            DisplayName = null,
        };

        model.Validate();
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1 { DisplayName = "display_name" };

        string expectedDisplayName = "display_name";

        Assert.Equal(expectedDisplayName, model.DisplayName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1 { DisplayName = "display_name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1 { DisplayName = "display_name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);
        Assert.NotNull(deserialized);

        string expectedDisplayName = "display_name";

        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1 { DisplayName = "display_name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1 { };

        Assert.Null(model.DisplayName);
        Assert.False(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntersectionMember1 { DisplayName = null };

        Assert.Null(model.DisplayName);
        Assert.True(model.RawData.ContainsKey("display_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntersectionMember1 { DisplayName = null };

        model.Validate();
    }
}

public class PlaylistRetrieveResponseTracksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlaylistRetrieveResponseTracks
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
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = Models::PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new Models::TrackObject()
                    {
                        ID = "id",
                        Album = new()
                        {
                            ID = "2up3OPMp9Tb4dAKM2erWXQ",
                            AlbumType = Models::AlbumType.Compilation,
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Models::Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
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
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::PlaylistTrackObject> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AddedBy = new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Type = Models::PlaylistUserObjectType.User,
                    Uri = "uri",
                },
                IsLocal = true,
                Track = new Models::TrackObject()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = Models::AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
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
                        ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Restrictions = new() { Reason = Models::Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Type = Models::SimplifiedArtistObjectType.Artist,
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
                    Type = Models::TrackObjectType.Track,
                    Uri = "uri",
                },
            },
        ];

        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedLimit, model.Limit);
        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedOffset, model.Offset);
        Assert.Equal(expectedPrevious, model.Previous);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlaylistRetrieveResponseTracks
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
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = Models::PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new Models::TrackObject()
                    {
                        ID = "id",
                        Album = new()
                        {
                            ID = "2up3OPMp9Tb4dAKM2erWXQ",
                            AlbumType = Models::AlbumType.Compilation,
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Models::Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
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
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlaylistRetrieveResponseTracks>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlaylistRetrieveResponseTracks
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
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = Models::PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new Models::TrackObject()
                    {
                        ID = "id",
                        Album = new()
                        {
                            ID = "2up3OPMp9Tb4dAKM2erWXQ",
                            AlbumType = Models::AlbumType.Compilation,
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Models::Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
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
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlaylistRetrieveResponseTracks>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::PlaylistTrackObject> expectedItems =
        [
            new()
            {
                AddedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AddedBy = new()
                {
                    ID = "id",
                    ExternalURLs = new() { Spotify = "spotify" },
                    Href = "href",
                    Type = Models::PlaylistUserObjectType.User,
                    Uri = "uri",
                },
                IsLocal = true,
                Track = new Models::TrackObject()
                {
                    ID = "id",
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = Models::AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
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
                        ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Restrictions = new() { Reason = Models::Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Type = Models::SimplifiedArtistObjectType.Artist,
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
                    Type = Models::TrackObjectType.Track,
                    Uri = "uri",
                },
            },
        ];

        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedLimit, deserialized.Limit);
        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedOffset, deserialized.Offset);
        Assert.Equal(expectedPrevious, deserialized.Previous);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlaylistRetrieveResponseTracks
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
                    AddedBy = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = Models::PlaylistUserObjectType.User,
                        Uri = "uri",
                    },
                    IsLocal = true,
                    Track = new Models::TrackObject()
                    {
                        ID = "id",
                        Album = new()
                        {
                            ID = "2up3OPMp9Tb4dAKM2erWXQ",
                            AlbumType = Models::AlbumType.Compilation,
                            Artists =
                            [
                                new()
                                {
                                    ID = "id",
                                    ExternalURLs = new() { Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Type = Models::SimplifiedArtistObjectType.Artist,
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
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Restrictions = new() { Reason = Models::Reason.Market },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Type = Models::SimplifiedArtistObjectType.Artist,
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
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlaylistRetrieveResponseTracks
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlaylistRetrieveResponseTracks
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
        var model = new PlaylistRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,

            // Null should be interpreted as omitted for these properties
            Items = null,
        };

        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlaylistRetrieveResponseTracks
        {
            Href = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n",
            Limit = 20,
            Next = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Offset = 0,
            Previous = "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
            Total = 4,

            // Null should be interpreted as omitted for these properties
            Items = null,
        };

        model.Validate();
    }
}
