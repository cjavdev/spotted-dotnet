using Spotted.Models.Chapters;

namespace Spotted.Tests.Models.Chapters;

public class ChapterRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChapterRetrieveParams { ID = "0D5wENdkdwbqlrHoaJ9g29", Market = "ES" };

        string expectedID = "0D5wENdkdwbqlrHoaJ9g29";
        string expectedMarket = "ES";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChapterRetrieveParams { ID = "0D5wENdkdwbqlrHoaJ9g29" };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChapterRetrieveParams
        {
            ID = "0D5wENdkdwbqlrHoaJ9g29",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }
}
