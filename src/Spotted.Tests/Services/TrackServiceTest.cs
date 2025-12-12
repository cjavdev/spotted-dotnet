using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class TrackServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var trackObject = await this.client.Tracks.Retrieve(
            "11dFghVXANMlKmJXsNCbNl",
            new(),
            TestContext.Current.CancellationToken
        );
        trackObject.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Tracks.BulkRetrieve(
            new() { IDs = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
