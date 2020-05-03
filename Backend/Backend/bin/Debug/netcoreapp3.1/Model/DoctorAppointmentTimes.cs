using Backend.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class DoctorAppointmentTimes
    {
        public string doctorId { get; set; }
        public List<long> appointmentTimes { get; set; }

        public DoctorAppointmentTimes() { }

        public DoctorAppointmentTimes(string doctorId, List<long> appointmentTimes)
        {
            this.doctorId = doctorId;
            this.appointmentTimes = appointmentTimes;
        }

        public DoctorAppointmentTimes(string doctorId, List<DbDoctorAppointmentTimes> appointmentTimes)
        {
            this.doctorId = doctorId;
            this.appointmentTimes = new List<long>();
            foreach(DbDoctorAppointmentTimes t in appointmentTimes)
            {
                this.appointmentTimes.Add(t.appointmentTime);
            }
            this.appointmentTimes.Sort();
        }
    }
}
