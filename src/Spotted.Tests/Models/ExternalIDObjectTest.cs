using System.Text.Json;
using Spotted.Core;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class ExternalIDObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalIDObject
        {
            Ean = "ean",
            Isrc = "isrc",
            Published = true,
            Upc = "upc",
        };

        string expectedEan = "ean";
        string expectedIsrc = "isrc";
        bool expectedPublished = true;
        string expectedUpc = "upc";

        Assert.Equal(expectedEan, model.Ean);
        Assert.Equal(expectedIsrc, model.Isrc);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedUpc, model.Upc);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalIDObject
        {
            Ean = "ean",
            Isrc = "isrc",
            Published = true,
            Upc = "upc",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalIDObject>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalIDObject
        {
            Ean = "ean",
            Isrc = "isrc",
            Published = true,
            Upc = "upc",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ExternalIDObject>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEan = "ean";
        string expectedIsrc = "isrc";
        bool expectedPublished = true;
        string expectedUpc = "upc";

        Assert.Equal(expectedEan, deserialized.Ean);
        Assert.Equal(expectedIsrc, deserialized.Isrc);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedUpc, deserialized.Upc);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalIDObject
        {
            Ean = "ean",
            Isrc = "isrc",
            Published = true,
            Upc = "upc",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ExternalIDObject { };

        Assert.Null(model.Ean);
        Assert.False(model.RawData.ContainsKey("ean"));
        Assert.Null(model.Isrc);
        Assert.False(model.RawData.ContainsKey("isrc"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Upc);
        Assert.False(model.RawData.ContainsKey("upc"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ExternalIDObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ExternalIDObject
        {
            // Null should be interpreted as omitted for these properties
            Ean = null,
            Isrc = null,
            Published = null,
            Upc = null,
        };

        Assert.Null(model.Ean);
        Assert.False(model.RawData.ContainsKey("ean"));
        Assert.Null(model.Isrc);
        Assert.False(model.RawData.ContainsKey("isrc"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Upc);
        Assert.False(model.RawData.ContainsKey("upc"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ExternalIDObject
        {
            // Null should be interpreted as omitted for these properties
            Ean = null,
            Isrc = null,
            Published = null,
            Upc = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ExternalIDObject
        {
            Ean = "ean",
            Isrc = "isrc",
            Published = true,
            Upc = "upc",
        };

        ExternalIDObject copied = new(model);

        Assert.Equal(model, copied);
    }
}
