using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _090221Task.Exception
{
    class ListEmptyException:ApplicationException
    {
        public ListEmptyException(string message):base(message)
        {
            
        }
    }
}
