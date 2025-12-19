using Spotted.Models.Me.Shows;

namespace Spotted.Tests.Models.Me.Shows;

public class ShowCheckParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShowCheckParams
        {
            IDs = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ",
        };

        string expectedIDs = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";

        Assert.Equal(expectedIDs, parameters.IDs);
    }
}
