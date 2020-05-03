using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.DbManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorDb doctorDb;

        public DoctorsController(IDoctorDb doctorDb)
        {
            this.doctorDb = doctorDb;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> getDoctors()
        {
            List<Doctor> d = await doctorDb.getDoctorsAsync();
            if (d == null)
                return NotFound();
            return d;
        }

        [HttpGet("{specialization}/{country}/{city}")]
        public async Task<ActionResult<List<Doctor>>> getDoctorsInCity(string specialization, string country, string city)
        {
            List<Doctor> d = await doctorDb.getSelectedDoctorsAsync(specialization, country, city);
            if (d == null)
                return NotFound();
            return d;
        }

        [HttpGet("{doctorId}")]
        public async Task<ActionResult<Doctor>> getDoctor(string doctorId)
        {
            Doctor d = await doctorDb.getDoctorByIdAsync(doctorId);
            if (d == null)
                return NotFound();
            return d;
        }

        [HttpPut]
        public async Task<ActionResult> putDoctor(Doctor doctor)
        {
            bool x = await doctorDb.putDoctorAsync(doctor);
            if (x)
            {
                return Accepted();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> postDoctor(Doctor doctor)
        {
            if (!(await doctorDb.postDoctorAsync(doctor)))
                return Conflict();

            return Accepted();
        }

        [HttpDelete("{doctorId}")]
        public async Task deleteDoctor(string doctorId)
        {
            await doctorDb.deleteDoctorAsync(doctorId);
        }
    }
}