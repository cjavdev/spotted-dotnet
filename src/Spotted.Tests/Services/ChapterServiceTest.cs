using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class ChapterServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var chapter = await this.client.Chapters.Retrieve("0D5wENdkdwbqlrHoaJ9g29");
        chapter.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Chapters.BulkRetrieve(
            new() { IDs = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29" }
        );
        response.Validate();
    }
}
