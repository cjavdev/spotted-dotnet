using System.Text.Json;
using Spotted.Core;
using Spotted.Models;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class ContextObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContextObject
        {
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = "type",
            Uri = "uri",
        };

        ExternalUrlObject expectedExternalUrls = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        bool expectedPublished = true;
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedExternalUrls, model.ExternalUrls);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContextObject
        {
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = "type",
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContextObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContextObject
        {
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = "type",
            Uri = "uri",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContextObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ExternalUrlObject expectedExternalUrls = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        bool expectedPublished = true;
        string expectedType = "type";
        string expectedUri = "uri";

        Assert.Equal(expectedExternalUrls, deserialized.ExternalUrls);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContextObject
        {
            ExternalUrls = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Published = true,
            Type = "type",
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContextObject { };

        Assert.Null(model.ExternalUrls);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ContextObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ContextObject
        {
            // Null should be interpreted as omitted for these properties
            ExternalUrls = null,
            Href = null,
            Published = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ExternalUrls);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Uri);
        Assert.False(model.RawData.ContainsKey("uri"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ContextObject
        {
            // Null should be interpreted as omitted for these properties
            ExternalUrls = null,
            Href = null,
            Published = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }
}
