using Spotted.Models.Artists;

namespace Spotted.Tests.Models.Artists;

public class ArtistBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtistBulkRetrieveParams
        {
            IDs = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6",
        };

        string expectedIDs = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";

        Assert.Equal(expectedIDs, parameters.IDs);
    }
}
