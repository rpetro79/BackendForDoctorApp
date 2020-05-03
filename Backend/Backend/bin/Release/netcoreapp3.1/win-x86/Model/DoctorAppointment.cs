using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class DoctorAppointment
    {
        public int appointmentId { get; set; }
        public Patient patient { get; set; }
        public string doctorId { get; set; }
        public long datetime { get; set; }
        public string symptoms { get; set; }
        public bool cancelled { get; set; }

        public DoctorAppointment(int appointmentId, Patient patient, string doctorId, long datetime, string symptoms, bool cancelled)
        {
            this.appointmentId = appointmentId;
            this.doctorId = doctorId;
            this.patient = patient;
            this.datetime = datetime;
            this.symptoms = symptoms;
            this.cancelled = cancelled;
        }
    }
}
