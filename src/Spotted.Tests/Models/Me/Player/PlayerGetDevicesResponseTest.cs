using System.Collections.Generic;
using System.Text.Json;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerGetDevicesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlayerGetDevicesResponse
        {
            Devices =
            [
                new()
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
                },
            ],
        };

        List<DeviceObject> expectedDevices =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedDevices.Count, model.Devices.Count);
        for (int i = 0; i < expectedDevices.Count; i++)
        {
            Assert.Equal(expectedDevices[i], model.Devices[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlayerGetDevicesResponse
        {
            Devices =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlayerGetDevicesResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlayerGetDevicesResponse
        {
            Devices =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PlayerGetDevicesResponse>(element);
        Assert.NotNull(deserialized);

        List<DeviceObject> expectedDevices =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedDevices.Count, deserialized.Devices.Count);
        for (int i = 0; i < expectedDevices.Count; i++)
        {
            Assert.Equal(expectedDevices[i], deserialized.Devices[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlayerGetDevicesResponse
        {
            Devices =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }
}
