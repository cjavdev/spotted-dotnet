using System;
using Spotted.Models.Shows;

namespace Spotted.Tests.Models.Shows;

public class ShowRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShowRetrieveParams { ID = "38bS44xjbVVZ3No3ByF1dJ", Market = "ES" };

        string expectedID = "38bS44xjbVVZ3No3ByF1dJ";
        string expectedMarket = "ES";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ShowRetrieveParams { ID = "38bS44xjbVVZ3No3ByF1dJ" };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ShowRetrieveParams
        {
            ID = "38bS44xjbVVZ3No3ByF1dJ",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void Url_Works()
    {
        ShowRetrieveParams parameters = new() { ID = "38bS44xjbVVZ3No3ByF1dJ", Market = "ES" };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri("https://api.spotify.com/v1/shows/38bS44xjbVVZ3No3ByF1dJ?market=ES"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ShowRetrieveParams { ID = "38bS44xjbVVZ3No3ByF1dJ", Market = "ES" };

        ShowRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
