using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class BrowseServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetFeaturedPlaylists_Works()
    {
        var response = await this.client.Browse.GetFeaturedPlaylists(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetNewReleases_Works()
    {
        var response = await this.client.Browse.GetNewReleases(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
