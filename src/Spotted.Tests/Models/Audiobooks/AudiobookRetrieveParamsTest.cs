using System;
using Spotted.Models.Audiobooks;

namespace Spotted.Tests.Models.Audiobooks;

public class AudiobookRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AudiobookRetrieveParams
        {
            ID = "7iHfbu1YPACw6oZPAFJtqe",
            Market = "ES",
        };

        string expectedID = "7iHfbu1YPACw6oZPAFJtqe";
        string expectedMarket = "ES";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AudiobookRetrieveParams { ID = "7iHfbu1YPACw6oZPAFJtqe" };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AudiobookRetrieveParams
        {
            ID = "7iHfbu1YPACw6oZPAFJtqe",

            // Null should be interpreted as omitted for these properties
            Market = null,
        };

        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void Url_Works()
    {
        AudiobookRetrieveParams parameters = new() { ID = "7iHfbu1YPACw6oZPAFJtqe", Market = "ES" };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri("https://api.spotify.com/v1/audiobooks/7iHfbu1YPACw6oZPAFJtqe?market=ES"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AudiobookRetrieveParams
        {
            ID = "7iHfbu1YPACw6oZPAFJtqe",
            Market = "ES",
        };

        AudiobookRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
