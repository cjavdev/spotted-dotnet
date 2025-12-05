using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedRateLimitException : Spotted4xxException
{
    public SpottedRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
