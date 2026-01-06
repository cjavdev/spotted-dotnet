using System;
using System.Text.Json;
using Spotted.Models.Me.Following;

namespace Spotted.Tests.Models.Me.Following;

public class FollowingBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FollowingBulkRetrieveParams
        {
            After = "0I2XqVXqHScXjHhk6AYYRe",
            Limit = 10,
        };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"artist\"");
        string expectedAfter = "0I2XqVXqHScXjHhk6AYYRe";
        long expectedLimit = 10;

        Assert.True(JsonElement.DeepEquals(expectedType, parameters.Type));
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FollowingBulkRetrieveParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FollowingBulkRetrieveParams
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Limit = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        FollowingBulkRetrieveParams parameters = new()
        {
            Type = JsonSerializer.Deserialize<JsonElement>("\"artist\""),
            After = "0I2XqVXqHScXjHhk6AYYRe",
            Limit = 10,
        };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/me/following?type=artist&after=0I2XqVXqHScXjHhk6AYYRe&limit=10"
            ),
            url
        );
    }
}
