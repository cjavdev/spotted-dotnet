using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class TrackServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Me.Tracks.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Check_Works()
    {
        await this.client.Me.Tracks.Check(
            new() { IDs = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Me.Tracks.Remove(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Save_Works()
    {
        await this.client.Me.Tracks.Save(
            new() { IDs = ["string"] },
            TestContext.Current.CancellationToken
        );
    }
}
