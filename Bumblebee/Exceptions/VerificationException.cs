using System;

namespace Bumblebee.Exceptions
{
    public class VerificationException : Exception
    {
        public VerificationException(string message) : base(message)
        {
        }
    }
}
