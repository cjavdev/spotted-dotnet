using System.Threading.Tasks;

namespace Spotted.Tests.Services.Browse;

public class CategoryServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var category = await this.client.Browse.Categories.Retrieve(
            "dinner",
            new(),
            TestContext.Current.CancellationToken
        );
        category.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var categories = await this.client.Browse.Categories.List(
            new(),
            TestContext.Current.CancellationToken
        );
        categories.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetPlaylists_Works()
    {
        var response = await this.client.Browse.Categories.GetPlaylists(
            "dinner",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
