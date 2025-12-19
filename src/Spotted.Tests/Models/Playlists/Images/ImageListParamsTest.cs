using Spotted.Models.Playlists.Images;

namespace Spotted.Tests.Models.Playlists.Images;

public class ImageListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ImageListParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
    }
}
