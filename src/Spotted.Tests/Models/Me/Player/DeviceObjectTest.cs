using System.Text.Json;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class DeviceObjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeviceObject
        {
            ID = "id",
            IsActive = true,
            IsPrivateSession = true,
            IsRestricted = true,
            Name = "Kitchen speaker",
            Published = true,
            SupportsVolume = true,
            Type = "computer",
            VolumePercent = 59,
        };

        string expectedID = "id";
        bool expectedIsActive = true;
        bool expectedIsPrivateSession = true;
        bool expectedIsRestricted = true;
        string expectedName = "Kitchen speaker";
        bool expectedPublished = true;
        bool expectedSupportsVolume = true;
        string expectedType = "computer";
        long expectedVolumePercent = 59;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIsActive, model.IsActive);
        Assert.Equal(expectedIsPrivateSession, model.IsPrivateSession);
        Assert.Equal(expectedIsRestricted, model.IsRestricted);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPublished, model.Published);
        Assert.Equal(expectedSupportsVolume, model.SupportsVolume);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVolumePercent, model.VolumePercent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeviceObject
        {
            ID = "id",
            IsActive = true,
            IsPrivateSession = true,
            IsRestricted = true,
            Name = "Kitchen speaker",
            Published = true,
            SupportsVolume = true,
            Type = "computer",
            VolumePercent = 59,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DeviceObject>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeviceObject
        {
            ID = "id",
            IsActive = true,
            IsPrivateSession = true,
            IsRestricted = true,
            Name = "Kitchen speaker",
            Published = true,
            SupportsVolume = true,
            Type = "computer",
            VolumePercent = 59,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<DeviceObject>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedIsActive = true;
        bool expectedIsPrivateSession = true;
        bool expectedIsRestricted = true;
        string expectedName = "Kitchen speaker";
        bool expectedPublished = true;
        bool expectedSupportsVolume = true;
        string expectedType = "computer";
        long expectedVolumePercent = 59;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIsActive, deserialized.IsActive);
        Assert.Equal(expectedIsPrivateSession, deserialized.IsPrivateSession);
        Assert.Equal(expectedIsRestricted, deserialized.IsRestricted);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPublished, deserialized.Published);
        Assert.Equal(expectedSupportsVolume, deserialized.SupportsVolume);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVolumePercent, deserialized.VolumePercent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeviceObject
        {
            ID = "id",
            IsActive = true,
            IsPrivateSession = true,
            IsRestricted = true,
            Name = "Kitchen speaker",
            Published = true,
            SupportsVolume = true,
            Type = "computer",
            VolumePercent = 59,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeviceObject { ID = "id", VolumePercent = 59 };

        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.IsPrivateSession);
        Assert.False(model.RawData.ContainsKey("is_private_session"));
        Assert.Null(model.IsRestricted);
        Assert.False(model.RawData.ContainsKey("is_restricted"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.SupportsVolume);
        Assert.False(model.RawData.ContainsKey("supports_volume"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeviceObject { ID = "id", VolumePercent = 59 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DeviceObject
        {
            ID = "id",
            VolumePercent = 59,

            // Null should be interpreted as omitted for these properties
            IsActive = null,
            IsPrivateSession = null,
            IsRestricted = null,
            Name = null,
            Published = null,
            SupportsVolume = null,
            Type = null,
        };

        Assert.Null(model.IsActive);
        Assert.False(model.RawData.ContainsKey("is_active"));
        Assert.Null(model.IsPrivateSession);
        Assert.False(model.RawData.ContainsKey("is_private_session"));
        Assert.Null(model.IsRestricted);
        Assert.False(model.RawData.ContainsKey("is_restricted"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
        Assert.Null(model.SupportsVolume);
        Assert.False(model.RawData.ContainsKey("supports_volume"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeviceObject
        {
            ID = "id",
            VolumePercent = 59,

            // Null should be interpreted as omitted for these properties
            IsActive = null,
            IsPrivateSession = null,
            IsRestricted = null,
            Name = null,
            Published = null,
            SupportsVolume = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DeviceObject
        {
            IsActive = true,
            IsPrivateSession = true,
            IsRestricted = true,
            Name = "Kitchen speaker",
            Published = true,
            SupportsVolume = true,
            Type = "computer",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.VolumePercent);
        Assert.False(model.RawData.ContainsKey("volume_percent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DeviceObject
        {
            IsActive = true,
            IsPrivateSession = true,
            IsRestricted = true,
            Name = "Kitchen speaker",
            Published = true,
            SupportsVolume = true,
            Type = "computer",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DeviceObject
        {
            IsActive = true,
            IsPrivateSession = true,
            IsRestricted = true,
            Name = "Kitchen speaker",
            Published = true,
            SupportsVolume = true,
            Type = "computer",

            ID = null,
            VolumePercent = null,
        };

        Assert.Null(model.ID);
        Assert.True(model.RawData.ContainsKey("id"));
        Assert.Null(model.VolumePercent);
        Assert.True(model.RawData.ContainsKey("volume_percent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DeviceObject
        {
            IsActive = true,
            IsPrivateSession = true,
            IsRestricted = true,
            Name = "Kitchen speaker",
            Published = true,
            SupportsVolume = true,
            Type = "computer",

            ID = null,
            VolumePercent = null,
        };

        model.Validate();
    }
}
