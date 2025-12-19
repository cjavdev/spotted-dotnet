using System.Text;
using Spotted.Core;
using Spotted.Models.Playlists.Images;

namespace Spotted.Tests.Models.Playlists.Images;

public class ImageUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ImageUpdateParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Body = Encoding.UTF8.GetBytes("text"),
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        BinaryContent expectedBody = Encoding.UTF8.GetBytes("text");

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedBody, parameters.Body);
    }
}
