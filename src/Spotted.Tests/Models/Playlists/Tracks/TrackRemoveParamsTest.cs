using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Playlists.Tracks;

namespace Spotted.Tests.Models.Playlists.Tracks;

public class TrackRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrackRemoveParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Tracks = [new() { Uri = "uri" }],
            Published = true,
            SnapshotID = "snapshot_id",
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        List<Track> expectedTracks = [new() { Uri = "uri" }];
        bool expectedPublished = true;
        string expectedSnapshotID = "snapshot_id";

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedTracks.Count, parameters.Tracks.Count);
        for (int i = 0; i < expectedTracks.Count; i++)
        {
            Assert.Equal(expectedTracks[i], parameters.Tracks[i]);
        }
        Assert.Equal(expectedPublished, parameters.Published);
        Assert.Equal(expectedSnapshotID, parameters.SnapshotID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TrackRemoveParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Tracks = [new() { Uri = "uri" }],
        };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.SnapshotID);
        Assert.False(parameters.RawBodyData.ContainsKey("snapshot_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TrackRemoveParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Tracks = [new() { Uri = "uri" }],

            // Null should be interpreted as omitted for these properties
            Published = null,
            SnapshotID = null,
        };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.SnapshotID);
        Assert.False(parameters.RawBodyData.ContainsKey("snapshot_id"));
    }
}

public class TrackTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Track { Uri = "uri" };

        string expectedUri = "uri";

        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Track { Uri = "uri" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Track>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Track { Uri = "uri" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Track>(element);
        Assert.NotNull(deserialized);

        string expectedUri = "uri";

        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Track { Uri = "uri" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Track { };

        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Track { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Track
        {
            // Null should be interpreted as omitted for these properties
            Uri = null,
        };

        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Track
        {
            // Null should be interpreted as omitted for these properties
            Uri = null,
        };

        model.Validate();
    }
}
