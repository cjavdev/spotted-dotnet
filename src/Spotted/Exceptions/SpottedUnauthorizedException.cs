using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedUnauthorizedException : Spotted4xxException
{
    public SpottedUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
