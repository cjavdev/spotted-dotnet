using System.Collections.Generic;
using Spotted.Models.Playlists.Tracks;

namespace Spotted.Tests.Models.Playlists.Tracks;

public class TrackAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrackAddParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Position = 0,
            Published = true,
            Uris = ["string"],
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        long expectedPosition = 0;
        bool expectedPublished = true;
        List<string> expectedUris = ["string"];

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedPosition, parameters.Position);
        Assert.Equal(expectedPublished, parameters.Published);
        Assert.NotNull(parameters.Uris);
        Assert.Equal(expectedUris.Count, parameters.Uris.Count);
        for (int i = 0; i < expectedUris.Count; i++)
        {
            Assert.Equal(expectedUris[i], parameters.Uris[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TrackAddParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        Assert.Null(parameters.Position);
        Assert.False(parameters.RawBodyData.ContainsKey("position"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.Uris);
        Assert.False(parameters.RawBodyData.ContainsKey("uris"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TrackAddParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",

            // Null should be interpreted as omitted for these properties
            Position = null,
            Published = null,
            Uris = null,
        };

        Assert.Null(parameters.Position);
        Assert.False(parameters.RawBodyData.ContainsKey("position"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.Uris);
        Assert.False(parameters.RawBodyData.ContainsKey("uris"));
    }
}
