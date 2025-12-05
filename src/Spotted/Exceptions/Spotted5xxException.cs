using System.Net.Http;

namespace Spotted.Exceptions;

public class Spotted5xxException : SpottedApiException
{
    public Spotted5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
