using System;
using Spotted.Models.Shows;

namespace Spotted.Tests.Models.Shows;

public class ShowBulkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ShowBulkRetrieveParams
        {
            Ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ",
            Market = "ES",
        };

        string expectedIds = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ";
        string expectedMarket = "ES";

        Assert.Equal(expectedIds, parameters.Ids);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ShowBulkRetrieveParams
        {
            Ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ",
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ShowBulkRetrieveParams
        {
            Ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void Url_Works()
    {
        ShowBulkRetrieveParams parameters = new()
        {
            Ids = "5CfCWKI5pZ28U0uOzXkDHe,5as3aKmN2k11yfDDDSrvaZ",
            Market = "ES",
        };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/shows?ids=5CfCWKI5pZ28U0uOzXkDHe%2c5as3aKmN2k11yfDDDSrvaZ&market=ES"
            ),
            url
        );
    }
}
