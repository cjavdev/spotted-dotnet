using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedUnexpectedStatusCodeException : SpottedApiException
{
    public SpottedUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
