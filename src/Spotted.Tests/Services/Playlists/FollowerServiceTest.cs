using System.Threading.Tasks;

namespace Spotted.Tests.Services.Playlists;

public class FollowerServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Check_Works()
    {
        await this.client.Playlists.Followers.Check("3cEYpjA9oz9GiPac4AsH4n");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Follow_Works()
    {
        await this.client.Playlists.Followers.Follow("3cEYpjA9oz9GiPac4AsH4n");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Unfollow_Works()
    {
        await this.client.Playlists.Followers.Unfollow("3cEYpjA9oz9GiPac4AsH4n");
    }
}
