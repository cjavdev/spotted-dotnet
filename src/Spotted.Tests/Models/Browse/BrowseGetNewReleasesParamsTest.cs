using System;
using Spotted.Models.Browse;

namespace Spotted.Tests.Models.Browse;

public class BrowseGetNewReleasesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BrowseGetNewReleasesParams { Limit = 10, Offset = 5 };

        long expectedLimit = 10;
        long expectedOffset = 5;

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BrowseGetNewReleasesParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BrowseGetNewReleasesParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Offset = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void Url_Works()
    {
        BrowseGetNewReleasesParams parameters = new() { Limit = 10, Offset = 5 };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.spotify.com/v1/browse/new-releases?limit=10&offset=5"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BrowseGetNewReleasesParams { Limit = 10, Offset = 5 };

        BrowseGetNewReleasesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
