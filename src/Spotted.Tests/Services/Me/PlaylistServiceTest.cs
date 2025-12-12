using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class PlaylistServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Me.Playlists.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
