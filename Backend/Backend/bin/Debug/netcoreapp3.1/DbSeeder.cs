using Backend.DbManagement;
using Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class DbSeeder
    {
        public static async Task initAsync(ISpecializationsDb specializationsDb, IDoctorDb doctorDb, IDoctorAppointmentTimesDb datDb, Context context)
        {
            if(!context.specializations.Any())
            {
                await specializationsDb.postSpecializationAsync("Family Physician");
                await specializationsDb.postSpecializationAsync("Internal Medicine Physician");
                await specializationsDb.postSpecializationAsync("Pediatrician");
                await specializationsDb.postSpecializationAsync("Obstetrician/Gynecologist");
                await specializationsDb.postSpecializationAsync("Surgeon");
                await specializationsDb.postSpecializationAsync("Psychiatrist");
                await specializationsDb.postSpecializationAsync("Cardiologist");
                await specializationsDb.postSpecializationAsync("Dermatologist");
                await specializationsDb.postSpecializationAsync("Endocrinologist");
                await specializationsDb.postSpecializationAsync("Gastroenterologist");
                await specializationsDb.postSpecializationAsync("Infectious Disease Physician");
                await specializationsDb.postSpecializationAsync("Nephrologist");
                await specializationsDb.postSpecializationAsync("Ophthalmologist");
                await specializationsDb.postSpecializationAsync("Otolaryngologist");
                await specializationsDb.postSpecializationAsync("Pulmonologist");
                await specializationsDb.postSpecializationAsync("Neurologist");
                await specializationsDb.postSpecializationAsync("Physician Executive");
                await specializationsDb.postSpecializationAsync("Radiologist");
                await specializationsDb.postSpecializationAsync("Anesthesiologist");
                await specializationsDb.postSpecializationAsync("Oncologist");
                await specializationsDb.postSpecializationAsync("Dentist");
            }

            if(!context.doctors.Any())
            {
                Doctor d1 = new Doctor("12345678", "12345678", "John Smith", "01472583", "john@smithsc.com", "Denmark", "Horsens", "Smith's smile center", "789654123", "Dentist", "Sundvej 5");
                Doctor d2 = new Doctor("96385274", "96385274", "Jack Petersen", "11452143", "jackp@gmail.com", "Denmark", "Horsens", "Cardiocenter", "14523698", "Cardiologist", "Norregade 14");
                Doctor d3 = new Doctor("987456321", "987456321", "Mary Jackson", "55847699", "maryjack@gmail.com", "Denmark", "Aarhus", "Younglife", "77889944", "Pediatrician", "Klostergade 12");

                await doctorDb.postDoctorAsync(d1);
                await doctorDb.postDoctorAsync(d2);
                await doctorDb.postDoctorAsync(d3);
            }

            if(!context.doctorAppointmentTimes.Any())
            {
                DoctorAppointmentTimes dat1 = new DoctorAppointmentTimes("12345678", new List<long> {
                    28800000,
                    30600000,
                    32400000,
                    36000000,
                    37800000,
                    39600000,
                    41400000,
                    43200000,
                    45000000,
                    46800000,
                    50400000,
                    52200000,
                    54000000,
                    55800000,
                    57600000,
                    59400000,
                    61200000,
                    63000000 });

                DoctorAppointmentTimes dat2 = new DoctorAppointmentTimes("96385274", new List<long> {
                    28800000,
                    30600000,
                    32400000,
                    36000000,
                    37800000,
                    39600000,
                    41400000,
                    43200000,
                    45000000,
                    46800000,
                    50400000,
                    52200000,
                    54000000,
                    55800000,
                    57600000,
                    59400000,
                    61200000,
                    63000000 });

                DoctorAppointmentTimes dat3 = new DoctorAppointmentTimes("987456321", new List<long> {
                    28800000,
                    30600000,
                    32400000,
                    36000000,
                    37800000,
                    39600000,
                    41400000,
                    43200000,
                    45000000,
                    46800000,
                    50400000,
                    52200000,
                    54000000,
                    55800000,
                    57600000,
                    59400000,
                    61200000,
                    63000000 });

                await datDb.postDAT(dat1.doctorId, dat1.appointmentTimes);
                await datDb.postDAT(dat2.doctorId, dat2.appointmentTimes);
                await datDb.postDAT(dat3.doctorId, dat3.appointmentTimes);
            }
            
        }
    }
}
