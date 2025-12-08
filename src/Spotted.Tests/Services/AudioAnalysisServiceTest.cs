using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class AudioAnalysisServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var audioAnalysis = await this.client.AudioAnalysis.Retrieve("11dFghVXANMlKmJXsNCbNl");
        audioAnalysis.Validate();
    }
}
