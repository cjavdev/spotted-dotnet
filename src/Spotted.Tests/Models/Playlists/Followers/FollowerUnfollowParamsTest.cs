using System;
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

    [Fact]
    public void Url_Works()
    {
        FollowerUnfollowParams parameters = new() { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.spotify.com/v1/playlists/3cEYpjA9oz9GiPac4AsH4n/followers"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FollowerUnfollowParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        FollowerUnfollowParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
