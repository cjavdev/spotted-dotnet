using Spotted.Models.Me.Tracks;

namespace Spotted.Tests.Models.Me.Tracks;

public class TrackCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrackCheckParams
        {
            IDs = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B",
        };

        string expectedIDs = "7ouMYWpwJ422jRcDASZB7P,4VqPOruhp5EdPBeR92t6lQ,2takcwOaAZWiXQijPHIx7B";

        Assert.Equal(expectedIDs, parameters.IDs);
    }
}
