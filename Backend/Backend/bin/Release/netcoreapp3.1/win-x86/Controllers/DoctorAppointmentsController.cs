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
    public class DoctorAppointmentsController : ControllerBase
    {
        private readonly IDoctorAppointmentsDb db;

        public DoctorAppointmentsController(IDoctorAppointmentsDb db)
        {
            this.db = db;
        }


        [HttpGet("{appointmentId}")]
        public async Task<ActionResult<DoctorAppointment>> getDoctorAppointment(int appointmentId)
        {
            DoctorAppointment app = await db.getDoctorAppointmentAsync(appointmentId);
            if (app == null)
                return NotFound();
            return app;
        }

        [HttpGet("{doctorId}/day/{date}")]
        public async Task<ActionResult<List<DoctorAppointment>>> getAppointmentsOfDoctorPerDay(string doctorId, long date)
        {
            List<DoctorAppointment> apts = await db.getAppointmentsOfDoctorForDayAsync(doctorId, date);
            if (apts == null)
                return NotFound();
            return apts;
        }
    }
}