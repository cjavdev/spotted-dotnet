using Spotted.Models.Artists;

namespace Spotted.Tests.Models.Artists;

public class ArtistListAlbumsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtistListAlbumsParams
        {
            ID = "0TnOYISbd1XYRBk9myaseg",
            IncludeGroups = "single,appears_on",
            Limit = 10,
            Market = "ES",
            Offset = 5,
        };

        string expectedID = "0TnOYISbd1XYRBk9myaseg";
        string expectedIncludeGroups = "single,appears_on";
        long expectedLimit = 10;
        string expectedMarket = "ES";
        long expectedOffset = 5;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIncludeGroups, parameters.IncludeGroups);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMarket, parameters.Market);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ArtistListAlbumsParams { ID = "0TnOYISbd1XYRBk9myaseg" };

        Assert.Null(parameters.IncludeGroups);
        Assert.False(parameters.RawQueryData.ContainsKey("include_groups"));
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
        var parameters = new ArtistListAlbumsParams
        {
            ID = "0TnOYISbd1XYRBk9myaseg",

            // Null should be interpreted as omitted for these properties
            IncludeGroups = null,
            Limit = null,
            Market = null,
            Offset = null,
        };

        Assert.Null(parameters.IncludeGroups);
        Assert.False(parameters.RawQueryData.ContainsKey("include_groups"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }
}
