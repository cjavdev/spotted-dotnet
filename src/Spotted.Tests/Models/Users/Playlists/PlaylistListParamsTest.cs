using Spotted.Models.Users.Playlists;

namespace Spotted.Tests.Models.Users.Playlists;

public class PlaylistListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlaylistListParams
        {
            UserID = "smedjan",
            Limit = 10,
            Offset = 5,
        };

        string expectedUserID = "smedjan";
        long expectedLimit = 10;
        long expectedOffset = 5;

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlaylistListParams { UserID = "smedjan" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlaylistListParams
        {
            UserID = "smedjan",

            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }
}
