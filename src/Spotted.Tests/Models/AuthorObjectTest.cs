using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class AuthorObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthorObject { Name = "name" };

        string expectedName = "name";

        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuthorObject { Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AuthorObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuthorObject { Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AuthorObject>(json);
        Assert.NotNull(deserialized);

        string expectedName = "name";

        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuthorObject { Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AuthorObject { };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AuthorObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AuthorObject
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AuthorObject
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        model.Validate();
    }
}
