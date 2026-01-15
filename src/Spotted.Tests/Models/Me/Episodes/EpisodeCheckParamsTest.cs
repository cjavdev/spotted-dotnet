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
            Ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
        };

        string expectedIds = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf";

        Assert.Equal(expectedIds, parameters.Ids);
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeCheckParams parameters = new()
        {
            Ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/me/episodes/contains?ids=77o6BIVlYM3msb4MMIL1jH%2c0Q86acNRm6V9GYx55SXKwf"
            ),
            url
        );
    }
}
