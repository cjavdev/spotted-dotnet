using System.Collections.Generic;
using Spotted.Models.Playlists.Tracks;

namespace Spotted.Tests.Models.Playlists.Tracks;

public class TrackUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrackUpdateParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            InsertBefore = 3,
            Published = true,
            RangeLength = 2,
            RangeStart = 1,
            SnapshotID = "snapshot_id",
            Uris = ["string"],
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        long expectedInsertBefore = 3;
        bool expectedPublished = true;
        long expectedRangeLength = 2;
        long expectedRangeStart = 1;
        string expectedSnapshotID = "snapshot_id";
        List<string> expectedUris = ["string"];

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedInsertBefore, parameters.InsertBefore);
        Assert.Equal(expectedPublished, parameters.Published);
        Assert.Equal(expectedRangeLength, parameters.RangeLength);
        Assert.Equal(expectedRangeStart, parameters.RangeStart);
        Assert.Equal(expectedSnapshotID, parameters.SnapshotID);
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
        var parameters = new TrackUpdateParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        Assert.Null(parameters.InsertBefore);
        Assert.False(parameters.RawBodyData.ContainsKey("insert_before"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.RangeLength);
        Assert.False(parameters.RawBodyData.ContainsKey("range_length"));
        Assert.Null(parameters.RangeStart);
        Assert.False(parameters.RawBodyData.ContainsKey("range_start"));
        Assert.Null(parameters.SnapshotID);
        Assert.False(parameters.RawBodyData.ContainsKey("snapshot_id"));
        Assert.Null(parameters.Uris);
        Assert.False(parameters.RawBodyData.ContainsKey("uris"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TrackUpdateParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",

            // Null should be interpreted as omitted for these properties
            InsertBefore = null,
            Published = null,
            RangeLength = null,
            RangeStart = null,
            SnapshotID = null,
            Uris = null,
        };

        Assert.Null(parameters.InsertBefore);
        Assert.False(parameters.RawBodyData.ContainsKey("insert_before"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
        Assert.Null(parameters.RangeLength);
        Assert.False(parameters.RawBodyData.ContainsKey("range_length"));
        Assert.Null(parameters.RangeStart);
        Assert.False(parameters.RawBodyData.ContainsKey("range_start"));
        Assert.Null(parameters.SnapshotID);
        Assert.False(parameters.RawBodyData.ContainsKey("snapshot_id"));
        Assert.Null(parameters.Uris);
        Assert.False(parameters.RawBodyData.ContainsKey("uris"));
    }
}
