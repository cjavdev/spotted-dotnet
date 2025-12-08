using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class ShowServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var show = await this.client.Shows.Retrieve("38bS44xjbVVZ3No3ByF1dJ");
        show.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Shows.BulkRetrieve(
            new() { IDs = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ" }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListEpisodes_Works()
    {
        var page = await this.client.Shows.ListEpisodes("38bS44xjbVVZ3No3ByF1dJ");
        page.Validate();
    }
}
