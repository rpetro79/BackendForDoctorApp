using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public interface IDoctorDb
    {
        Task<List<Doctor>> getDoctorsAsync();

        Task<List<Doctor>> getSelectedDoctorsAsync(string specialization, string country, string city);

        Task<Doctor> getDoctorByIdAsync(string id);

        Task<bool> putDoctorAsync(Doctor doctor);

        Task<bool> postDoctorAsync(Doctor doctor);

        Task deleteDoctorAsync(string doctorId);
    }
}
