using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbModel
{
    public class Specialization
    {
        [Key]
        public string name { get; set; }

        public Specialization() { }
        public Specialization(string name) 
        {
            this.name = name;
        }
    }
}
