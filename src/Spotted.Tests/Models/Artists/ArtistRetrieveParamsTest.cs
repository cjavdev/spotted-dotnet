using Spotted.Models.Artists;

namespace Spotted.Tests.Models.Artists;

public class ArtistRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtistRetrieveParams { ID = "0TnOYISbd1XYRBk9myaseg" };

        string expectedID = "0TnOYISbd1XYRBk9myaseg";

        Assert.Equal(expectedID, parameters.ID);
    }
}
