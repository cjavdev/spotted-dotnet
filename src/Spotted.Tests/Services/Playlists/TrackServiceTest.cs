using System.Threading.Tasks;

namespace Spotted.Tests.Services.Playlists;

public class TrackServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var track = await this.client.Playlists.Tracks.Update(
            "3cEYpjA9oz9GiPac4AsH4n",
            new(),
            TestContext.Current.CancellationToken
        );
        track.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Playlists.Tracks.List(
            "3cEYpjA9oz9GiPac4AsH4n",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        var response = await this.client.Playlists.Tracks.Add(
            "3cEYpjA9oz9GiPac4AsH4n",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Remove_Works()
    {
        var track = await this.client.Playlists.Tracks.Remove(
            "3cEYpjA9oz9GiPac4AsH4n",
            new() { Tracks = [new() { Uri = "uri" }] },
            TestContext.Current.CancellationToken
        );
        track.Validate();
    }
}
