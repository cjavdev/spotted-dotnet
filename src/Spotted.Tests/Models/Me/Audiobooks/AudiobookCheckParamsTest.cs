using System;
using Spotted.Models.Me.Audiobooks;

namespace Spotted.Tests.Models.Me.Audiobooks;

public class AudiobookCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudiobookCheckParams
        {
            Ids = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe",
        };

        string expectedIds = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe";

        Assert.Equal(expectedIds, parameters.Ids);
    }

    [Fact]
    public void Url_Works()
    {
        AudiobookCheckParams parameters = new()
        {
            Ids = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe",
        };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/me/audiobooks/contains?ids=18yVqkdbdRvS24c0Ilj2ci%2c1HGw3J3NxZO1TP1BTtVhpZ%2c7iHfbu1YPACw6oZPAFJtqe"
            ),
            url
        );
    }
}
