using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestProject.Client
{
    public class Tasks
    {
        public required string Title { get; set; }

        public required Person Handler { get; set; }
    }

    public class Person
    {
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Function { get; set; }
    }
}
