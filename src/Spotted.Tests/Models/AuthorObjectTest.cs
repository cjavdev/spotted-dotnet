using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class AuthorObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AuthorObject { Name = "name", Published = true };

        string expectedName = "name";
        bool expectedPublished = true;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPublished, model.Published);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AuthorObject { Name = "name", Published = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AuthorObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AuthorObject { Name = "name", Published = true };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AuthorObject>(element);
        Assert.NotNull(deserialized);

        string expectedName = "name";
        bool expectedPublished = true;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPublished, deserialized.Published);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AuthorObject { Name = "name", Published = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AuthorObject { };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
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
            Published = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AuthorObject
        {
            // Null should be interpreted as omitted for these properties
            Name = null,
            Published = null,
        };

        model.Validate();
    }
}
