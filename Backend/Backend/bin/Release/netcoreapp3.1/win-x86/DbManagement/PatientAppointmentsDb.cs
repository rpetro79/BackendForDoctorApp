using Backend.DbModel;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public class PatientAppointmentsDb : IPatientAppointmentsDb
    {
        private readonly Context context;
        private readonly IDoctorDb doctorDb;

        public PatientAppointmentsDb(Context context, IDoctorDb doctorDb)
        {
            this.context = context;
            this.doctorDb = doctorDb;
        }

        public async Task<PatientAppointment> getPatientAppointmentAsync(int appointmentId)
        {
            Appointment dbApp = await context.appointments.FindAsync(appointmentId);

            if (dbApp == null)
                return null;

            Doctor doctor = await doctorDb.getDoctorByIdAsync(dbApp.doctorId);

            if (doctor == null)
                return null;

            return dbApp.toPatientAppointment(doctor);
        }

        public async Task<List<PatientAppointment>> getAllUpcomingAppointmentsOfPatientAsync(String patientId, long date)
        {
            List<Appointment> list = await context.appointments.Where(ap => ap.patientId == patientId && ap.datetime >= date).ToListAsync<Appointment>();
            List<PatientAppointment> returnList = new List<PatientAppointment>();

            foreach(Appointment ap in list)
            {
                Doctor doctor = await doctorDb.getDoctorByIdAsync(ap.doctorId);
                returnList.Add(ap.toPatientAppointment(doctor));
            }
            
            return returnList;
        }

        public async Task<List<PatientAppointment>> getPastAppointmentsOfPatientAsync(String patientId, long date)
        {
            List<Appointment> list = await context.appointments.Where(ap => ap.patientId == patientId && ap.datetime < date).ToListAsync<Appointment>();
            List<PatientAppointment> returnList = new List<PatientAppointment>();

            foreach (Appointment ap in list)
            {
                Doctor doctor = await doctorDb.getDoctorByIdAsync(ap.doctorId);
                returnList.Add(ap.toPatientAppointment(doctor));
            }

            return returnList;
        }
    }
}
