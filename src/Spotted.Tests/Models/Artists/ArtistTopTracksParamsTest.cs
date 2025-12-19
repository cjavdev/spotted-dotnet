using Spotted.Models.Artists;

namespace Spotted.Tests.Models.Artists;

public class ArtistTopTracksParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtistTopTracksParams { ID = "0TnOYISbd1XYRBk9myaseg", Market = "ES" };

        string expectedID = "0TnOYISbd1XYRBk9myaseg";
        string expectedMarket = "ES";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ArtistTopTracksParams { ID = "0TnOYISbd1XYRBk9myaseg" };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ArtistTopTracksParams
        {
            ID = "0TnOYISbd1XYRBk9myaseg",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }
}
