using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbModel
{
    public class DbDoctorAppointmentTimes
    {
        public string doctorId { get; set; }
        public long appointmentTime { get; set; }
    }
}
