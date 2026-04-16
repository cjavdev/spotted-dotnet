using System;
using Spotted.Models.Chapters;

namespace Spotted.Tests.Models.Chapters;

public class ChapterRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ChapterRetrieveParams { ID = "0D5wENdkdwbqlrHoaJ9g29", Market = "ES" };

        string expectedID = "0D5wENdkdwbqlrHoaJ9g29";
        string expectedMarket = "ES";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ChapterRetrieveParams { ID = "0D5wENdkdwbqlrHoaJ9g29" };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ChapterRetrieveParams
        {
            ID = "0D5wENdkdwbqlrHoaJ9g29",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void Url_Works()
    {
        ChapterRetrieveParams parameters = new() { ID = "0D5wENdkdwbqlrHoaJ9g29", Market = "ES" };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.spotify.com/v1/chapters/0D5wENdkdwbqlrHoaJ9g29?market=ES"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ChapterRetrieveParams { ID = "0D5wENdkdwbqlrHoaJ9g29", Market = "ES" };

        ChapterRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
