using System.Text.Json;
using Spotted.Models;
using Spotted.Models.Browse.Categories;

namespace Spotted.Tests.Models.Browse.Categories;

public class CategoryGetPlaylistsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CategoryGetPlaylistsResponse
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
                        Owner = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = PlaylistUserObjectType.User,
                            Uri = "uri",
                            DisplayName = "display_name",
                        },
                        Public = true,
                        SnapshotID = "snapshot_id",
                        Tracks = new() { Href = "href", Total = 0 },
                        Type = "type",
                        Uri = "uri",
                    },
                ],
            },
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
                    Owner = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = PlaylistUserObjectType.User,
                        Uri = "uri",
                        DisplayName = "display_name",
                    },
                    Public = true,
                    SnapshotID = "snapshot_id",
                    Tracks = new() { Href = "href", Total = 0 },
                    Type = "type",
                    Uri = "uri",
                },
            ],
        };

        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedPlaylists, model.Playlists);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CategoryGetPlaylistsResponse
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
                        Owner = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = PlaylistUserObjectType.User,
                            Uri = "uri",
                            DisplayName = "display_name",
                        },
                        Public = true,
                        SnapshotID = "snapshot_id",
                        Tracks = new() { Href = "href", Total = 0 },
                        Type = "type",
                        Uri = "uri",
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CategoryGetPlaylistsResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CategoryGetPlaylistsResponse
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
                        Owner = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = PlaylistUserObjectType.User,
                            Uri = "uri",
                            DisplayName = "display_name",
                        },
                        Public = true,
                        SnapshotID = "snapshot_id",
                        Tracks = new() { Href = "href", Total = 0 },
                        Type = "type",
                        Uri = "uri",
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CategoryGetPlaylistsResponse>(json);
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
                    Owner = new()
                    {
                        ID = "id",
                        ExternalURLs = new() { Spotify = "spotify" },
                        Href = "href",
                        Type = PlaylistUserObjectType.User,
                        Uri = "uri",
                        DisplayName = "display_name",
                    },
                    Public = true,
                    SnapshotID = "snapshot_id",
                    Tracks = new() { Href = "href", Total = 0 },
                    Type = "type",
                    Uri = "uri",
                },
            ],
        };

        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.Equal(expectedPlaylists, deserialized.Playlists);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CategoryGetPlaylistsResponse
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
                        Owner = new()
                        {
                            ID = "id",
                            ExternalURLs = new() { Spotify = "spotify" },
                            Href = "href",
                            Type = PlaylistUserObjectType.User,
                            Uri = "uri",
                            DisplayName = "display_name",
                        },
                        Public = true,
                        SnapshotID = "snapshot_id",
                        Tracks = new() { Href = "href", Total = 0 },
                        Type = "type",
                        Uri = "uri",
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CategoryGetPlaylistsResponse { };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Playlists);
        Assert.False(model.RawData.ContainsKey("playlists"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CategoryGetPlaylistsResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CategoryGetPlaylistsResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Playlists = null,
        };

        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Playlists);
        Assert.False(model.RawData.ContainsKey("playlists"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CategoryGetPlaylistsResponse
        {
            // Null should be interpreted as omitted for these properties
            Message = null,
            Playlists = null,
        };

        model.Validate();
    }
}
