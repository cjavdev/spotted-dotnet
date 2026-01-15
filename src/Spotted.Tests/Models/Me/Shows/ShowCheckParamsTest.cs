using System;
using Spotted.Models.Me.Shows;

namespace Spotted.Tests.Models.Me.Shows;

public class ShowCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShowCheckParams
        {
            Ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ",
        };

        string expectedIds = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";

        Assert.Equal(expectedIds, parameters.Ids);
    }

    [Fact]
    public void Url_Works()
    {
        ShowCheckParams parameters = new()
        {
            Ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/me/shows/contains?ids=5CfCWKI5pZ28U0uOzXkDHe%2c5as3aKmN2k11yfDDDSrvaZ"
            ),
            url
        );
    }
}
