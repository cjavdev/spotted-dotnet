using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class RecommendationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var recommendation = await this.client.Recommendations.Get(
            new(),
            TestContext.Current.CancellationToken
        );
        recommendation.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListAvailableGenreSeeds_Works()
    {
        var response = await this.client.Recommendations.ListAvailableGenreSeeds(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
