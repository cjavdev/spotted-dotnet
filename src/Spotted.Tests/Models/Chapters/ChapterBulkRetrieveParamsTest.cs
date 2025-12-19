using Spotted.Models.Chapters;

namespace Spotted.Tests.Models.Chapters;

public class ChapterBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChapterBulkRetrieveParams
        {
            IDs = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29",
            Market = "ES",
        };

        string expectedIDs = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29";
        string expectedMarket = "ES";

        Assert.Equal(expectedIDs, parameters.IDs);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChapterBulkRetrieveParams
        {
            IDs = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29",
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChapterBulkRetrieveParams
        {
            IDs = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }
}
