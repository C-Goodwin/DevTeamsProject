using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class Developer
    {
        public string Name { get; set; }

        public int EmployeeID { get; set; }

        public bool PluralsightAccess { get; set; }

        public Developer() { }

        public Developer(string name, int id, bool access)
        {
            Name = name;
            EmployeeID = id;
            PluralsightAccess = access;
        }
    }
}