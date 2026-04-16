using System;
using Spotted.Models.Me.Player;

namespace Spotted.Tests.Models.Me.Player;

public class PlayerGetCurrentlyPlayingParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlayerGetCurrentlyPlayingParams
        {
            AdditionalTypes = "additional_types",
            Market = "ES",
        };

        string expectedAdditionalTypes = "additional_types";
        string expectedMarket = "ES";

        Assert.Equal(expectedAdditionalTypes, parameters.AdditionalTypes);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlayerGetCurrentlyPlayingParams { };

        Assert.Null(parameters.AdditionalTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("additional_types"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlayerGetCurrentlyPlayingParams
        {
            // Null should be interpreted as omitted for these properties
            AdditionalTypes = null,
            Market = null,
        };

        Assert.Null(parameters.AdditionalTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("additional_types"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void Url_Works()
    {
        PlayerGetCurrentlyPlayingParams parameters = new()
        {
            AdditionalTypes = "additional_types",
            Market = "ES",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.spotify.com/v1/me/player/currently-playing?additional_types=additional_types&market=ES"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlayerGetCurrentlyPlayingParams
        {
            AdditionalTypes = "additional_types",
            Market = "ES",
        };

        PlayerGetCurrentlyPlayingParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
