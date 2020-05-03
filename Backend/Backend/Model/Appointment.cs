using Backend.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Appointment
    {
        [Key]
        public int appointmentId { get; set; }
        public string patientId { get; set; }
        public string doctorId { get; set; }
        public long datetime { get; set; }
        public string symptoms { get; set; }
        public string label { get; set; }
        public bool cancelled { get; set; }

        public void fromPatientAppointment(PatientAppointment app)
        {
            this.appointmentId = app.appointmentId;
            this.doctorId = app.doctor.personId;
            this.patientId = app.patientId;
            this.datetime = app.datetime;
            this.symptoms = app.symptoms;
            this.label = app.label;
            this.cancelled = app.cancelled;
        }

        public PatientAppointment toPatientAppointment(Doctor doctor)
        {
            return new PatientAppointment(appointmentId, doctor, patientId, datetime, symptoms, label, cancelled);
        }

        public void fromDoctorAppointment(DoctorAppointment app, string label)
        {
            this.appointmentId = app.appointmentId;
            this.doctorId = app.patient.personId;
            this.patientId = app.doctorId;
            this.datetime = app.datetime;
            this.symptoms = app.symptoms;
            this.label = label;
            this.cancelled = app.cancelled;
        }

        public DoctorAppointment toDoctorAppointment(Patient patient)
        {
            return new DoctorAppointment(appointmentId, patient, doctorId, datetime, symptoms, cancelled);
        }

        public Appointment() { }

        public Appointment(string patientId, string doctorId, long datetime, string symptoms, string label, bool cancelled) 
        {
            this.doctorId = doctorId;
            this.patientId = patientId;
            this.datetime = datetime;
            this.symptoms = symptoms;
            this.label = label;
            this.cancelled = cancelled;
        }

        public Appointment(int appointmentId, string patientId, string doctorId, long datetime, string symptoms, string label, bool cancelled)
        {
            this.appointmentId = appointmentId;
            this.doctorId = doctorId;
            this.patientId = patientId;
            this.datetime = datetime;
            this.symptoms = symptoms;
            this.label = label;
            this.cancelled = cancelled;
        }

        public void copy(Appointment app)
        {
            this.appointmentId = app.appointmentId;
            this.doctorId = app.doctorId;
            this.patientId = app.patientId;
            this.datetime = app.datetime;
            this.symptoms = app.symptoms;
            this.cancelled = app.cancelled;

            if (!(app.label == null || app.label.Length == 0))
                label = app.label;
        }
    }
}
