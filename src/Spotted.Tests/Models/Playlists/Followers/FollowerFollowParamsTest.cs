using Spotted.Models.Playlists.Followers;

namespace Spotted.Tests.Models.Playlists.Followers;

public class FollowerFollowParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowerFollowParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Published = true,
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        bool expectedPublished = true;

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedPublished, parameters.Published);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FollowerFollowParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FollowerFollowParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }
}
