using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class TopServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListTopArtists_Works()
    {
        var page = await this.client.Me.Top.ListTopArtists();
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListTopTracks_Works()
    {
        var page = await this.client.Me.Top.ListTopTracks();
        page.Validate();
    }
}
