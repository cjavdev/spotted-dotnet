using System.Text;
using System.Threading.Tasks;

namespace Spotted.Tests.Services.Playlists;

public class ImageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        await this.client.Playlists.Images.Update(
            "3cEYpjA9oz9GiPac4AsH4n",
            Encoding.UTF8.GetBytes("Example data"),
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var imageObjects = await this.client.Playlists.Images.List(
            "3cEYpjA9oz9GiPac4AsH4n",
            new(),
            TestContext.Current.CancellationToken
        );
        foreach (var item in imageObjects)
        {
            item.Validate();
        }
    }
}
