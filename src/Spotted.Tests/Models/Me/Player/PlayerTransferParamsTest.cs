using System;
using System.Collections.Generic;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerTransferParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlayerTransferParams
        {
            DeviceIds = ["74ASZWbe4lXaubB36ztrGX"],
            Play = true,
            Published = true,
        };

        List<string> expectedDeviceIds = ["74ASZWbe4lXaubB36ztrGX"];
        bool expectedPlay = true;
        bool expectedPublished = true;

        Assert.Equal(expectedDeviceIds.Count, parameters.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], parameters.DeviceIds[i]);
        }
        Assert.Equal(expectedPlay, parameters.Play);
        Assert.Equal(expectedPublished, parameters.Published);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlayerTransferParams { DeviceIds = ["74ASZWbe4lXaubB36ztrGX"] };

        Assert.Null(parameters.Play);
        Assert.False(parameters.RawBodyData.ContainsKey("play"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlayerTransferParams
        {
            DeviceIds = ["74ASZWbe4lXaubB36ztrGX"],

            // Null should be interpreted as omitted for these properties
            Play = null,
            Published = null,
        };

        Assert.Null(parameters.Play);
        Assert.False(parameters.RawBodyData.ContainsKey("play"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void Url_Works()
    {
        PlayerTransferParams parameters = new() { DeviceIds = ["74ASZWbe4lXaubB36ztrGX"] };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(new Uri("https://api.spotify.com/v1/me/player"), url);
    }
}
