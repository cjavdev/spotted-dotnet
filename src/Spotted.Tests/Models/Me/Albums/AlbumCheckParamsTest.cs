using Spotted.Models.Me.Albums;

namespace Spotted.Tests.Models.Me.Albums;

public class AlbumCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlbumCheckParams
        {
            IDs = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc",
        };

        string expectedIDs = "382ObEPsp2rxGrnsizN5TX,1A2GTWGtFfWp7KSQTwWOyo,2noRn2Aes5aoNVsU6iWThc";

        Assert.Equal(expectedIDs, parameters.IDs);
    }
}
