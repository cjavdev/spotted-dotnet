using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class ResumePointObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ResumePointObject
        {
            FullyPlayed = true,
            Published = true,
            ResumePositionMs = 0,
        };

        bool expectedFullyPlayed = true;
        bool expectedPublished = true;
        long expectedResumePositionMs = 0;

        Assert.Equal(expectedFullyPlayed, model.FullyPlayed);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedResumePositionMs, model.ResumePositionMs);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ResumePointObject
        {
            FullyPlayed = true,
            Published = true,
            ResumePositionMs = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ResumePointObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ResumePointObject
        {
            FullyPlayed = true,
            Published = true,
            ResumePositionMs = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ResumePointObject>(json);
        Assert.NotNull(deserialized);

        bool expectedFullyPlayed = true;
        bool expectedPublished = true;
        long expectedResumePositionMs = 0;

        Assert.Equal(expectedFullyPlayed, deserialized.FullyPlayed);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedResumePositionMs, deserialized.ResumePositionMs);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ResumePointObject
        {
            FullyPlayed = true,
            Published = true,
            ResumePositionMs = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ResumePointObject { };

        Assert.Null(model.FullyPlayed);
        Assert.False(model.RawData.ContainsKey("fully_played"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.ResumePositionMs);
        Assert.False(model.RawData.ContainsKey("resume_position_ms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ResumePointObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ResumePointObject
        {
            // Null should be interpreted as omitted for these properties
            FullyPlayed = null,
            Published = null,
            ResumePositionMs = null,
        };

        Assert.Null(model.FullyPlayed);
        Assert.False(model.RawData.ContainsKey("fully_played"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.ResumePositionMs);
        Assert.False(model.RawData.ContainsKey("resume_position_ms"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ResumePointObject
        {
            // Null should be interpreted as omitted for these properties
            FullyPlayed = null,
            Published = null,
            ResumePositionMs = null,
        };

        model.Validate();
    }
}
