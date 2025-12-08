using System.Threading.Tasks;
using Spotted.Models.Search;

namespace Spotted.Tests.Services;

public class SearchServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Query_Works()
    {
        var response = await this.client.Search.Query(
            new() { Q = "remaster%20track:Doxy%20artist:Miles%20Davis", Type = [Type.Album] }
        );
        response.Validate();
    }
}
