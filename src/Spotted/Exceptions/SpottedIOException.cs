using System;
using System.Net.Http;

namespace Spotted.Exceptions;

public class SpottedIOException : SpottedException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public SpottedIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
