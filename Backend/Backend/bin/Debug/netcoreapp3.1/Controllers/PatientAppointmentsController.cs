using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DbManagement;
using Backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAppointmentsController : ControllerBase
    {
        private readonly IPatientAppointmentsDb db;

        public PatientAppointmentsController(IPatientAppointmentsDb db)
        {
            this.db = db;
        }

        [HttpGet("{appointmentId}")]
        public async Task<ActionResult<PatientAppointment>> getPatientAppointment(int appointmentId)
        {
            PatientAppointment app = await db.getPatientAppointmentAsync(appointmentId);
            if (app == null)
                return NotFound();
            return app;
        }

        [HttpGet("{patientId}/upcomingAppointments/{date}")]
        public async Task<ActionResult<List<PatientAppointment>>> getUpcomingAppointmentsOfPatient(string patientId, long date)
        {
            List<PatientAppointment> apts = await db.getAllUpcomingAppointmentsOfPatientAsync(patientId, date);
            if (apts == null)
                return NotFound();
            return apts;
        }

        [HttpGet("{patientId}/pastAppointments/{date}")]
        public async Task<ActionResult<List<PatientAppointment>>> getPastAppointmentsOfPatient(string patientId, long date)
        {
            List<PatientAppointment> apts = await db.getPastAppointmentsOfPatientAsync(patientId, date);
            if (apts == null)
                return NotFound();
            return apts;
        }
    }
}