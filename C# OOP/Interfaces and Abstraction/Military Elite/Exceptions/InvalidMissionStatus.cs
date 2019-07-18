using System;

namespace _08MilitaryElite.Exceptions
{
    public class InvalidMissionStatus : Exception
    {
        private const string EXCEPTION_MESSAGE = "You cannot finish already finished mission.";

        public InvalidMissionStatus()
            :base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidMissionStatus(string message) 
            : base(message)
        {

        }
    }
}
