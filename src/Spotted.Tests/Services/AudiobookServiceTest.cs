using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class AudiobookServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var audiobook = await this.client.Audiobooks.Retrieve(
            "7iHfbu1YPACw6oZPAFJtqe",
            new(),
            TestContext.Current.CancellationToken
        );
        audiobook.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Audiobooks.BulkRetrieve(
            new() { IDs = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListChapters_Works()
    {
        var page = await this.client.Audiobooks.ListChapters(
            "7iHfbu1YPACw6oZPAFJtqe",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
