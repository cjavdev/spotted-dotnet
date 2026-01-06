using System;
using Spotted.Models.Me.Episodes;

namespace Spotted.Tests.Models.Me.Episodes;

public class EpisodeCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeCheckParams
        {
            IDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
        };

        string expectedIDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf";

        Assert.Equal(expectedIDs, parameters.IDs);
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeCheckParams parameters = new()
        {
            IDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
        };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/me/episodes/contains?ids=77o6BIVlYM3msb4MMIL1jH%2c0Q86acNRm6V9GYx55SXKwf"
            ),
            url
        );
    }
}
