using Spotted.Models.Playlists.Followers;

namespace Spotted.Tests.Models.Playlists.Followers;

public class FollowerCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowerCheckParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            IDs = "jmperezperez",
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        string expectedIDs = "jmperezperez";

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedIDs, parameters.IDs);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FollowerCheckParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        Assert.Null(parameters.IDs);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FollowerCheckParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",

            // Null should be interpreted as omitted for these properties
            IDs = null,
        };

        Assert.Null(parameters.IDs);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
    }
}
