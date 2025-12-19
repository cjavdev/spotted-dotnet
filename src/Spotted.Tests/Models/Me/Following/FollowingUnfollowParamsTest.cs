using System.Collections.Generic;
using Spotted.Models.Me.Following;

namespace Spotted.Tests.Models.Me.Following;

public class FollowingUnfollowParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowingUnfollowParams { IDs = ["string"], Published = true };

        List<string> expectedIDs = ["string"];
        bool expectedPublished = true;

        Assert.NotNull(parameters.IDs);
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
        var parameters = new FollowingUnfollowParams { };

        Assert.Null(parameters.IDs);
        Assert.False(parameters.RawBodyData.ContainsKey("ids"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FollowingUnfollowParams
        {
            // Null should be interpreted as omitted for these properties
            IDs = null,
            Published = null,
        };

        Assert.Null(parameters.IDs);
        Assert.False(parameters.RawBodyData.ContainsKey("ids"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }
}
