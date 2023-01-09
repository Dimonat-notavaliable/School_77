using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School_77.Models
{
    public class Parent: Person
    {
        public virtual ICollection<Student> Kids { get; set; }
    }
}