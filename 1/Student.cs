using System;

class Student : Person
    {
        private string studentID;
        public Student(string name, string address, string citizenID, string studentID)
        : base(name, address, citizenID)
        {
            this.studentID = studentID;
        }
    }