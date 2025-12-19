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
}
