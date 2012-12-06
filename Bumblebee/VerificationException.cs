using System;

namespace Bumblebee
{
    public class VerificationException : Exception
    {
        public VerificationException(string message) : base(message)
        {
        }
    }
}
