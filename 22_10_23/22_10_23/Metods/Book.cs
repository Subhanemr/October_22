using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22_10_23.Metods
{
    //Task 3
    internal class Book: Base
    {
        public string Author { get; }
        public Category Category { get; }
        public Book(string name, string author, Category category) : base(name)
        {
            Author = author;
            Category = category;
        }
    }
}
