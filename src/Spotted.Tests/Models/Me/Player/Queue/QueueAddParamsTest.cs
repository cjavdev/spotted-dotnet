using System;
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

    [Fact]
    public void Url_Works()
    {
        QueueAddParams parameters = new()
        {
            Uri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh",
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.spotify.com/v1/me/player/queue?uri=spotify%3atrack%3a4iV5W9uYEdYUVa79Axb7Rh&device_id=0d1841b0976bae2a3a310dd74c0f3df354899bc8"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new QueueAddParams
        {
            Uri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh",
            DeviceID = "0d1841b0976bae2a3a310dd74c0f3df354899bc8",
        };

        QueueAddParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
