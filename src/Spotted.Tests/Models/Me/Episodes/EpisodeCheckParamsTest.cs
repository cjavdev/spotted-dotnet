using Spotted.Models.Me.Episodes;

namespace Spotted.Tests.Models.Me.Episodes;

public class EpisodeCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeCheckParams
        {
            IDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
        };

        string expectedIDs = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf";

        Assert.Equal(expectedIDs, parameters.IDs);
    }
}
