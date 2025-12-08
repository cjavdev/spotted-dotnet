using System.Text.Json;
using Spotted.Models.Playlists.Tracks;

namespace Spotted.Tests.Models.Playlists.Tracks;

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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Track>(json);
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
