using Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbModel
{
    public class DbCredentials
    {
        public int personId { get; set; }
        [Key]
        public string SSN { get; set; }
        public string password { get; set; }

        internal void fromCredentials(Credentials credentials, int id)
        {
            this.SSN = credentials.SSN;
            this.password = credentials.password;
            this.personId = id;
        }
    }
}
