using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class PlaylistTracksRefObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlaylistTracksRefObject
        {
            Href = "href",
            Published = true,
            Total = 0,
        };

        string expectedHref = "href";
        bool expectedPublished = true;
        long expectedTotal = 0;

        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlaylistTracksRefObject
        {
            Href = "href",
            Published = true,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlaylistTracksRefObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlaylistTracksRefObject
        {
            Href = "href",
            Published = true,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlaylistTracksRefObject>(json);
        Assert.NotNull(deserialized);

        string expectedHref = "href";
        bool expectedPublished = true;
        long expectedTotal = 0;

        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlaylistTracksRefObject
        {
            Href = "href",
            Published = true,
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlaylistTracksRefObject { };

        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlaylistTracksRefObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PlaylistTracksRefObject
        {
            // Null should be interpreted as omitted for these properties
            Href = null,
            Published = null,
            Total = null,
        };

        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PlaylistTracksRefObject
        {
            // Null should be interpreted as omitted for these properties
            Href = null,
            Published = null,
            Total = null,
        };

        model.Validate();
    }
}
