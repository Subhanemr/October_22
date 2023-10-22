using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_10_23.Exseptions
{
    //Task 3
    internal class WrongInputException : Exception
    {
        public WrongInputException(string masage) : base(masage) { }
    }
}
