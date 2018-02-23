using System;

namespace StringCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException()
        {
        }

        public NegativesNotAllowedException(string message) : base(message)
        {
        }

        public NegativesNotAllowedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
