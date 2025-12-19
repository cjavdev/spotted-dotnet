using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerSkipPreviousParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlayerSkipPreviousParams
        {
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        string expectedDeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

        Assert.Equal(expectedDeviceID, parameters.DeviceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlayerSkipPreviousParams { };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlayerSkipPreviousParams
        {
            // Null should be interpreted as omitted for these properties
            DeviceID = null,
        };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
    }
}
