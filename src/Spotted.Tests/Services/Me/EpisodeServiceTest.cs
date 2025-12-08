using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class EpisodeServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Me.Episodes.List();
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Check_Works()
    {
        await this.client.Me.Episodes.Check(
            new() { IDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf" }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Me.Episodes.Remove();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Save_Works()
    {
        await this.client.Me.Episodes.Save(new() { IDs = ["string"] });
    }
}
