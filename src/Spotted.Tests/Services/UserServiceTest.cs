using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class UserServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveProfile_Works()
    {
        var response = await this.client.Users.RetrieveProfile(
            "smedjan",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
