using System;
using Spotted.Models.Browse.Categories;

namespace Spotted.Tests.Models.Browse.Categories;

public class CategoryRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CategoryRetrieveParams { CategoryID = "dinner", Locale = "sv_SE" };

        string expectedCategoryID = "dinner";
        string expectedLocale = "sv_SE";

        Assert.Equal(expectedCategoryID, parameters.CategoryID);
        Assert.Equal(expectedLocale, parameters.Locale);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CategoryRetrieveParams { CategoryID = "dinner" };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CategoryRetrieveParams
        {
            CategoryID = "dinner",

            // Null should be interpreted as omitted for these properties
            Locale = null,
        };

        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
    }

    [Fact]
    public void Url_Works()
    {
        CategoryRetrieveParams parameters = new() { CategoryID = "dinner", Locale = "sv_SE" };

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(
            new Uri("https://api.spotify.com/v1/browse/categories/dinner?locale=sv_SE"),
            url
        );
    }
}
