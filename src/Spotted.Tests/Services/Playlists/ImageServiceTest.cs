using System.Threading.Tasks;

namespace Spotted.Tests.Services.Playlists;

public class ImageServiceTest : TestBase
{
    [Fact(Skip = "Prism doesn't support application/binary responses")]
    public async Task Update_Works()
    {
        await this.client.Playlists.Images.Update("3cEYpjA9oz9GiPac4AsH4n", "a value");
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var imageObjects = await this.client.Playlists.Images.List("3cEYpjA9oz9GiPac4AsH4n");
        foreach (var item in imageObjects)
        {
            item.Validate();
        }
    }
}
