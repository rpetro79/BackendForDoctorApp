using Backend.DbModel;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public class DoctorAppointmentTimesDb : IDoctorAppointmentTimesDb
    {
        private readonly Context context;

        public DoctorAppointmentTimesDb(Context context)
        {
            this.context = context;
        }

        public async Task<List<long>> getAvailableTimesForDay(string doctorId, long day)
        {
            long oneDayInMiliseconds = 24 * 60 * 60 * 1000;
            List<Appointment> list = await context.appointments.Where(ap => ap.doctorId == doctorId && ap.datetime >= day && ap.datetime < (day + oneDayInMiliseconds)).ToListAsync<Appointment>();

            List<DbDoctorAppointmentTimes> times = await context.doctorAppointmentTimes.Where(t => t.doctorId == doctorId).ToListAsync<DbDoctorAppointmentTimes>();
            List<long> returnList = new List<long>();

            bool okay;
            foreach(DbDoctorAppointmentTimes dat in times)
            {
                long dayTime = dat.appointmentTime + day;
                okay = true;
                foreach(Appointment app in list)
                {
                    if (app.datetime == dayTime)
                    {
                        okay = false;
                        break;
                    }
                }
                if(okay)
                {
                    returnList.Add(dat.appointmentTime);
                }
            }
            returnList.Sort();
            return returnList;
        }

        public async Task<DoctorAppointmentTimes> getDoctorAppointmentTimes(string doctorId)
        {
            if (context.doctors.Find(doctorId) == null)
                return null;
            List<DbDoctorAppointmentTimes> times = await context.doctorAppointmentTimes.Where(t => t.doctorId == doctorId).ToListAsync<DbDoctorAppointmentTimes>();
            return new DoctorAppointmentTimes(doctorId, times);

        }

        public async Task<bool> postDAT(DoctorAppointmentTimes newTimes)
        {
            if (context.doctors.Find(newTimes.doctorId) == null)
                return false;

            foreach (long time in newTimes.appointmentTimes)
            {
                DbDoctorAppointmentTimes t = new DbDoctorAppointmentTimes();
                t.doctorId = newTimes.doctorId;
                t.appointmentTime = time;

                context.doctorAppointmentTimes.Add(t);
            }

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

        public async Task<bool> putDAT(DoctorAppointmentTimes newTimes)
        {
            if (!(await deleteDAT(newTimes.doctorId)))
                return false;

            return await postDAT(newTimes);
        }

        public async Task<bool> deleteDAT(string doctorId)
        {
            List<DbDoctorAppointmentTimes> current = await context.doctorAppointmentTimes.Where(dat => dat.doctorId == doctorId).ToListAsync<DbDoctorAppointmentTimes>();

            foreach(DbDoctorAppointmentTimes dat in current)
            {
                context.doctorAppointmentTimes.Remove(dat);
            }

            try
            {
                await context.SaveChangesAsync();
            }
            catch(DbUpdateException)
            {
                return false;
            }
            return true;
        }
    }
}
