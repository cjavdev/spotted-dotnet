using System.Collections.Generic;
using System.Text.Json;
using Spotted.Core;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class SimplifiedPlaylistObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SimplifiedPlaylistObject
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        };

        string expectedID = "id";
        bool expectedCollaborative = true;
        string expectedDescription = "description";
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        List<ImageObject> expectedImages =
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
        Owner expectedOwner = new()
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };
        bool expectedPublished = true;
        string expectedSnapshotID = "snapshot_id";
        PlaylistTracksRefObject expectedTracks = new()
        {
            Href = "href",
            Published = true,
            Total = 0,
        };
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCollaborative, model.Collaborative);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.NotNull(model.Images);
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
        var model = new SimplifiedPlaylistObject
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SimplifiedPlaylistObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SimplifiedPlaylistObject
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SimplifiedPlaylistObject>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedCollaborative = true;
        string expectedDescription = "description";
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        List<ImageObject> expectedImages =
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
        Owner expectedOwner = new()
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };
        bool expectedPublished = true;
        string expectedSnapshotID = "snapshot_id";
        PlaylistTracksRefObject expectedTracks = new()
        {
            Href = "href",
            Published = true,
            Total = 0,
        };
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCollaborative, deserialized.Collaborative);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.NotNull(deserialized.Images);
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
        var model = new SimplifiedPlaylistObject
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
                    URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SimplifiedPlaylistObject { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Collaborative);
        Assert.False(model.RawData.ContainsKey("collaborative"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
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
        var model = new SimplifiedPlaylistObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SimplifiedPlaylistObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Collaborative = null,
            Description = null,
            ExternalURLs = null,
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
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
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
        var model = new SimplifiedPlaylistObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            Collaborative = null,
            Description = null,
            ExternalURLs = null,
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
}

public class OwnerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Owner
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };

        string expectedID = "id";
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        bool expectedPublished = true;
        ApiEnum<string, PlaylistUserObjectType> expectedType = PlaylistUserObjectType.User;
        string expectedUri = "uri";
        string expectedDisplayName = "display_name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedPublished, model.Published);
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
            Uri = "uri",
            DisplayName = "display_name",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Owner>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        bool expectedPublished = true;
        ApiEnum<string, PlaylistUserObjectType> expectedType = PlaylistUserObjectType.User;
        string expectedUri = "uri";
        string expectedDisplayName = "display_name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedPublished, deserialized.Published);
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
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
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
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
            Published = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
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
            Published = null,
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
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
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = PlaylistUserObjectType.User,
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
