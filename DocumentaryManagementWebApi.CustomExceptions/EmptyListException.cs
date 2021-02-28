using System;

namespace DocumentaryManagementWebApi.CustomExceptions
{
    public class EmptyListException : Exception
    {
        public EmptyListException(string message) : base(message)
        {
        }
    }
}