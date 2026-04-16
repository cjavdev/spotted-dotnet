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

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.spotify.com/v1/artists/0TnOYISbd1XYRBk9myaseg/related-artists"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ArtistListRelatedArtistsParams { ID = "0TnOYISbd1XYRBk9myaseg" };

        ArtistListRelatedArtistsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
