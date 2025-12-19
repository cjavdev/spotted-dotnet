using Spotted.Models.Users.Playlists;

namespace Spotted.Tests.Models.Users.Playlists;

public class PlaylistCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlaylistCreateParams
        {
            UserID = "smedjan",
            Name = "New Playlist",
            Collaborative = true,
            Description = "New playlist description",
            Published = true,
        };

        string expectedUserID = "smedjan";
        string expectedName = "New Playlist";
        bool expectedCollaborative = true;
        string expectedDescription = "New playlist description";
        bool expectedPublished = true;

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedCollaborative, parameters.Collaborative);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedPublished, parameters.Published);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlaylistCreateParams { UserID = "smedjan", Name = "New Playlist" };

        Assert.Null(parameters.Collaborative);
        Assert.False(parameters.RawBodyData.ContainsKey("collaborative"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlaylistCreateParams
        {
            UserID = "smedjan",
            Name = "New Playlist",

            // Null should be interpreted as omitted for these properties
            Collaborative = null,
            Description = null,
            Published = null,
        };

        Assert.Null(parameters.Collaborative);
        Assert.False(parameters.RawBodyData.ContainsKey("collaborative"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }
}
