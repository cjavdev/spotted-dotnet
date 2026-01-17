using System;
using System.Collections.Generic;
using Spotted.Models.Me.Episodes;

namespace Spotted.Tests.Models.Me.Episodes;

public class EpisodeSaveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EpisodeSaveParams { Ids = ["string"], Published = true };

        List<string> expectedIds = ["string"];
        bool expectedPublished = true;

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
        var parameters = new EpisodeSaveParams { Ids = ["string"] };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EpisodeSaveParams
        {
            Ids = ["string"],

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void Url_Works()
    {
        EpisodeSaveParams parameters = new() { Ids = ["string"] };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(new Uri("https://api.spotify.com/v1/me/episodes"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EpisodeSaveParams { Ids = ["string"], Published = true };

        EpisodeSaveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
