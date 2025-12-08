using System.Threading.Tasks;

namespace Spotted.Tests.Services;

public class MeServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var me = await this.client.Me.Retrieve();
        me.Validate();
    }
}
