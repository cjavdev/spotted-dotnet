using System;
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
            Ids = "jmperezperez",
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        string expectedIds = "jmperezperez";

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedIds, parameters.Ids);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FollowerCheckParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FollowerCheckParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",

            // Null should be interpreted as omitted for these properties
            Ids = null,
        };

        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
    }

    [Fact]
    public void Url_Works()
    {
        FollowerCheckParams parameters = new()
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Ids = "jmperezperez",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/playlists/3cEYpjA9oz9GiPac4AsH4n/followers/contains?ids=jmperezperez"
            ),
            url
        );
    }
}
