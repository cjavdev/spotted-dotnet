using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class AlbumServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var album = await this.client.Albums.Retrieve("4aawyAB9vmqN3uQ7FjRGTy");
        album.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Albums.BulkRetrieve(
            new() { IDs = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc" }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListTracks_Works()
    {
        var page = await this.client.Albums.ListTracks("4aawyAB9vmqN3uQ7FjRGTy");
        page.Validate();
    }
}
