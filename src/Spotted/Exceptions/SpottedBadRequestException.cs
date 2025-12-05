using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedBadRequestException : Spotted4xxException
{
    public SpottedBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
