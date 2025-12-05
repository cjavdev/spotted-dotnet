using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class CopyrightObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CopyrightObject { Text = "text", Type = "type" };

        string expectedText = "text";
        string expectedType = "type";

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CopyrightObject { Text = "text", Type = "type" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CopyrightObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CopyrightObject { Text = "text", Type = "type" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CopyrightObject>(json);
        Assert.NotNull(deserialized);

        string expectedText = "text";
        string expectedType = "type";

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CopyrightObject { Text = "text", Type = "type" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CopyrightObject { };

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
            Text = null,
            Type = null,
        };

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
            Text = null,
            Type = null,
        };

        model.Validate();
    }
}
