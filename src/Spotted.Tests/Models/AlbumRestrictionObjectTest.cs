using System.Text.Json;
using Spotted.Core;
using Spotted.Models;

namespace Spotted.Tests.Models;

public class AlbumRestrictionObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AlbumRestrictionObject { Reason = Reason.Market };

        ApiEnum<string, Reason> expectedReason = Reason.Market;

        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AlbumRestrictionObject { Reason = Reason.Market };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumRestrictionObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AlbumRestrictionObject { Reason = Reason.Market };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AlbumRestrictionObject>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, Reason> expectedReason = Reason.Market;

        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AlbumRestrictionObject { Reason = Reason.Market };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AlbumRestrictionObject { };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AlbumRestrictionObject { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AlbumRestrictionObject
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AlbumRestrictionObject
        {
            // Null should be interpreted as omitted for these properties
            Reason = null,
        };

        model.Validate();
    }
}
