using System;

namespace DocumentaryManagementWebApi.CustomExceptions
{
    public class InvalidActorIdException : Exception
    {
        public InvalidActorIdException(string message) : base(message)
        {
        }
    }
}