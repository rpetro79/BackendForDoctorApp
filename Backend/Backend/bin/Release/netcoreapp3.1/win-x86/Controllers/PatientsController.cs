using Backend.DbManagement;
using Backend.DbModel;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientDb patientDb;

        public PatientsController(IPatientDb patientDb)
        {
            this.patientDb = patientDb;
        }

        [HttpGet("surprize")]
        public async Task<ActionResult<string>> getNiceMessage()
        {
            return "Hello there :)";
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> getPatients()
        {
            List<Patient> p = await patientDb.getPatientsAsync();
            if (p == null)
                return NotFound();
            return p;
        }

        [HttpGet("{patientId}")]
        public async Task<ActionResult<Patient>> getPatient(string patientId)
        {
            Patient p = await patientDb.getPatientByIdAsync(patientId);
            if (p == null)
                return NotFound();
            return p;
        }

        [HttpPut]
        public async Task<ActionResult> putPatient(Patient patient)
        {
            bool x = await patientDb.putPatientAsync(patient);
            if (x)
            {
                return Accepted();
            }
            
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> postPatient(Patient patient)
        {
            if (!(await patientDb.postPatientAsync(patient)))
                return Conflict();

            return Accepted();
        }

        [HttpDelete("{patientId}")]
        public async Task deletePatient(string patientId)
        {
            await patientDb.deletePatientAsync(patientId);
        }
    }
}
