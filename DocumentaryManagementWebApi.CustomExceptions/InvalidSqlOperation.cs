using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentaryManagementWebApi.CustomExceptions
{
    public class InvalidSqlOperation : Exception
    {
        public InvalidSqlOperation(string message) : base(message) { 
        
        }
    }
}
