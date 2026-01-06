using System;
using Spotted.Models.AudioFeatures;

namespace Spotted.Tests.Models.AudioFeatures;

public class AudioFeatureBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudioFeatureBulkRetrieveParams
        {
            IDs = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B",
        };

        string expectedIDs = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";

        Assert.Equal(expectedIDs, parameters.IDs);
    }

    [Fact]
    public void Url_Works()
    {
        AudioFeatureBulkRetrieveParams parameters = new()
        {
            IDs = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B",
        };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/audio-features?ids=7ouMYWpwJ422jRcDASZB7P%2c4VqPOruhp5EdPBeR92t6lQ%2c2takcwOaAZWiXQijPHIx7B"
            ),
            url
        );
    }
}
