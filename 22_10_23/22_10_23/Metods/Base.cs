using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_10_23.Metods
{
    //Task 3
    internal abstract class Base
    {
        private static int _idCounter = 0;
        public int Id = 1;
        public string Name { get; set; }
        public Base(string name)
        {
            Id = ++_idCounter;
            Name = name;
        }
    }
}
