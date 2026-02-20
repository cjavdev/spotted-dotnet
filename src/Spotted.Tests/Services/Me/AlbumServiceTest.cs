using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class AlbumServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Me.Albums.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Check_Works()
    {
        await this.client.Me.Albums.Check(
            new() { Ids = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Me.Albums.Remove(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Save_Works()
    {
        await this.client.Me.Albums.Save(new(), TestContext.Current.CancellationToken);
    }
}
