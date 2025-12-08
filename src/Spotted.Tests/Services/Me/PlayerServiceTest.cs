using System.Threading.Tasks;

namespace Spotted.Tests.Services.Me;

public class PlayerServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetCurrentlyPlaying_Works()
    {
        var response = await this.client.Me.Player.GetCurrentlyPlaying();
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetDevices_Works()
    {
        var response = await this.client.Me.Player.GetDevices();
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetState_Works()
    {
        var response = await this.client.Me.Player.GetState();
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListRecentlyPlayed_Works()
    {
        var page = await this.client.Me.Player.ListRecentlyPlayed();
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task PausePlayback_Works()
    {
        await this.client.Me.Player.PausePlayback();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SeekToPosition_Works()
    {
        await this.client.Me.Player.SeekToPosition(new() { PositionMs = 25000 });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SetRepeatMode_Works()
    {
        await this.client.Me.Player.SetRepeatMode(new() { State = "context" });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SetVolume_Works()
    {
        await this.client.Me.Player.SetVolume(new() { VolumePercent = 50 });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SkipNext_Works()
    {
        await this.client.Me.Player.SkipNext();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SkipPrevious_Works()
    {
        await this.client.Me.Player.SkipPrevious();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task StartPlayback_Works()
    {
        await this.client.Me.Player.StartPlayback();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ToggleShuffle_Works()
    {
        await this.client.Me.Player.ToggleShuffle(new() { State = true });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Transfer_Works()
    {
        await this.client.Me.Player.Transfer(new() { DeviceIDs = ["74ASZWbe4lXaubB36ztrGX"] });
    }
}
