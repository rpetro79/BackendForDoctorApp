using Backend.DbModel;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DbManagement
{
    public class PatientDb : IPatientDb
    {
        private readonly Context context; 
        public PatientDb(Context context)
        {
            this.context = context;
        }

        public async Task<Patient> getPatientByIdAsync(string id)
        {
            DbPatient dbPatient = await context.patients.FindAsync(id);
            if (dbPatient == null)
                return null;

            return dbPatient.toPatient();
        }

        public async Task<Patient> getPatientBySSNAsync(string ssn)
        {
            List<DbPatient> dbPatients = await context.patients.Where(p => p.ssn == ssn).ToListAsync();
            if (dbPatients == null)
                return null;

            return dbPatients[0].toPatient();
        }

        public async Task<bool> putPatientAsync(Patient patient)
        {
            DbPatient dbPatient = await context.patients.FindAsync(patient.personId);
            if (dbPatient == null)
                return false;

            dbPatient.fromPatient(patient);
            context.Entry(dbPatient).State = EntityState.Modified;
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

        public async Task<bool> postPatientAsync(Patient patient)
        {
            DbPatient dbPatient = new DbPatient();
            dbPatient.fromPatient(patient);

            context.patients.Add(dbPatient);

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

        public async Task deletePatientAsync(string patientId)
        {
            var patient = await context.patients.FindAsync(patientId);
            
            if (patient == null)
            {
                return;
            }

            context.patients.Remove(patient);
            await context.SaveChangesAsync();

        }

        public async Task<List<Patient>> getPatientsAsync()
        {
            List<DbPatient> dbPatients = await context.patients.ToListAsync<DbPatient>();
            List<Patient> patients = new List<Patient>();
            foreach (DbPatient p in dbPatients)
                patients.Add(p.toPatient());

            return patients;
        }
    }
}
