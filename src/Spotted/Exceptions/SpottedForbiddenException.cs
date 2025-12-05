using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedForbiddenException : Spotted4xxException
{
    public SpottedForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
