using Spotted.Models.Me.Audiobooks;

namespace Spotted.Tests.Models.Me.Audiobooks;

public class AudiobookRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudiobookRemoveParams
        {
            IDs = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe",
        };

        string expectedIDs = "18yVqkdbdRvS24c0Ilj2ci,1HGw3J3NxZO1TP1BTtVhpZ,7iHfbu1YPACw6oZPAFJtqe";

        Assert.Equal(expectedIDs, parameters.IDs);
    }
}
