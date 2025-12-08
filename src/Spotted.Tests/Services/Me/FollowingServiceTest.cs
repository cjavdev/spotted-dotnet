using System.Text.Json;
using System.Threading.Tasks;
using Spotted.Models.Me.Following;

namespace Spotted.Tests.Services.Me;

public class FollowingServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Me.Following.BulkRetrieve(
            new() { Type = JsonSerializer.Deserialize<JsonElement>("\"artist\"") }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Check_Works()
    {
        await this.client.Me.Following.Check(
            new()
            {
                IDs = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6",
                Type = Type.Artist,
            }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Follow_Works()
    {
        await this.client.Me.Following.Follow(new() { IDs = ["string"] });
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Unfollow_Works()
    {
        await this.client.Me.Following.Unfollow();
    }
}
