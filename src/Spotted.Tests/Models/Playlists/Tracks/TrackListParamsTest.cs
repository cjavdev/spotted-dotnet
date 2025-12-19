using Spotted.Models.Playlists.Tracks;

namespace Spotted.Tests.Models.Playlists.Tracks;

public class TrackListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TrackListParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            AdditionalTypes = "additional_types",
            Fields = "items(added_by.id,track(name,href,album(name,href)))",
            Limit = 10,
            Market = "ES",
            Offset = 5,
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        string expectedAdditionalTypes = "additional_types";
        string expectedFields = "items(added_by.id,track(name,href,album(name,href)))";
        long expectedLimit = 10;
        string expectedMarket = "ES";
        long expectedOffset = 5;

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedAdditionalTypes, parameters.AdditionalTypes);
        Assert.Equal(expectedFields, parameters.Fields);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedMarket, parameters.Market);
        Assert.Equal(expectedOffset, parameters.Offset);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TrackListParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        Assert.Null(parameters.AdditionalTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("additional_types"));
        Assert.Null(parameters.Fields);
        Assert.False(parameters.RawQueryData.ContainsKey("fields"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TrackListParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",

            // Null should be interpreted as omitted for these properties
            AdditionalTypes = null,
            Fields = null,
            Limit = null,
            Market = null,
            Offset = null,
        };

        Assert.Null(parameters.AdditionalTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("additional_types"));
        Assert.Null(parameters.Fields);
        Assert.False(parameters.RawQueryData.ContainsKey("fields"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
        Assert.Null(parameters.Offset);
        Assert.False(parameters.RawQueryData.ContainsKey("offset"));
    }
}
