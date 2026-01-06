using System;
using Spotted.Models.Artists;

namespace Spotted.Tests.Models.Artists;

public class ArtistBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ArtistBulkRetrieveParams
        {
            Ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6",
        };

        string expectedIds = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6";

        Assert.Equal(expectedIds, parameters.Ids);
    }

    [Fact]
    public void Url_Works()
    {
        ArtistBulkRetrieveParams parameters = new()
        {
            Ids = "2CIMQHirSU0MQqyYHq0eOx,57dN52uHvrHOxijzpIgu3E,1vCWHaC5f2uS3yhpwWbIA6",
        };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/artists?ids=2CIMQHirSU0MQqyYHq0eOx%2c57dN52uHvrHOxijzpIgu3E%2c1vCWHaC5f2uS3yhpwWbIA6"
            ),
            url
        );
    }
}
