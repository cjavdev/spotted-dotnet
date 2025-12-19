using Spotted.Models.Albums;

namespace Spotted.Tests.Models.Albums;

public class AlbumRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlbumRetrieveParams { ID = "4aawyAB9vmqN3uQ7FjRGTy", Market = "ES" };

        string expectedID = "4aawyAB9vmqN3uQ7FjRGTy";
        string expectedMarket = "ES";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AlbumRetrieveParams { ID = "4aawyAB9vmqN3uQ7FjRGTy" };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AlbumRetrieveParams
        {
            ID = "4aawyAB9vmqN3uQ7FjRGTy",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }
}
