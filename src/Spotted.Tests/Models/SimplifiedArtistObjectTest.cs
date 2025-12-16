using System.Text.Json;
using Spotted.Core;
using Spotted.Exceptions;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class SimplifiedArtistObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SimplifiedArtistObject
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Name = "name",
            Published = true,
            Type = SimplifiedArtistObjectType.Artist,
            Uri = "uri",
        };

        string expectedID = "id";
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        string expectedName = "name";
        bool expectedPublished = true;
        ApiEnum<string, SimplifiedArtistObjectType> expectedType =
            SimplifiedArtistObjectType.Artist;
        string expectedUri = "uri";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedExternalURLs, model.ExternalURLs);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUri, model.Uri);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SimplifiedArtistObject
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Name = "name",
            Published = true,
            Type = SimplifiedArtistObjectType.Artist,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SimplifiedArtistObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SimplifiedArtistObject
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Name = "name",
            Published = true,
            Type = SimplifiedArtistObjectType.Artist,
            Uri = "uri",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SimplifiedArtistObject>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ExternalURLObject expectedExternalURLs = new() { Published = true, Spotify = "spotify" };
        string expectedHref = "href";
        string expectedName = "name";
        bool expectedPublished = true;
        ApiEnum<string, SimplifiedArtistObjectType> expectedType =
            SimplifiedArtistObjectType.Artist;
        string expectedUri = "uri";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedExternalURLs, deserialized.ExternalURLs);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUri, deserialized.Uri);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SimplifiedArtistObject
        {
            ID = "id",
            ExternalURLs = new() { Published = true, Spotify = "spotify" },
            Href = "href",
            Name = "name",
            Published = true,
            Type = SimplifiedArtistObjectType.Artist,
            Uri = "uri",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SimplifiedArtistObject { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
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
        var model = new SimplifiedArtistObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SimplifiedArtistObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Href = null,
            Name = null,
            Published = null,
            Type = null,
            Uri = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.ExternalURLs);
        Assert.False(model.RawData.ContainsKey("external_urls"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
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
        var model = new SimplifiedArtistObject
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            ExternalURLs = null,
            Href = null,
            Name = null,
            Published = null,
            Type = null,
            Uri = null,
        };

        model.Validate();
    }
}

public class SimplifiedArtistObjectTypeTest : TestBase
{
    [Theory]
    [InlineData(SimplifiedArtistObjectType.Artist)]
    public void Validation_Works(SimplifiedArtistObjectType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SimplifiedArtistObjectType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SimplifiedArtistObjectType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<SpottedInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SimplifiedArtistObjectType.Artist)]
    public void SerializationRoundtrip_Works(SimplifiedArtistObjectType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SimplifiedArtistObjectType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SimplifiedArtistObjectType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SimplifiedArtistObjectType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SimplifiedArtistObjectType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
