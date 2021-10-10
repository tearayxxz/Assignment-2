using System;
class Teacher : Person
    {
        private string employeeID;
        public Teacher(string name, string address, string citizenID, string employeeID)
        : base(name, address, citizenID)
        {
            this.employeeID = employeeID;
        }
    }