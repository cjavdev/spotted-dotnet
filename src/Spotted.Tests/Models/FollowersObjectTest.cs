using System.Text.Json;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class FollowersObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FollowersObject
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
        var model = new FollowersObject
        {
            Href = "href",
            Published = true,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FollowersObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FollowersObject
        {
            Href = "href",
            Published = true,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<FollowersObject>(json);
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
        var model = new FollowersObject
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
        var model = new FollowersObject { Href = "href" };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FollowersObject { Href = "href" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FollowersObject
        {
            Href = "href",

            // Null should be interpreted as omitted for these properties
            Published = null,
            Total = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FollowersObject
        {
            Href = "href",

            // Null should be interpreted as omitted for these properties
            Published = null,
            Total = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FollowersObject { Published = true, Total = 0 };

        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new FollowersObject { Published = true, Total = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new FollowersObject
        {
            Published = true,
            Total = 0,

            Href = null,
        };

        Assert.Null(model.Href);
        Assert.True(model.RawData.ContainsKey("href"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FollowersObject
        {
            Published = true,
            Total = 0,

            Href = null,
        };

        model.Validate();
    }
}
