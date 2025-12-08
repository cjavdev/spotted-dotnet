using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class EpisodeServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var episodeObject = await this.client.Episodes.Retrieve("512ojhOuo1ktJprKbVcKyQ");
        episodeObject.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Episodes.BulkRetrieve(
            new() { IDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf" }
        );
        response.Validate();
    }
}
