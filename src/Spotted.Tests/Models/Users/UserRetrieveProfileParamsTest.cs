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
}
