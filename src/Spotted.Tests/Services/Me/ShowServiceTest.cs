using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class ShowServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Me.Shows.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Check_Works()
    {
        await this.client.Me.Shows.Check(
            new() { IDs = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Remove_Works()
    {
        await this.client.Me.Shows.Remove(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Save_Works()
    {
        await this.client.Me.Shows.Save(new(), TestContext.Current.CancellationToken);
    }
}
