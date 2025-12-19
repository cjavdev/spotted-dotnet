using Spotted.Models.Episodes;

namespace Spotted.Tests.Models.Episodes;

public class EpisodeBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeBulkRetrieveParams
        {
            IDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
            Market = "ES",
        };

        string expectedIDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf";
        string expectedMarket = "ES";

        Assert.Equal(expectedIDs, parameters.IDs);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeBulkRetrieveParams
        {
            IDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EpisodeBulkRetrieveParams
        {
            IDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }
}
