using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class EpisodeRestrictionObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EpisodeRestrictionObject { Published = true, Reason = "reason" };

        bool expectedPublished = true;
        string expectedReason = "reason";

        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EpisodeRestrictionObject { Published = true, Reason = "reason" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EpisodeRestrictionObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EpisodeRestrictionObject { Published = true, Reason = "reason" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EpisodeRestrictionObject>(element);
        Assert.NotNull(deserialized);

        bool expectedPublished = true;
        string expectedReason = "reason";

        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EpisodeRestrictionObject { Published = true, Reason = "reason" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EpisodeRestrictionObject { };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
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
            Published = null,
            Reason = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EpisodeRestrictionObject
        {
            // Null should be interpreted as omitted for these properties
            Published = null,
            Reason = null,
        };

        model.Validate();
    }
}
