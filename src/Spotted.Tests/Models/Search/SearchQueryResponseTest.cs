using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models.Search;
using Models = Spotted.Models;

namespace Spotted.Tests.Models.Search;

public class SearchQueryResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchQueryResponse
        {
            Albums = new()
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
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = ReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                ],
                Published = true,
            },
            Artists = new()
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
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        Popularity = 0,
                        Published = true,
                        Type = Models::Type.Artist,
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
            Audiobooks = new()
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
                    },
                ],
                Published = true,
            },
            Episodes = new()
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
                        ReleaseDatePrecision =
                            Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
                ],
                Published = true,
            },
            Playlists = new()
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
                        Collaborative = true,
                        Description = "description",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        Owner = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Published = true,
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                            DisplayName = "display_name",
                        },
                        Published = true,
                        SnapshotID = "snapshot_id",
                        Tracks = new()
                        {
                            Href = "href",
                            Published = true,
                            Total = 0,
                        },
                        Type = "type",
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
            Shows = new()
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
                ],
                Published = true,
            },
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
                                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Published = true,
                                    Type = Models::SimplifiedArtistObjectType.Artist,
                                    Uri = "uri",
                                },
                            ],
                            AvailableMarkets = ["CA", "BR", "IT"],
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
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
                            Name = "name",
                            ReleaseDate = "1981-12",
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Published = true,
                            Restrictions = new()
                            {
                                Published = true,
                                Reason = Models::Reason.Market,
                            },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
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
                            Published = true,
                            Upc = "upc",
                        },
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
                        Popularity = 0,
                        PreviewURL = "preview_url",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        TrackNumber = 0,
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
        };

        SearchQueryResponseAlbums expectedAlbums = new()
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                },
            ],
            Published = true,
        };
        SearchQueryResponseArtists expectedArtists = new()
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
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Published = true,
        };
        SearchQueryResponseAudiobooks expectedAudiobooks = new()
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
                },
            ],
            Published = true,
        };
        SearchQueryResponseEpisodes expectedEpisodes = new()
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
                    ReleaseDatePrecision = Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
            ],
            Published = true,
        };
        Models::PagingPlaylistObject expectedPlaylists = new()
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
                    Collaborative = true,
                    Description = "description",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    Owner = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Published = true,
                        Type = Models::PlaylistUserObjectType.User,
                        Uri = "uri",
                        DisplayName = "display_name",
                    },
                    Published = true,
                    SnapshotID = "snapshot_id",
                    Tracks = new()
                    {
                        Href = "href",
                        Published = true,
                        Total = 0,
                    },
                    Type = "type",
                    Uri = "uri",
                },
            ],
            Published = true,
        };
        SearchQueryResponseShows expectedShows = new()
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
            ],
            Published = true,
        };
        SearchQueryResponseTracks expectedTracks = new()
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
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = Models::AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
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
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = Models::TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        Assert.Equal(expectedAlbums, model.Albums);
        Assert.Equal(expectedArtists, model.Artists);
        Assert.Equal(expectedAudiobooks, model.Audiobooks);
        Assert.Equal(expectedEpisodes, model.Episodes);
        Assert.Equal(expectedPlaylists, model.Playlists);
        Assert.Equal(expectedShows, model.Shows);
        Assert.Equal(expectedTracks, model.Tracks);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SearchQueryResponse
        {
            Albums = new()
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
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = ReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                ],
                Published = true,
            },
            Artists = new()
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
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        Popularity = 0,
                        Published = true,
                        Type = Models::Type.Artist,
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
            Audiobooks = new()
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
                    },
                ],
                Published = true,
            },
            Episodes = new()
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
                        ReleaseDatePrecision =
                            Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
                ],
                Published = true,
            },
            Playlists = new()
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
                        Collaborative = true,
                        Description = "description",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        Owner = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Published = true,
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                            DisplayName = "display_name",
                        },
                        Published = true,
                        SnapshotID = "snapshot_id",
                        Tracks = new()
                        {
                            Href = "href",
                            Published = true,
                            Total = 0,
                        },
                        Type = "type",
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
            Shows = new()
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
                ],
                Published = true,
            },
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
                                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Published = true,
                                    Type = Models::SimplifiedArtistObjectType.Artist,
                                    Uri = "uri",
                                },
                            ],
                            AvailableMarkets = ["CA", "BR", "IT"],
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
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
                            Name = "name",
                            ReleaseDate = "1981-12",
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Published = true,
                            Restrictions = new()
                            {
                                Published = true,
                                Reason = Models::Reason.Market,
                            },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
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
                            Published = true,
                            Upc = "upc",
                        },
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
                        Popularity = 0,
                        PreviewURL = "preview_url",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        TrackNumber = 0,
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchQueryResponse
        {
            Albums = new()
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
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = ReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                ],
                Published = true,
            },
            Artists = new()
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
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        Popularity = 0,
                        Published = true,
                        Type = Models::Type.Artist,
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
            Audiobooks = new()
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
                    },
                ],
                Published = true,
            },
            Episodes = new()
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
                        ReleaseDatePrecision =
                            Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
                ],
                Published = true,
            },
            Playlists = new()
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
                        Collaborative = true,
                        Description = "description",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        Owner = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Published = true,
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                            DisplayName = "display_name",
                        },
                        Published = true,
                        SnapshotID = "snapshot_id",
                        Tracks = new()
                        {
                            Href = "href",
                            Published = true,
                            Total = 0,
                        },
                        Type = "type",
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
            Shows = new()
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
                ],
                Published = true,
            },
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
                                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Published = true,
                                    Type = Models::SimplifiedArtistObjectType.Artist,
                                    Uri = "uri",
                                },
                            ],
                            AvailableMarkets = ["CA", "BR", "IT"],
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
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
                            Name = "name",
                            ReleaseDate = "1981-12",
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Published = true,
                            Restrictions = new()
                            {
                                Published = true,
                                Reason = Models::Reason.Market,
                            },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
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
                            Published = true,
                            Upc = "upc",
                        },
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
                        Popularity = 0,
                        PreviewURL = "preview_url",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        TrackNumber = 0,
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponse>(json);
        Assert.NotNull(deserialized);

        SearchQueryResponseAlbums expectedAlbums = new()
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                },
            ],
            Published = true,
        };
        SearchQueryResponseArtists expectedArtists = new()
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
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Published = true,
        };
        SearchQueryResponseAudiobooks expectedAudiobooks = new()
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
                },
            ],
            Published = true,
        };
        SearchQueryResponseEpisodes expectedEpisodes = new()
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
                    ReleaseDatePrecision = Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
            ],
            Published = true,
        };
        Models::PagingPlaylistObject expectedPlaylists = new()
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
                    Collaborative = true,
                    Description = "description",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    Owner = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Published = true,
                        Type = Models::PlaylistUserObjectType.User,
                        Uri = "uri",
                        DisplayName = "display_name",
                    },
                    Published = true,
                    SnapshotID = "snapshot_id",
                    Tracks = new()
                    {
                        Href = "href",
                        Published = true,
                        Total = 0,
                    },
                    Type = "type",
                    Uri = "uri",
                },
            ],
            Published = true,
        };
        SearchQueryResponseShows expectedShows = new()
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
            ],
            Published = true,
        };
        SearchQueryResponseTracks expectedTracks = new()
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
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = Models::AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
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
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = Models::TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        Assert.Equal(expectedAlbums, deserialized.Albums);
        Assert.Equal(expectedArtists, deserialized.Artists);
        Assert.Equal(expectedAudiobooks, deserialized.Audiobooks);
        Assert.Equal(expectedEpisodes, deserialized.Episodes);
        Assert.Equal(expectedPlaylists, deserialized.Playlists);
        Assert.Equal(expectedShows, deserialized.Shows);
        Assert.Equal(expectedTracks, deserialized.Tracks);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SearchQueryResponse
        {
            Albums = new()
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
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = ReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                ],
                Published = true,
            },
            Artists = new()
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
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                                URL =
                                    "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                                Width = 300,
                                Published = true,
                            },
                        ],
                        Name = "name",
                        Popularity = 0,
                        Published = true,
                        Type = Models::Type.Artist,
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
            Audiobooks = new()
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
                    },
                ],
                Published = true,
            },
            Episodes = new()
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
                        ReleaseDatePrecision =
                            Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
                ],
                Published = true,
            },
            Playlists = new()
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
                        Collaborative = true,
                        Description = "description",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        Owner = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Published = true,
                            Type = Models::PlaylistUserObjectType.User,
                            Uri = "uri",
                            DisplayName = "display_name",
                        },
                        Published = true,
                        SnapshotID = "snapshot_id",
                        Tracks = new()
                        {
                            Href = "href",
                            Published = true,
                            Total = 0,
                        },
                        Type = "type",
                        Uri = "uri",
                    },
                ],
                Published = true,
            },
            Shows = new()
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
                ],
                Published = true,
            },
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
                                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                    Href = "href",
                                    Name = "name",
                                    Published = true,
                                    Type = Models::SimplifiedArtistObjectType.Artist,
                                    Uri = "uri",
                                },
                            ],
                            AvailableMarkets = ["CA", "BR", "IT"],
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
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
                            Name = "name",
                            ReleaseDate = "1981-12",
                            ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                            TotalTracks = 9,
                            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                            Published = true,
                            Restrictions = new()
                            {
                                Published = true,
                                Reason = Models::Reason.Market,
                            },
                        },
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
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
                            Published = true,
                            Upc = "upc",
                        },
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
                        Popularity = 0,
                        PreviewURL = "preview_url",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = "reason" },
                        TrackNumber = 0,
                        Type = Models::TrackObjectType.Track,
                        Uri = "uri",
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
        var model = new SearchQueryResponse { };

        Assert.Null(model.Albums);
        Assert.False(model.RawData.ContainsKey("albums"));
        Assert.Null(model.Artists);
        Assert.False(model.RawData.ContainsKey("artists"));
        Assert.Null(model.Audiobooks);
        Assert.False(model.RawData.ContainsKey("audiobooks"));
        Assert.Null(model.Episodes);
        Assert.False(model.RawData.ContainsKey("episodes"));
        Assert.Null(model.Playlists);
        Assert.False(model.RawData.ContainsKey("playlists"));
        Assert.Null(model.Shows);
        Assert.False(model.RawData.ContainsKey("shows"));
        Assert.Null(model.Tracks);
        Assert.False(model.RawData.ContainsKey("tracks"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SearchQueryResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SearchQueryResponse
        {
            // Null should be interpreted as omitted for these properties
            Albums = null,
            Artists = null,
            Audiobooks = null,
            Episodes = null,
            Playlists = null,
            Shows = null,
            Tracks = null,
        };

        Assert.Null(model.Albums);
        Assert.False(model.RawData.ContainsKey("albums"));
        Assert.Null(model.Artists);
        Assert.False(model.RawData.ContainsKey("artists"));
        Assert.Null(model.Audiobooks);
        Assert.False(model.RawData.ContainsKey("audiobooks"));
        Assert.Null(model.Episodes);
        Assert.False(model.RawData.ContainsKey("episodes"));
        Assert.Null(model.Playlists);
        Assert.False(model.RawData.ContainsKey("playlists"));
        Assert.Null(model.Shows);
        Assert.False(model.RawData.ContainsKey("shows"));
        Assert.Null(model.Tracks);
        Assert.False(model.RawData.ContainsKey("tracks"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SearchQueryResponse
        {
            // Null should be interpreted as omitted for these properties
            Albums = null,
            Artists = null,
            Audiobooks = null,
            Episodes = null,
            Playlists = null,
            Shows = null,
            Tracks = null,
        };

        model.Validate();
    }
}

public class SearchQueryResponseAlbumsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchQueryResponseAlbums
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Models::Reason.Market },
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
        List<Item> expectedItems =
        [
            new()
            {
                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                AlbumType = AlbumType.Compilation,
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Published = true,
                        Type = Models::SimplifiedArtistObjectType.Artist,
                        Uri = "uri",
                    },
                ],
                AvailableMarkets = ["CA", "BR", "IT"],
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "href",
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
                Name = "name",
                ReleaseDate = "1981-12",
                ReleaseDatePrecision = ReleaseDatePrecision.Year,
                TotalTracks = 9,
                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                Published = true,
                Restrictions = new() { Published = true, Reason = Models::Reason.Market },
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
        var model = new SearchQueryResponseAlbums
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseAlbums>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchQueryResponseAlbums
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseAlbums>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Item> expectedItems =
        [
            new()
            {
                ID = "2up3OPMp9Tb4dAKM2erWXQ",
                AlbumType = AlbumType.Compilation,
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Published = true,
                        Type = Models::SimplifiedArtistObjectType.Artist,
                        Uri = "uri",
                    },
                ],
                AvailableMarkets = ["CA", "BR", "IT"],
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "href",
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
                Name = "name",
                ReleaseDate = "1981-12",
                ReleaseDatePrecision = ReleaseDatePrecision.Year,
                TotalTracks = 9,
                Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                Published = true,
                Restrictions = new() { Published = true, Reason = Models::Reason.Market },
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
        var model = new SearchQueryResponseAlbums
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
                    ID = "2up3OPMp9Tb4dAKM2erWXQ",
                    AlbumType = AlbumType.Compilation,
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = ReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                },
            ],
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchQueryResponseAlbums
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
        var model = new SearchQueryResponseAlbums
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
        var model = new SearchQueryResponseAlbums
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
        var model = new SearchQueryResponseAlbums
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

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
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
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Published = true,
            Restrictions = new() { Published = true, Reason = Models::Reason.Market },
        };

        string expectedID = "2up3OPMp9Tb4dAKM2erWXQ";
        ApiEnum<string, AlbumType> expectedAlbumType = AlbumType.Compilation;
        List<Models::SimplifiedArtistObject> expectedArtists =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "href",
                Name = "name",
                Published = true,
                Type = Models::SimplifiedArtistObjectType.Artist,
                Uri = "uri",
            },
        ];
        List<string> expectedAvailableMarkets = ["CA", "BR", "IT"];
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        string expectedHref = "href";
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
        string expectedName = "name";
        string expectedReleaseDate = "1981-12";
        ApiEnum<string, ReleaseDatePrecision> expectedReleaseDatePrecision =
            ReleaseDatePrecision.Year;
        long expectedTotalTracks = 9;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"album\"");
        string expectedUri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ";
        bool expectedPublished = true;
        Models::AlbumRestrictionObject expectedRestrictions = new()
        {
            Published = true,
            Reason = Models::Reason.Market,
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAlbumType, model.AlbumType);
        Assert.Equal(expectedArtists.Count, model.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], model.Artists[i]);
        }
        Assert.Equal(expectedAvailableMarkets.Count, model.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], model.AvailableMarkets[i]);
        }
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedImages.Count, model.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], model.Images[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedReleaseDate, model.ReleaseDate);
        Assert.Equal(expectedReleaseDatePrecision, model.ReleaseDatePrecision);
        Assert.Equal(expectedTotalTracks, model.TotalTracks);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedUri, model.Uri);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedRestrictions, model.Restrictions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
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
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Published = true,
            Restrictions = new() { Published = true, Reason = Models::Reason.Market },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
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
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Published = true,
            Restrictions = new() { Published = true, Reason = Models::Reason.Market },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);
        Assert.NotNull(deserialized);

        string expectedID = "2up3OPMp9Tb4dAKM2erWXQ";
        ApiEnum<string, AlbumType> expectedAlbumType = AlbumType.Compilation;
        List<Models::SimplifiedArtistObject> expectedArtists =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                Href = "href",
                Name = "name",
                Published = true,
                Type = Models::SimplifiedArtistObjectType.Artist,
                Uri = "uri",
            },
        ];
        List<string> expectedAvailableMarkets = ["CA", "BR", "IT"];
        Models::ExternalURLObject expectedExternalURLs = new()
        {
            Published = true,
            Spotify = "spotify",
        };
        string expectedHref = "href";
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
        string expectedName = "name";
        string expectedReleaseDate = "1981-12";
        ApiEnum<string, ReleaseDatePrecision> expectedReleaseDatePrecision =
            ReleaseDatePrecision.Year;
        long expectedTotalTracks = 9;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"album\"");
        string expectedUri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ";
        bool expectedPublished = true;
        Models::AlbumRestrictionObject expectedRestrictions = new()
        {
            Published = true,
            Reason = Models::Reason.Market,
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAlbumType, deserialized.AlbumType);
        Assert.Equal(expectedArtists.Count, deserialized.Artists.Count);
        for (int i = 0; i < expectedArtists.Count; i++)
        {
            Assert.Equal(expectedArtists[i], deserialized.Artists[i]);
        }
        Assert.Equal(expectedAvailableMarkets.Count, deserialized.AvailableMarkets.Count);
        for (int i = 0; i < expectedAvailableMarkets.Count; i++)
        {
            Assert.Equal(expectedAvailableMarkets[i], deserialized.AvailableMarkets[i]);
        }
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedImages.Count, deserialized.Images.Count);
        for (int i = 0; i < expectedImages.Count; i++)
        {
            Assert.Equal(expectedImages[i], deserialized.Images[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedReleaseDate, deserialized.ReleaseDate);
        Assert.Equal(expectedReleaseDatePrecision, deserialized.ReleaseDatePrecision);
        Assert.Equal(expectedTotalTracks, deserialized.TotalTracks);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedUri, deserialized.Uri);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedRestrictions, deserialized.Restrictions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
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
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
            Published = true,
            Restrictions = new() { Published = true, Reason = Models::Reason.Market },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
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
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
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
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
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
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",

            // Null should be interpreted as omitted for these properties
            Published = null,
            Restrictions = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Restrictions);
        Assert.False(model.RawData.ContainsKey("restrictions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "2up3OPMp9Tb4dAKM2erWXQ",
            AlbumType = AlbumType.Compilation,
            Artists =
            [
                new()
                {
                    ID = "id",
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
                    Name = "name",
                    Published = true,
                    Type = Models::SimplifiedArtistObjectType.Artist,
                    Uri = "uri",
                },
            ],
            AvailableMarkets = ["CA", "BR", "IT"],
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
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
            Name = "name",
            ReleaseDate = "1981-12",
            ReleaseDatePrecision = ReleaseDatePrecision.Year,
            TotalTracks = 9,
            Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",

            // Null should be interpreted as omitted for these properties
            Published = null,
            Restrictions = null,
        };

        model.Validate();
    }
}

