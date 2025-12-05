using System;

namespace Spotted.Exceptions;

public class SpottedInvalidDataException : SpottedException
{
    public SpottedInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
