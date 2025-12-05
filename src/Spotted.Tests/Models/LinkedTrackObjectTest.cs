using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class LinkedTrackObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LinkedTrackObject
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = "type",
            Uri = "uri",
        };

        string expectedID = "id";
        ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        string expectedHref = "href";
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LinkedTrackObject
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = "type",
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LinkedTrackObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LinkedTrackObject
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = "type",
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LinkedTrackObject>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ExternalURLObject expectedExternalURLs = new() { Spotify = "spotify" };
        string expectedHref = "href";
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LinkedTrackObject
        {
            ID = "id",
            ExternalURLs = new() { Spotify = "spotify" },
            Href = "href",
            Type = "type",
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LinkedTrackObject { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new LinkedTrackObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new LinkedTrackObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Href = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LinkedTrackObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Href = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }
}
