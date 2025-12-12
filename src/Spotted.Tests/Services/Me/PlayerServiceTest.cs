using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class PlayerServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetCurrentlyPlaying_Works()
    {
        var response = await this.client.Me.Player.GetCurrentlyPlaying(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetDevices_Works()
    {
        var response = await this.client.Me.Player.GetDevices(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetState_Works()
    {
        var response = await this.client.Me.Player.GetState(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListRecentlyPlayed_Works()
    {
        var page = await this.client.Me.Player.ListRecentlyPlayed(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task PausePlayback_Works()
    {
        await this.client.Me.Player.PausePlayback(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SeekToPosition_Works()
    {
        await this.client.Me.Player.SeekToPosition(
            new() { PositionMs = 25000 },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SetRepeatMode_Works()
    {
        await this.client.Me.Player.SetRepeatMode(
            new() { State = "context" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SetVolume_Works()
    {
        await this.client.Me.Player.SetVolume(
            new() { VolumePercent = 50 },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SkipNext_Works()
    {
        await this.client.Me.Player.SkipNext(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SkipPrevious_Works()
    {
        await this.client.Me.Player.SkipPrevious(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task StartPlayback_Works()
    {
        await this.client.Me.Player.StartPlayback(new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ToggleShuffle_Works()
    {
        await this.client.Me.Player.ToggleShuffle(
            new() { State = true },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Transfer_Works()
    {
        await this.client.Me.Player.Transfer(
            new() { DeviceIDs = ["74ASZWbe4lXaubB36ztrGX"] },
            TestContext.Current.CancellationToken
        );
    }
}
