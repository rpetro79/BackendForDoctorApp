using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public class AppointmentDb : IAppointmentDb
    {
        private readonly Context context;

        public AppointmentDb(Context context) 
        {
            this.context = context;
        }

        public async Task<Appointment> putAppointmentAsync(Appointment appointment)
        {
            Appointment dbApp = await context.appointments.FindAsync(appointment.appointmentId);
            if (dbApp == null)
                return null;

            dbApp.copy(appointment);
            context.Entry(dbApp).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return appointment;
        }

        public async Task<Appointment> postAppointmentAsync(Appointment appointment)
        {
            context.appointments.Add(appointment);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            List<Appointment> appointments = await context.appointments.Where(a => a.datetime == appointment.datetime && a.patientId == appointment.patientId && a.doctorId == appointment.doctorId).ToListAsync();
            if (appointments == null)
                return null;
            if (appointments.Count > 0)
                return appointments[0];

            return null;
        }

        public async Task deleteAppointmentAsync(int appintmentId)
        {
            var app = await context.appointments.FindAsync(appintmentId);

            if (app == null)
            {
                return;
            }

            context.appointments.Remove(app);
            await context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> getAppointmentsAsync()
        {
            return await context.appointments.ToListAsync<Appointment>();
        }
    }
}
