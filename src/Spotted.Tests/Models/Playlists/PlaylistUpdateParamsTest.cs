using Spotted.Models.Playlists;

namespace Spotted.Tests.Models.Playlists;

public class PlaylistUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlaylistUpdateParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",
            Collaborative = true,
            Description = "Updated playlist description",
            Name = "Updated Playlist Name",
            Published = true,
        };

        string expectedPlaylistID = "3cEYpjA9oz9GiPac4AsH4n";
        bool expectedCollaborative = true;
        string expectedDescription = "Updated playlist description";
        string expectedName = "Updated Playlist Name";
        bool expectedPublished = true;

        Assert.Equal(expectedPlaylistID, parameters.PlaylistID);
        Assert.Equal(expectedCollaborative, parameters.Collaborative);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPublished, parameters.Published);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlaylistUpdateParams { PlaylistID = "3cEYpjA9oz9GiPac4AsH4n" };

        Assert.Null(parameters.Collaborative);
        Assert.False(parameters.RawBodyData.ContainsKey("collaborative"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlaylistUpdateParams
        {
            PlaylistID = "3cEYpjA9oz9GiPac4AsH4n",

            // Null should be interpreted as omitted for these properties
            Collaborative = null,
            Description = null,
            Name = null,
            Published = null,
        };

        Assert.Null(parameters.Collaborative);
        Assert.False(parameters.RawBodyData.ContainsKey("collaborative"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }
}
