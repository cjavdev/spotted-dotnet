using System;
using Spotted.Models.Chapters;

namespace Spotted.Tests.Models.Chapters;

public class ChapterBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChapterBulkRetrieveParams
        {
            Ids = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29",
            Market = "ES",
        };

        string expectedIds = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29";
        string expectedMarket = "ES";

        Assert.Equal(expectedIds, parameters.Ids);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChapterBulkRetrieveParams
        {
            Ids = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29",
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChapterBulkRetrieveParams
        {
            Ids = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void Url_Works()
    {
        ChapterBulkRetrieveParams parameters = new()
        {
            Ids = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29",
            Market = "ES",
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.spotify.com/v1/chapters?ids=0IsXVP0JmcB2adSE338GkK%2c3ZXb8FKZGU0EHALYX6uCzU%2c0D5wENdkdwbqlrHoaJ9g29&market=ES"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChapterBulkRetrieveParams
        {
            Ids = "0IsXVP0JmcB2adSE338GkK,3ZXb8FKZGU0EHALYX6uCzU,0D5wENdkdwbqlrHoaJ9g29",
            Market = "ES",
        };

        ChapterBulkRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
