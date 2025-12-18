using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Browse;

namespace Spotted.Tests.Models.Browse;

public class BrowseGetFeaturedPlaylistsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowseGetFeaturedPlaylistsResponse
        {
            Message = "Popular Playlists",
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
                            Type = PlaylistUserObjectType.User,
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
            Published = true,
        };

        string expectedMessage = "Popular Playlists";
        PagingPlaylistObject expectedPlaylists = new()
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
                        Type = PlaylistUserObjectType.User,
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
        bool expectedPublished = true;

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedPlaylists, model.Playlists);
        Assert.Equal(expectedPublished, model.Published);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowseGetFeaturedPlaylistsResponse
        {
            Message = "Popular Playlists",
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
                            Type = PlaylistUserObjectType.User,
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
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowseGetFeaturedPlaylistsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowseGetFeaturedPlaylistsResponse
        {
            Message = "Popular Playlists",
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
                            Type = PlaylistUserObjectType.User,
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
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BrowseGetFeaturedPlaylistsResponse>(element);
        Assert.NotNull(deserialized);

        string expectedMessage = "Popular Playlists";
        PagingPlaylistObject expectedPlaylists = new()
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
                        Type = PlaylistUserObjectType.User,
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
        bool expectedPublished = true;

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedPlaylists, deserialized.Playlists);
        Assert.Equal(expectedPublished, deserialized.Published);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowseGetFeaturedPlaylistsResponse
        {
            Message = "Popular Playlists",
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
                            Type = PlaylistUserObjectType.User,
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
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowseGetFeaturedPlaylistsResponse { };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Playlists);
        Assert.False(model.RawData.ContainsKey("playlists"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowseGetFeaturedPlaylistsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrowseGetFeaturedPlaylistsResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Playlists = null,
            Published = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Playlists);
        Assert.False(model.RawData.ContainsKey("playlists"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowseGetFeaturedPlaylistsResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Playlists = null,
            Published = null,
        };

        model.Validate();
    }
}
