using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Patient : Person
    {
        public long birthday { get; set; }

        public Patient(string patientId, string ssn, string name, string phone,
            string email, string country, string city, long birthday) : base(patientId, ssn, name, phone,
            email, country, city)
        {
            this.birthday = birthday;
        }

        public Patient() : base() { }
    }
}
