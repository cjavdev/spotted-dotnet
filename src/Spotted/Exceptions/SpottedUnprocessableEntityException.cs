using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedUnprocessableEntityException : Spotted4xxException
{
    public SpottedUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
