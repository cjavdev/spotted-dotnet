using Spotted.Models.Playlists.Followers;

namespace Spotted.Tests.Models.Playlists.Followers;

public class FollowerUnfollowParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowerUnfollowParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
    }
}
