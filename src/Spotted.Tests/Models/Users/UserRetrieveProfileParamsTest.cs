using System;
using Spotted.Models.Users;

namespace Spotted.Tests.Models.Users;

public class UserRetrieveProfileParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new UserRetrieveProfileParams { UserID = "smedjan" };

        string expectedUserID = "smedjan";

        Assert.Equal(expectedUserID, parameters.UserID);
    }

    [Fact]
    public void Url_Works()
    {
        UserRetrieveProfileParams parameters = new() { UserID = "smedjan" };

        var url = parameters.Url(new() { AccessToken = "My Access Token" });

        Assert.Equal(new Uri("https://api.spotify.com/v1/users/smedjan"), url);
    }
}
