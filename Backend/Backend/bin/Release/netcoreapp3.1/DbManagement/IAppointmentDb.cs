using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public interface IAppointmentDb
    {
        Task<Appointment> putAppointmentAsync(Appointment appointment);

        Task<Appointment> postAppointmentAsync(Appointment appointment);

        Task deleteAppointmentAsync(int appintmentId);

        Task<List<Appointment>> getAppointmentsAsync();
    }
}
