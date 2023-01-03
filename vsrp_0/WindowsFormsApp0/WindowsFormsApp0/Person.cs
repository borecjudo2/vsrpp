using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp0
{
    public class Person
    {
        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastNameAndFatherName { get; set; }

        public Person(Guid id, string firstName, string lastNameAndFatherName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastNameAndFatherName = lastNameAndFatherName;
        }
    }
}
