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
}
