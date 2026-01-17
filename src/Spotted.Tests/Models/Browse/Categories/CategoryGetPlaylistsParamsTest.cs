using System;
using Spotted.Models.Browse.Categories;

namespace Spotted.Tests.Models.Browse.Categories;

public class CategoryGetPlaylistsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CategoryGetPlaylistsParams
        {
            CategoryID = "dinner",
            Limit = 10,
            Offset = 5,
        };

        string expectedCategoryID = "dinner";
        long expectedLimit = 10;
        long expectedOffset = 5;

        Assert.Equal(expectedCategoryID, parameters.CategoryID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CategoryGetPlaylistsParams { CategoryID = "dinner" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CategoryGetPlaylistsParams
        {
            CategoryID = "dinner",

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
        CategoryGetPlaylistsParams parameters = new()
        {
            CategoryID = "dinner",
            Limit = 10,
            Offset = 5,
        };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(
            new Uri(
                "https://api.spotify.com/v1/browse/categories/dinner/playlists?limit=10&offset=5"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CategoryGetPlaylistsParams
        {
            CategoryID = "dinner",
            Limit = 10,
            Offset = 5,
        };

        CategoryGetPlaylistsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
