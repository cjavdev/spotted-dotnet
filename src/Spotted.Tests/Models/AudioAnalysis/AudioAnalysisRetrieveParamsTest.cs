using System;
using Spotted.Models.AudioAnalysis;

namespace Spotted.Tests.Models.AudioAnalysis;

public class AudioAnalysisRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudioAnalysisRetrieveParams { ID = "11dFghVXANMlKmJXsNCbNl" };

        string expectedID = "11dFghVXANMlKmJXsNCbNl";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AudioAnalysisRetrieveParams parameters = new() { ID = "11dFghVXANMlKmJXsNCbNl" };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri("https://api.spotify.com/v1/audio-analysis/11dFghVXANMlKmJXsNCbNl"),
            url
        );
    }
}
