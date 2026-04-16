using System;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerSetVolumeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlayerSetVolumeParams
        {
            VolumePercent = 50,
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        long expectedVolumePercent = 50;
        string expectedDeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

        Assert.Equal(expectedVolumePercent, parameters.VolumePercent);
        Assert.Equal(expectedDeviceID, parameters.DeviceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlayerSetVolumeParams { VolumePercent = 50 };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlayerSetVolumeParams
        {
            VolumePercent = 50,

            // Null should be interpreted as omitted for these properties
            DeviceID = null,
        };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PlayerSetVolumeParams parameters = new()
        {
            VolumePercent = 50,
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.spotify.com/v1/me/player/volume?volume_percent=50&device_id=0d1841b0976bae2a3a310dd74c0f3df354899bc8"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlayerSetVolumeParams
        {
            VolumePercent = 50,
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        PlayerSetVolumeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
