using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me.Player;

public class QueueServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        await this.client.Me.Player.Queue.Add(
            new() { Uri = "spotify:track:4iV5W9uYEdYUVa79Axb7Rh" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Get_Works()
    {
        var queue = await this.client.Me.Player.Queue.Get(
            new(),
            TestContext.Current.CancellationToken
        );
        queue.Validate();
    }
}
