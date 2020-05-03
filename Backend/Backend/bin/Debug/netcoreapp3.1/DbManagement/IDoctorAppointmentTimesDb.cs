using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public interface IDoctorAppointmentTimesDb
    {
        Task<List<long>> getAvailableTimesForDay(string doctorId, long day);

        Task<DoctorAppointmentTimes> getDoctorAppointmentTimes(string doctorId);

        Task<bool> putDAT(DoctorAppointmentTimes newTimes);

        Task<bool> postDAT(String doctorId, List<long> newTimes);

        Task<bool> deleteDAT(string doctorId);
    }
}
