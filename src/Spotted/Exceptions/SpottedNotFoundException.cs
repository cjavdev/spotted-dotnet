using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedNotFoundException : Spotted4xxException
{
    public SpottedNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
