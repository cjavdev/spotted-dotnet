using System;
using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedException : Exception
{
    public SpottedException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected SpottedException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
