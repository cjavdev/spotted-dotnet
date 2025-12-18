using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class CopyrightObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CopyrightObject
        {
            Published = true,
            Text = "text",
            Type = "type",
        };

        bool expectedPublished = true;
        string expectedText = "text";
        string expectedType = "type";

        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CopyrightObject
        {
            Published = true,
            Text = "text",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CopyrightObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CopyrightObject
        {
            Published = true,
            Text = "text",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CopyrightObject>(element);
        Assert.NotNull(deserialized);

        bool expectedPublished = true;
        string expectedText = "text";
        string expectedType = "type";

        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CopyrightObject
        {
            Published = true,
            Text = "text",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CopyrightObject { };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CopyrightObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CopyrightObject
        {
            // Null should be interpreted as omitted for these properties
            Published = null,
            Text = null,
            Type = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Text);
        Assert.False(model.RawData.ContainsKey("text"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CopyrightObject
        {
            // Null should be interpreted as omitted for these properties
            Published = null,
            Text = null,
            Type = null,
        };

        model.Validate();
    }
}
