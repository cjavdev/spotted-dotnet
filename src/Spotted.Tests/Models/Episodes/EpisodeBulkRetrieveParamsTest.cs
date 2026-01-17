using System;
using Spotted.Models.Episodes;

namespace Spotted.Tests.Models.Episodes;

public class EpisodeBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeBulkRetrieveParams
        {
            Ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
            Market = "ES",
        };

        string expectedIds = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf";
        string expectedMarket = "ES";

        Assert.Equal(expectedIds, parameters.Ids);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EpisodeBulkRetrieveParams
        {
            Ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EpisodeBulkRetrieveParams
        {
            Ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeBulkRetrieveParams parameters = new()
        {
            Ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
            Market = "ES",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/episodes?ids=77o6BIVlYM3msb4MMIL1jH%2c0Q86acNRm6V9GYx55SXKwf&market=ES"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EpisodeBulkRetrieveParams
        {
            Ids = "77o6BIVlYM3msb4MMIL1jH,0Q86acNRm6V9GYx55SXKwf",
            Market = "ES",
        };

        EpisodeBulkRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
