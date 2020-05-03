using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Doctor : Person
    {
        public string clinicName { get; set; }
        public string cvr { get; set; }
        public string specialization { get; set; }
        public string address { get; set; }

        public Doctor(string doctorId, string ssn, string name, string phone,
            string email, string country, string city, string clinicName, string cvr, string specialization, string address) : base(doctorId, ssn, name, phone,
            email, country, city)
        {
            this.clinicName = clinicName;
            this.cvr = cvr;
            this.specialization = specialization;
            this.address = address;
        }

        public Doctor() : base() { }
    }
}
