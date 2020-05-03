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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentDb appointmentDb;

        public AppointmentsController(IAppointmentDb appDb)
        {
            this.appointmentDb = appDb;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> getAppointments()
        {
            List<Appointment> apps = await appointmentDb.getAppointmentsAsync();
            if (apps == null)
                return NotFound();
            return apps;
        }

        [HttpPost]
        public async Task<ActionResult> postAppointment(Appointment appointment)
        {
            if (!(await appointmentDb.postAppointmentAsync(appointment)))
                return Conflict();

            return Accepted();
        }

        [HttpPut]
        public async Task<ActionResult> putAppointment(Appointment appointment)
        {
            bool x = await appointmentDb.putAppointmentAsync(appointment);
            if (x)
            {
                return Accepted();
            }

            return NotFound();
        }

        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult> deleteAppointment(int appointmentId)
        {
            await appointmentDb.deleteAppointmentAsync(appointmentId);
            return Ok();
        }
    }
}