public class AlbumTypeTest : TestBase
{
    [Theory]
    [InlineData(AlbumType.Album)]
    [InlineData(AlbumType.Single)]
    [InlineData(AlbumType.Compilation)]
    public void Validation_Works(AlbumType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlbumType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AlbumType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AlbumType.Album)]
    [InlineData(AlbumType.Single)]
    [InlineData(AlbumType.Compilation)]
    public void SerializationRoundtrip_Works(AlbumType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AlbumType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AlbumType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AlbumType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AlbumType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

public class SearchQueryResponseArtistsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchQueryResponseArtists
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
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Models::Type.Artist,
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
        List<Models::ArtistObject> expectedItems =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                        Published = true,
                    },
                ],
                Name = "name",
                Popularity = 0,
                Published = true,
                Type = Models::Type.Artist,
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
        var model = new SearchQueryResponseArtists
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
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseArtists>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchQueryResponseArtists
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
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Models::Type.Artist,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseArtists>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::ArtistObject> expectedItems =
        [
            new()
            {
                ID = "id",
                ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                        Published = true,
                    },
                ],
                Name = "name",
                Popularity = 0,
                Published = true,
                Type = Models::Type.Artist,
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
        var model = new SearchQueryResponseArtists
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
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
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
                            URL =
                                "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                            Width = 300,
                            Published = true,
                        },
                    ],
                    Name = "name",
                    Popularity = 0,
                    Published = true,
                    Type = Models::Type.Artist,
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
        var model = new SearchQueryResponseArtists
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
        var model = new SearchQueryResponseArtists
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
        var model = new SearchQueryResponseArtists
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
        var model = new SearchQueryResponseArtists
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

public class SearchQueryResponseAudiobooksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchQueryResponseAudiobooks
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
        List<Models::AudiobookBase> expectedItems =
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
        var model = new SearchQueryResponseAudiobooks
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
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseAudiobooks>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchQueryResponseAudiobooks
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
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseAudiobooks>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::AudiobookBase> expectedItems =
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
        var model = new SearchQueryResponseAudiobooks
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
                },
            ],
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchQueryResponseAudiobooks
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
        var model = new SearchQueryResponseAudiobooks
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
        var model = new SearchQueryResponseAudiobooks
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
        var model = new SearchQueryResponseAudiobooks
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

public class SearchQueryResponseEpisodesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchQueryResponseEpisodes
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
                    ReleaseDatePrecision = Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
            ],
            Published = true,
        };

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::SimplifiedEpisodeObject> expectedItems =
        [
            new()
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                        Published = true,
                    },
                ],
                IsExternallyHosted = true,
                IsPlayable = true,
                Languages = ["fr", "en"],
                Name = "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                ReleaseDate = "1981-12-15",
                ReleaseDatePrecision = Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
        var model = new SearchQueryResponseEpisodes
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
                    ReleaseDatePrecision = Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseEpisodes>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchQueryResponseEpisodes
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
                    ReleaseDatePrecision = Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseEpisodes>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::SimplifiedEpisodeObject> expectedItems =
        [
            new()
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
                        Width = 300,
                        Published = true,
                    },
                ],
                IsExternallyHosted = true,
                IsPlayable = true,
                Languages = ["fr", "en"],
                Name = "Starting Your Own Podcast: Tips, Tricks, and Advice From Anchor Creators\n",
                ReleaseDate = "1981-12-15",
                ReleaseDatePrecision = Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
        var model = new SearchQueryResponseEpisodes
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
                    ReleaseDatePrecision = Models::SimplifiedEpisodeObjectReleaseDatePrecision.Day,
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
            ],
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchQueryResponseEpisodes
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
        var model = new SearchQueryResponseEpisodes
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
        var model = new SearchQueryResponseEpisodes
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
        var model = new SearchQueryResponseEpisodes
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

