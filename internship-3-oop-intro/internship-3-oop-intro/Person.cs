using System;
using System.Collections.Generic;
using System.Text;

namespace internship_3_oop_intro
{
    public class Person
    {
        public Person(string firstName,string lastName,string oIB,string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            OIB = oIB;
            PhoneNumber = phoneNumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OIB { get; set; }
        public string PhoneNumber { get; set; }
    }
}
