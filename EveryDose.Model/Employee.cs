using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDose.Model
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                FullName = value;
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                FullName = FullName + " " + value;
            }
        }
        public string Dob { get; set; }

        
        private string _fullName;
        [Ignore]
        public string FullName
        {
            get { return _fullName; }
            set
            { 
                _fullName = value; 
            }
        }

    }
}
