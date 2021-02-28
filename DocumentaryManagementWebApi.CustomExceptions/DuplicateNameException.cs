using System;

namespace DocumentaryManagementWebApi.CustomExceptions
{
    public class DuplicateNameException : Exception
    {
        public DuplicateNameException(string message) : base(message) { 
            
        }
    }
}
