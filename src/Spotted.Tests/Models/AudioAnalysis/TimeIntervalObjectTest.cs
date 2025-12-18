using System.Text.Json;
using Spotted.Models.AudioAnalysis;

namespace Spotted.Tests.Models.AudioAnalysis;

public class TimeIntervalObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TimeIntervalObject
        {
            Confidence = 0.925,
            Duration = 2.18749,
            Published = true,
            Start = 0.49567,
        };

        double expectedConfidence = 0.925;
        double expectedDuration = 2.18749;
        bool expectedPublished = true;
        double expectedStart = 0.49567;

        Assert.Equal(expectedConfidence, model.Confidence);
        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TimeIntervalObject
        {
            Confidence = 0.925,
            Duration = 2.18749,
            Published = true,
            Start = 0.49567,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TimeIntervalObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TimeIntervalObject
        {
            Confidence = 0.925,
            Duration = 2.18749,
            Published = true,
            Start = 0.49567,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TimeIntervalObject>(element);
        Assert.NotNull(deserialized);

        double expectedConfidence = 0.925;
        double expectedDuration = 2.18749;
        bool expectedPublished = true;
        double expectedStart = 0.49567;

        Assert.Equal(expectedConfidence, deserialized.Confidence);
        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TimeIntervalObject
        {
            Confidence = 0.925,
            Duration = 2.18749,
            Published = true,
            Start = 0.49567,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TimeIntervalObject { };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TimeIntervalObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TimeIntervalObject
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Duration = null,
            Published = null,
            Start = null,
        };

        Assert.Null(model.Confidence);
        Assert.False(model.RawData.ContainsKey("confidence"));
        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TimeIntervalObject
        {
            // Null should be interpreted as omitted for these properties
            Confidence = null,
            Duration = null,
            Published = null,
            Start = null,
        };

        model.Validate();
    }
}
