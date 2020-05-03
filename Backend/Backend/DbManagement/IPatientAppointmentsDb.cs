using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public interface IPatientAppointmentsDb
    {
        Task<PatientAppointment> getPatientAppointmentAsync(int appointmentId);

        Task<List<PatientAppointment>> getAllUpcomingAppointmentsOfPatientAsync(String patientId, long date);

        Task<List<PatientAppointment>> getPastAppointmentsOfPatientAsync(String patientId, long date);

        
    }
}
