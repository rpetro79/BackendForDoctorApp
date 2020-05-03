using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public class DoctorAppointmentsDb : IDoctorAppointmentsDb
    {
        private readonly Context context;
        private readonly IPatientDb patientDb;

        public DoctorAppointmentsDb(Context context, IPatientDb patientDb)
        {
            this.context = context;
            this.patientDb = patientDb;
        }

        public async Task<DoctorAppointment> getDoctorAppointmentAsync(int appointmentId)
        {
            Appointment dbApp = await context.appointments.FindAsync(appointmentId);

            if (dbApp == null)
                return null;

            Patient p = await patientDb.getPatientByIdAsync(dbApp.patientId);

            if (p == null)
                return null;

            return dbApp.toDoctorAppointment(p);
        }

        public async Task<List<DoctorAppointment>> getAppointmentsOfDoctorForDayAsync(String doctorId, long day)
        {
            long oneDayInMiliseconds = 24 * 60 * 60 * 1000;
            List<Appointment> list = await context.appointments.Where(ap => ap.doctorId == doctorId && ap.datetime >= day && ap.datetime < (day+oneDayInMiliseconds)).ToListAsync<Appointment>();
            List<DoctorAppointment> returnList = new List<DoctorAppointment>();

            foreach (Appointment ap in list)
            {
                Patient patient = await patientDb.getPatientByIdAsync(ap.patientId);
                returnList.Add(ap.toDoctorAppointment(patient));
            }

            return returnList;
        }
    }
}
