using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class ArtistServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var artistObject = await this.client.Artists.Retrieve(
            "0TnOYISbd1XYRBk9myaseg",
            new(),
            TestContext.Current.CancellationToken
        );
        artistObject.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task BulkRetrieve_Works()
    {
        var response = await this.client.Artists.BulkRetrieve(
            new() { IDs = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListAlbums_Works()
    {
        var page = await this.client.Artists.ListAlbums(
            "0TnOYISbd1XYRBk9myaseg",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListRelatedArtists_Works()
    {
        var response = await this.client.Artists.ListRelatedArtists(
            "0TnOYISbd1XYRBk9myaseg",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task TopTracks_Works()
    {
        var response = await this.client.Artists.TopTracks(
            "0TnOYISbd1XYRBk9myaseg",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
