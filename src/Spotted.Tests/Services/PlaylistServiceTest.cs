using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class PlaylistServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var playlist = await this.client.Playlists.Retrieve("3cEYpjA9oz9GiPac4AsH4n");
        playlist.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Playlists.Update("3cEYpjA9oz9GiPac4AsH4n");
    }
}
