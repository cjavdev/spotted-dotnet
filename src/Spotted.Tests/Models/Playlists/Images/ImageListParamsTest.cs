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

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri("https://api.spotify.com/v1/playlists/3cEYpjA9oz9GiPac4AsH4n/images"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ImageListParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        ImageListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
