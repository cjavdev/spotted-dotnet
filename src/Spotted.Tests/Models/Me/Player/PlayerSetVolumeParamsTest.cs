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
}
