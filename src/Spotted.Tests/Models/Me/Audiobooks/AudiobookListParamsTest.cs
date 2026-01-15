using System;
using Spotted.Models.Me.Audiobooks;

namespace Spotted.Tests.Models.Me.Audiobooks;

public class AudiobookListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudiobookListParams { Limit = 10, Offset = 5 };

        long expectedLimit = 10;
        long expectedOffset = 5;

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AudiobookListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AudiobookListParams
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
        AudiobookListParams parameters = new() { Limit = 10, Offset = 5 };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(new Uri("https://api.spotify.com/v1/me/audiobooks?limit=10&offset=5"), url);
    }
}
