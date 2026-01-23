using System;
using Spotted.Models.Me.Albums;

namespace Spotted.Tests.Models.Me.Albums;

public class AlbumCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlbumCheckParams
        {
            Ids = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc",
        };

        string expectedIds = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc";

        Assert.Equal(expectedIds, parameters.Ids);
    }

    [Fact]
    public void Url_Works()
    {
        AlbumCheckParams parameters = new()
        {
            Ids = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/me/albums/contains?ids=382ObEPsp2rxGrnsizN5TX%2c1A2GTWGtFfWp7KSQTwWOyo%2c2noRn2Aes5aoNVsU6iWThc"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AlbumCheckParams
        {
            Ids = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc",
        };

        AlbumCheckParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
