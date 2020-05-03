using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Person
    {
        [Key]
        public string personId { get; set; }
        public string ssn { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public string city { get; set; }

        public Person(string personId, string ssn, string name, string phone,
            string email, string country, string city)
        {
            this.personId = personId;
            this.ssn = ssn;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.country = country;
            this.city = city;
        }

        public Person() { }
    }
}
