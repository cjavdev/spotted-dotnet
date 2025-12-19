using Spotted.Models.Tracks;

namespace Spotted.Tests.Models.Tracks;

public class TrackRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrackRetrieveParams { ID = "11dFghVXANMlKmJXsNCbNl", Market = "ES" };

        string expectedID = "11dFghVXANMlKmJXsNCbNl";
        string expectedMarket = "ES";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TrackRetrieveParams { ID = "11dFghVXANMlKmJXsNCbNl" };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TrackRetrieveParams
        {
            ID = "11dFghVXANMlKmJXsNCbNl",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }
}
