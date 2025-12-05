using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class ExternalURLObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalURLObject { Spotify = "spotify" };

        string expectedSpotify = "spotify";

        Assert.Equal(expectedSpotify, model.Spotify);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalURLObject { Spotify = "spotify" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExternalURLObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalURLObject { Spotify = "spotify" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExternalURLObject>(json);
        Assert.NotNull(deserialized);

        string expectedSpotify = "spotify";

        Assert.Equal(expectedSpotify, deserialized.Spotify);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalURLObject { Spotify = "spotify" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExternalURLObject { };

        Assert.Null(model.Spotify);
        Assert.False(model.RawData.ContainsKey("spotify"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExternalURLObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExternalURLObject
        {
            // Null should be interpreted as omitted for these properties
            Spotify = null,
        };

        Assert.Null(model.Spotify);
        Assert.False(model.RawData.ContainsKey("spotify"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExternalURLObject
        {
            // Null should be interpreted as omitted for these properties
            Spotify = null,
        };

        model.Validate();
    }
}
