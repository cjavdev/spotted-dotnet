using System;
using Spotted.Models.Browse.Categories;

namespace Spotted.Tests.Models.Browse.Categories;

public class CategoryListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CategoryListParams
        {
            Limit = 10,
            Locale = "sv_SE",
            Offset = 5,
        };

        long expectedLimit = 10;
        string expectedLocale = "sv_SE";
        long expectedOffset = 5;

        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CategoryListParams { };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CategoryListParams
        {
            // Null should be interpreted as omitted for these properties
            Limit = null,
            Locale = null,
            Offset = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawQueryData.ContainsKey("locale"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void Url_Works()
    {
        CategoryListParams parameters = new()
        {
            Limit = 10,
            Locale = "sv_SE",
            Offset = 5,
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.spotify.com/v1/browse/categories?limit=10&locale=sv_SE&offset=5"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CategoryListParams
        {
            Limit = 10,
            Locale = "sv_SE",
            Offset = 5,
        };

        CategoryListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