public class SearchQueryResponseShowsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchQueryResponseShows
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
            ],
            Published = true,
        };

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::ShowBase> expectedItems =
        [
            new()
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        var model = new SearchQueryResponseShows
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
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseShows>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchQueryResponseShows
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
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseShows>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::ShowBase> expectedItems =
        [
            new()
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
                        URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        var model = new SearchQueryResponseShows
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
            ],
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SearchQueryResponseShows
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
        var model = new SearchQueryResponseShows
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
        var model = new SearchQueryResponseShows
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
        var model = new SearchQueryResponseShows
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

public class SearchQueryResponseTracksTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SearchQueryResponseTracks
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
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = Models::AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
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
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = Models::TrackObjectType.Track,
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
        List<Models::TrackObject> expectedItems =
        [
            new()
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
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                },
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Published = true,
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
                    Published = true,
                    Upc = "upc",
                },
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
                Popularity = 0,
                PreviewURL = "preview_url",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                TrackNumber = 0,
                Type = Models::TrackObjectType.Track,
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
        var model = new SearchQueryResponseTracks
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
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = Models::AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
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
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = Models::TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseTracks>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SearchQueryResponseTracks
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
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = Models::AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
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
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = Models::TrackObjectType.Track,
                    Uri = "uri",
                },
            ],
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SearchQueryResponseTracks>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "https://api.spotify.com/v1/me/shows?offset=0&limit=20\n";
        long expectedLimit = 20;
        string expectedNext = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedOffset = 0;
        string expectedPrevious = "https://api.spotify.com/v1/me/shows?offset=1&limit=1";
        long expectedTotal = 4;
        List<Models::TrackObject> expectedItems =
        [
            new()
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
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
                            Type = Models::SimplifiedArtistObjectType.Artist,
                            Uri = "uri",
                        },
                    ],
                    AvailableMarkets = ["CA", "BR", "IT"],
                    ExternalURLs = new() { Published = true, Spotify = "spotify" },
                    Href = "href",
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
                    Name = "name",
                    ReleaseDate = "1981-12",
                    ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                    TotalTracks = 9,
                    Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                },
                Artists =
                [
                    new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
                        Name = "name",
                        Published = true,
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
                    Published = true,
                    Upc = "upc",
                },
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
                Popularity = 0,
                PreviewURL = "preview_url",
                Published = true,
                Restrictions = new() { Published = true, Reason = "reason" },
                TrackNumber = 0,
                Type = Models::TrackObjectType.Track,
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
        var model = new SearchQueryResponseTracks
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
                    Album = new()
                    {
                        ID = "2up3OPMp9Tb4dAKM2erWXQ",
                        AlbumType = Models::AlbumType.Compilation,
                        Artists =
                        [
                            new()
                            {
                                ID = "id",
                                ExternalURLs = new() { Published = true, Spotify = "spotify" },
                                Href = "href",
                                Name = "name",
                                Published = true,
                                Type = Models::SimplifiedArtistObjectType.Artist,
                                Uri = "uri",
                            },
                        ],
                        AvailableMarkets = ["CA", "BR", "IT"],
                        ExternalURLs = new() { Published = true, Spotify = "spotify" },
                        Href = "href",
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
                        Name = "name",
                        ReleaseDate = "1981-12",
                        ReleaseDatePrecision = Models::AlbumReleaseDatePrecision.Year,
                        TotalTracks = 9,
                        Uri = "spotify:album:2up3OPMp9Tb4dAKM2erWXQ",
                        Published = true,
                        Restrictions = new() { Published = true, Reason = Models::Reason.Market },
                    },
                    Artists =
                    [
                        new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Published = true, Spotify = "spotify" },
                            Href = "href",
                            Name = "name",
                            Published = true,
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
                        Published = true,
                        Upc = "upc",
                    },
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
                    Popularity = 0,
                    PreviewURL = "preview_url",
                    Published = true,
                    Restrictions = new() { Published = true, Reason = "reason" },
                    TrackNumber = 0,
                    Type = Models::TrackObjectType.Track,
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
        var model = new SearchQueryResponseTracks
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
        var model = new SearchQueryResponseTracks
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
        var model = new SearchQueryResponseTracks
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
        var model = new SearchQueryResponseTracks
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
