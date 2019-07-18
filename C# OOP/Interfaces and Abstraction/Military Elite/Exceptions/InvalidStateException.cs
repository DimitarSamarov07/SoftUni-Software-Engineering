using System;

namespace _08MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid state!";

        public InvalidStateException()
            : base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidStateException(string message) 
            : base(message)
        {

        }
    }
}
