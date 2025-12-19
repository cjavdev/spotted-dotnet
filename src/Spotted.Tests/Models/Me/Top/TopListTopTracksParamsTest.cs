using Spotted.Models.Me.Top;

namespace Spotted.Tests.Models.Me.Top;

public class TopListTopTracksParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TopListTopTracksParams
        {
            Limit = 10,
            Offset = 5,
            TimeRange = "medium_term",
        };

        long expectedLimit = 10;
        long expectedOffset = 5;
        string expectedTimeRange = "medium_term";

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
        Assert.Equal(expectedTimeRange, parameters.TimeRange);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TopListTopTracksParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.TimeRange);
        Assert.False(parameters.RawQueryData.ContainsKey("time_range"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TopListTopTracksParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
            TimeRange = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
        Assert.Null(parameters.TimeRange);
        Assert.False(parameters.RawQueryData.ContainsKey("time_range"));
    }
}
