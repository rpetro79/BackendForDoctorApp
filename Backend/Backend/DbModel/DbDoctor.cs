using Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbModel
{
    public class DbDoctor
    {
        [Key]
        public string doctorId { get; set; }
        public string ssn { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string clinicName { get; set; }
        public string cvr { get; set; }
        public string specialization { get; set; }
        public string address { get; set; }

        public Doctor toDoctor()
        {
            return new Doctor(doctorId, ssn, name, phone,
            email, country, city, clinicName, cvr, specialization, address);
        }

        public void fromDoctor(Doctor doctor)
        {
            this.doctorId = doctor.personId;
            this.ssn = doctor.ssn;
            this.name = doctor.name;
            this.phone = doctor.phone;
            this.email = doctor.email;
            this.country = doctor.country;
            this.city = doctor.city;
            this.clinicName = doctor.clinicName;
            this.cvr = doctor.cvr;
            this.specialization = doctor.specialization;
            this.address = doctor.address;
        }
    }
}
