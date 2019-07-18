using System;

namespace _08MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid corps";

        public InvalidCorpsException()
            : base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
    }
}
