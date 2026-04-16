using System;
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

    [Fact]
    public void Url_Works()
    {
        FollowerFollowParams parameters = new() { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

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
        var parameters = new FollowerFollowParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Published = true,
        };

        FollowerFollowParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
