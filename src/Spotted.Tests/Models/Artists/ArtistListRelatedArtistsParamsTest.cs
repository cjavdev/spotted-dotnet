using System;
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

    [Fact]
    public void Url_Works()
    {
        ArtistListRelatedArtistsParams parameters = new() { ID = "0TnOYISbd1XYRBk9myaseg" };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri("https://api.spotify.com/v1/artists/0TnOYISbd1XYRBk9myaseg/related-artists"),
            url
        );
    }
}
