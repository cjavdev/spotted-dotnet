using Spotted.Models.Albums;

namespace Spotted.Tests.Models.Albums;

public class AlbumListTracksParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlbumListTracksParams
        {
            ID = "4aawyAB9vmqN3uQ7FjRGTy",
            Limit = 10,
            Market = "ES",
            Offset = 5,
        };

        string expectedID = "4aawyAB9vmqN3uQ7FjRGTy";
        long expectedLimit = 10;
        string expectedMarket = "ES";
        long expectedOffset = 5;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMarket, parameters.Market);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AlbumListTracksParams { ID = "4aawyAB9vmqN3uQ7FjRGTy" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AlbumListTracksParams
        {
            ID = "4aawyAB9vmqN3uQ7FjRGTy",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Market = null,
            Offset = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }
}
