using System;
using System.Collections.Generic;
using Spotted.Models.Me.Albums;

namespace Spotted.Tests.Models.Me.Albums;

public class AlbumSaveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AlbumSaveParams { Ids = ["string"], Published = true };

        List<string> expectedIds = ["string"];
        bool expectedPublished = true;

        Assert.NotNull(parameters.Ids);
        Assert.Equal(expectedIds.Count, parameters.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], parameters.Ids[i]);
        }
        Assert.Equal(expectedPublished, parameters.Published);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AlbumSaveParams { };

        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawBodyData.ContainsKey("ids"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AlbumSaveParams
        {
            // Null should be interpreted as omitted for these properties
            Ids = null,
            Published = null,
        };

        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawBodyData.ContainsKey("ids"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void Url_Works()
    {
        AlbumSaveParams parameters = new();

        var url = parameters.Url(
            new() { ClientID = "My Client ID", ClientSecret = "My Client Secret" }
        );

        Assert.Equal(new Uri("https://api.spotify.com/v1/me/albums"), url);
    }
}
