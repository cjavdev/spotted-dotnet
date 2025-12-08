using System.Threading.Tasks;

namespace Spotted.Tests.Services.Browse;

public class CategoryServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var category = await this.client.Browse.Categories.Retrieve("dinner");
        category.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var categories = await this.client.Browse.Categories.List();
        categories.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task GetPlaylists_Works()
    {
        var response = await this.client.Browse.Categories.GetPlaylists("dinner");
        response.Validate();
    }
}
