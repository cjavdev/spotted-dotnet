using System.Text.Json;
using Spotted.Models.Playlists.Tracks;

namespace Spotted.Tests.Models.Playlists.Tracks;

public class TrackUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrackUpdateResponse { SnapshotID = "abc" };

        string expectedSnapshotID = "abc";

        Assert.Equal(expectedSnapshotID, model.SnapshotID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TrackUpdateResponse { SnapshotID = "abc" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrackUpdateResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrackUpdateResponse { SnapshotID = "abc" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TrackUpdateResponse>(json);
        Assert.NotNull(deserialized);

        string expectedSnapshotID = "abc";

        Assert.Equal(expectedSnapshotID, deserialized.SnapshotID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TrackUpdateResponse { SnapshotID = "abc" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TrackUpdateResponse { };

        Assert.Null(model.SnapshotID);
        Assert.False(model.RawData.ContainsKey("snapshot_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TrackUpdateResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TrackUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            SnapshotID = null,
        };

        Assert.Null(model.SnapshotID);
        Assert.False(model.RawData.ContainsKey("snapshot_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TrackUpdateResponse
        {
            // Null should be interpreted as omitted for these properties
            SnapshotID = null,
        };

        model.Validate();
    }
}
