using System;
using System.Text;
using Spotted.Core;
using Spotted.Models.Playlists.Images;

namespace Spotted.Tests.Models.Playlists.Images;

public class ImageUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent body = Encoding.UTF8.GetBytes("Example data");

        var parameters = new ImageUpdateParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Body = body,
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        BinaryContent expectedBody = body;

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedBody, parameters.Body);
    }

    [Fact]
    public void Url_Works()
    {
        ImageUpdateParams parameters = new()
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Body = Encoding.UTF8.GetBytes("Example data"),
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.spotify.com/v1/playlists/3cEYpjA9oz9GiPac4AsH4n/images"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ImageUpdateParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Body = Encoding.UTF8.GetBytes("Example data"),
        };

        ImageUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
