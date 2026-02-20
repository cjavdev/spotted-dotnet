using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class MarketServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var markets = await this.client.Markets.List(new(), TestContext.Current.CancellationToken);
        markets.Validate();
    }
}
