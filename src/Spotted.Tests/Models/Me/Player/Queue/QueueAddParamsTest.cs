using Spotted.Models.Me.Player.Queue;

namespace Spotted.Tests.Models.Me.Player.Queue;

public class QueueAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new QueueAddParams
        {
            Uri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh",
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        string expectedUri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh";
        string expectedDeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8";

        Assert.Equal(expectedUri, parameters.Uri);
        Assert.Equal(expectedDeviceID, parameters.DeviceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new QueueAddParams { Uri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh" };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new QueueAddParams
        {
            Uri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh",

            // Null should be interpreted as omitted for these properties
            DeviceID = null,
        };

        Assert.Null(parameters.DeviceID);
        Assert.False(parameters.RawQueryData.ContainsKey("device_id"));
    }
}
