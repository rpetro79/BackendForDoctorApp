using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public interface IPatientDb
    {
        Task<Patient> getPatientByIdAsync(string id);

        Task<Patient> getPatientBySSNAsync(string ssn);

        Task<bool> putPatientAsync(Patient patient);

        Task<bool> postPatientAsync(Patient patient);

        Task deletePatientAsync(string patientId);

        Task<List<Patient>> getPatientsAsync();
    }
}
