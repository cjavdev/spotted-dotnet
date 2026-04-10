using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class ShowServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var show = await this.client.Shows.Retrieve(
            "38bS44xjbVVZ3No3ByF1dJ",
            new(),
            TestContext.Current.CancellationToken
        );
        show.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Shows.BulkRetrieve(
            new() { Ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListEpisodes_Works()
    {
        var page = await this.client.Shows.ListEpisodes(
            "38bS44xjbVVZ3No3ByF1dJ",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
