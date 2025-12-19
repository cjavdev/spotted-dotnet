using System.Collections.Generic;
using Spotted.Models.Me.Following;

namespace Spotted.Tests.Models.Me.Following;

public class FollowingFollowParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowingFollowParams { IDs = ["string"], Published = true };

        List<string> expectedIDs = ["string"];
        bool expectedPublished = true;

        Assert.Equal(expectedIDs.Count, parameters.IDs.Count);
        for (int i = 0; i < expectedIDs.Count; i++)
        {
            Assert.Equal(expectedIDs[i], parameters.IDs[i]);
        }
        Assert.Equal(expectedPublished, parameters.Published);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FollowingFollowParams { IDs = ["string"] };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FollowingFollowParams
        {
            IDs = ["string"],

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }
}
