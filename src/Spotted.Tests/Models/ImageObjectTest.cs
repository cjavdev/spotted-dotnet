using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class ImageObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,
            Published = true,
        };

        long expectedHeight = 300;
        string expectedURL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n";
        long expectedWidth = 300;
        bool expectedPublished = true;

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedPublished, model.Published);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,
            Published = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ImageObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,
            Published = true,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ImageObject>(element);
        Assert.NotNull(deserialized);

        long expectedHeight = 300;
        string expectedURL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n";
        long expectedWidth = 300;
        bool expectedPublished = true;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedPublished, deserialized.Published);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        model.Validate();
    }
}
