using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2023_Task3_DroneSimulator.Exceptions
{
    public class CustomException: Exception
    {
        public CustomException() 
        {

        }

        public CustomException(String message): base(message)
        {

        }

        public CustomException(string message, Exception inner)
       : base(message, inner) { }
    }
}
