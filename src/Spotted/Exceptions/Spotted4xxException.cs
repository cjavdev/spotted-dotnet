using System.Net.Http;

namespace Spotted.Exceptions;

public class Spotted4xxException : SpottedApiException
{
    public Spotted4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
