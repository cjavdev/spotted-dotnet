using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class EpisodeServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Me.Episodes.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Check_Works()
    {
        await this.client.Me.Episodes.Check(
            new() { Ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Me.Episodes.Remove(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Save_Works()
    {
        await this.client.Me.Episodes.Save(
            new() { Ids = ["string"] },
            TestContext.Current.CancellationToken
        );
    }
}
