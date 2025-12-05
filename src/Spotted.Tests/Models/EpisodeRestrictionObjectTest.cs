using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class EpisodeRestrictionObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EpisodeRestrictionObject { Reason = "reason" };

        string expectedReason = "reason";

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EpisodeRestrictionObject { Reason = "reason" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EpisodeRestrictionObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EpisodeRestrictionObject { Reason = "reason" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EpisodeRestrictionObject>(json);
        Assert.NotNull(deserialized);

        string expectedReason = "reason";

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EpisodeRestrictionObject { Reason = "reason" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EpisodeRestrictionObject { };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EpisodeRestrictionObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EpisodeRestrictionObject
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EpisodeRestrictionObject
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }
}
