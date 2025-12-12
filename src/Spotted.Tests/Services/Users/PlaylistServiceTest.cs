using System.Threading.Tasks;

namespace Spotted.Tests.Services.Users;

public class PlaylistServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var playlist = await this.client.Users.Playlists.Create(
            "smedjan",
            new() { Name = "New Playlist" },
            TestContext.Current.CancellationToken
        );
        playlist.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Users.Playlists.List(
            "smedjan",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
