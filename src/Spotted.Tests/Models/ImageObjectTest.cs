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
        };

        long expectedHeight = 300;
        string expectedURL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n";
        long expectedWidth = 300;

        Assert.Equal(expectedHeight, model.Height);
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedWidth, model.Width);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ImageObject>(json);
        Assert.NotNull(deserialized);

        long expectedHeight = 300;
        string expectedURL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n";
        long expectedWidth = 300;

        Assert.Equal(expectedHeight, deserialized.Height);
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedWidth, deserialized.Width);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImageObject
        {
            Height = 300,
            URL = "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228\n",
            Width = 300,
        };

        model.Validate();
    }
}
