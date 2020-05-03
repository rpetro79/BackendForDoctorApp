using Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbModel
{
    public class DbPatient
    {
        [Key]
        public string patientId { get; set; }
        public string ssn { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public long birthday { get; set; }

        public Patient toPatient()
        {
            return new Patient(patientId, ssn, name, phone,
            email, country, city, birthday);
        }

        public void fromPatient(Patient patient)
        {
            this.patientId = patient.personId;
            this.ssn = patient.ssn;
            this.name = patient.name;
            this.phone = patient.phone;
            this.email = patient.email;
            this.country = patient.country;
            this.city = patient.city;
            this.birthday = patient.birthday;
        }
    }
}
