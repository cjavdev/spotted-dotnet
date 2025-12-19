using Spotted.Models.Episodes;

namespace Spotted.Tests.Models.Episodes;

public class EpisodeRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeRetrieveParams { ID = "512ojhOuo1ktJprKbVcKyQ", Market = "ES" };

        string expectedID = "512ojhOuo1ktJprKbVcKyQ";
        string expectedMarket = "ES";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeRetrieveParams { ID = "512ojhOuo1ktJprKbVcKyQ" };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EpisodeRetrieveParams
        {
            ID = "512ojhOuo1ktJprKbVcKyQ",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }
}
