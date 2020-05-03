using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public interface IDoctorAppointmentsDb
    {
        Task<DoctorAppointment> getDoctorAppointmentAsync(int appointmentId);
        Task<List<DoctorAppointment>> getAppointmentsOfDoctorForDayAsync(String doctorId, long day);
    }
}
