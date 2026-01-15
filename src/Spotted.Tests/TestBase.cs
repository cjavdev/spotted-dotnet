using System;
using Spotted;

namespace Spotted.Tests;

public class TestBase
{
    protected ISpottedClient client;

    public TestBase()
    {
        client = new SpottedClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            AccessToken = "My Access Token",
        };
    }
}
