using Backend.DbModel;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public class DoctorDb : IDoctorDb
    {
        private readonly Context context;
        private readonly IDoctorAppointmentTimesDb datDb;
        public DoctorDb(Context context, IDoctorAppointmentTimesDb datDb)
        {
            this.context = context;
            this.datDb = datDb;
        }

        public async Task<Doctor> getDoctorByIdAsync(string id)
        {
            DbDoctor dbDoctor = await context.doctors.FindAsync(id);
            if (dbDoctor == null)
                return null;

            return dbDoctor.toDoctor();
        }

        public async Task<bool> putDoctorAsync(Doctor doctor)
        {
            DbDoctor dbDoctor = await context.doctors.FindAsync(doctor.personId);
            if (dbDoctor == null)
                return false;

            dbDoctor.fromDoctor(doctor);
            context.Entry(dbDoctor).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> postDoctorAsync(Doctor doctor)
        {
            DbDoctor dbDoctor = new DbDoctor();
            dbDoctor.fromDoctor(doctor);

            context.doctors.Add(dbDoctor);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public async Task deleteDoctorAsync(string doctorId)
        {
            var doctor = await context.doctors.FindAsync(doctorId);

            if (doctor == null)
            {
                return;
            }

            await datDb.deleteDAT(doctorId);

            context.doctors.Remove(doctor);
            await context.SaveChangesAsync();

        }

        public async Task<List<Doctor>> getDoctorsAsync()
        {
            List<DbDoctor> dbDoctors = await context.doctors.ToListAsync<DbDoctor>();
            List<Doctor> doctors = new List<Doctor>();
            foreach (DbDoctor d in dbDoctors)
                doctors.Add(d.toDoctor());

            return doctors;
        }

        public async Task<List<Doctor>> getSelectedDoctorsAsync(string specialization, string country, string city)
        {
            List<DbDoctor> dbDoctors = await context.doctors.Where(d => d.country == country && d.city == city && d.specialization == specialization).ToListAsync<DbDoctor>();
            List<Doctor> doctors = new List<Doctor>();
            foreach (DbDoctor d in dbDoctors)
                doctors.Add(d.toDoctor());

            return doctors;
        }
    }
}
