using Spotted.Models.Artists;

namespace Spotted.Tests.Models.Artists;

public class ArtistListRelatedArtistsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtistListRelatedArtistsParams { ID = "0TnOYISbd1XYRBk9myaseg" };

        string expectedID = "0TnOYISbd1XYRBk9myaseg";

        Assert.Equal(expectedID, parameters.ID);
    }
}
