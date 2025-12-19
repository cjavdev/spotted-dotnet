using Spotted.Models.Playlists;

namespace Spotted.Tests.Models.Playlists;

public class PlaylistRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlaylistRetrieveParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            AdditionalTypes = "additional_types",
            Fields = "items(added_by.id,track(name,href,album(name,href)))",
            Market = "ES",
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        string expectedAdditionalTypes = "additional_types";
        string expectedFields = "items(added_by.id,track(name,href,album(name,href)))";
        string expectedMarket = "ES";

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedAdditionalTypes, parameters.AdditionalTypes);
        Assert.Equal(expectedFields, parameters.Fields);
        Assert.Equal(expectedMarket, parameters.Market);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlaylistRetrieveParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        Assert.Null(parameters.AdditionalTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("additional_types"));
        Assert.Null(parameters.Fields);
        Assert.False(parameters.RawQueryData.ContainsKey("fields"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlaylistRetrieveParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",

            // Null should be interpreted as omitted for these properties
            AdditionalTypes = null,
            Fields = null,
            Market = null,
        };

        Assert.Null(parameters.AdditionalTypes);
        Assert.False(parameters.RawQueryData.ContainsKey("additional_types"));
        Assert.Null(parameters.Fields);
        Assert.False(parameters.RawQueryData.ContainsKey("fields"));
        Assert.Null(parameters.Market);
        Assert.False(parameters.RawQueryData.ContainsKey("market"));
    }
}
