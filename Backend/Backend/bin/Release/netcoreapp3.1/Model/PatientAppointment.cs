using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class PatientAppointment
    {
        public int appointmentId { get; set; }
        public Doctor doctor { get; set; }
        public string patientId { get; set; }
        public long datetime { get; set; }
        public string symptoms { get; set; }
        public string label { get; set; }
        public bool cancelled { get; set; }

        public PatientAppointment(int appointmentId, Doctor doctor, string patientId, long datetime, string symptoms, string label, bool cancelled)
        {
            this.appointmentId = appointmentId;
            this.doctor = doctor;
            this.patientId = patientId;
            this.datetime = datetime;
            this.symptoms = symptoms;
            this.label = label;
            this.cancelled = cancelled;
        }

        public PatientAppointment(Doctor doctor, string patientId, long datetime, string symptoms, string label, bool cancelled)
        {
            this.doctor = doctor;
            this.patientId = patientId;
            this.datetime = datetime;
            this.symptoms = symptoms;
            this.label = label;
            this.cancelled = cancelled;
        }

        public PatientAppointment()
        {
        }
    }
}
