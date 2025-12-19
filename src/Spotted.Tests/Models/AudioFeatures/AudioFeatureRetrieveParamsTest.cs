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
}
