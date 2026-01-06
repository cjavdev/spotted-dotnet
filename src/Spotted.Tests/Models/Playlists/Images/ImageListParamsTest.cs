using System;
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

    [Fact]
    public void Url_Works()
    {
        ImageListParams parameters = new() { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri("https://api.spotify.com/v1/playlists/3cEYpjA9oz9GiPac4AsH4n/images"),
            url
        );
    }
}
