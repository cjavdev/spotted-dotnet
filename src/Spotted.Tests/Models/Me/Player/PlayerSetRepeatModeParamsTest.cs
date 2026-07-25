using System;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerSetRepeatModeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlayerSetRepeatModeParams
        {
            State = "context",
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        string expectedState = "context";
        string expectedDeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedDeviceID, parameters.DeviceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlayerSetRepeatModeParams { State = "context" };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlayerSetRepeatModeParams
        {
            State = "context",

            // Null should be interpreted as omitted for these properties
            DeviceID = null,
        };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
    }

    [Fact]
    public void Url_Works()
    {
        PlayerSetRepeatModeParams parameters = new()
        {
            State = "context",
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.spotify.com/v1/me/player/repeat?state=context&device_id=0d1841b0976bae2a3a310dd74c0f3df354899bc8"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlayerSetRepeatModeParams
        {
            State = "context",
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        PlayerSetRepeatModeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
