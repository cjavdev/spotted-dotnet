using System;
using Spotted.Models.AudioFeatures;

namespace Spotted.Tests.Models.AudioFeatures;

public class AudioFeatureRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudioFeatureRetrieveParams { ID = "11dFghVXANMlKmJXsNCbNl" };

        string expectedID = "11dFghVXANMlKmJXsNCbNl";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        AudioFeatureRetrieveParams parameters = new() { ID = "11dFghVXANMlKmJXsNCbNl" };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri("https://api.spotify.com/v1/audio-features/11dFghVXANMlKmJXsNCbNl"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AudioFeatureRetrieveParams { ID = "11dFghVXANMlKmJXsNCbNl" };

        AudioFeatureRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
