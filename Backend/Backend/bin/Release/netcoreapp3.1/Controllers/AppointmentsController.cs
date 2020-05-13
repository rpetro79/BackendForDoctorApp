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
        public async Task<ActionResult<Appointment>> postAppointment(Appointment appointment)
        {
            Appointment ap = await appointmentDb.postAppointmentAsync(appointment);
            if (ap == null)
                return Conflict();

            return ap;
        }

        [HttpPut]
        public async Task<ActionResult<Appointment>> putAppointment(Appointment appointment)
        {
            Appointment ap = await appointmentDb.putAppointmentAsync(appointment);
            if (ap == null)
            {
                return NotFound(); 
            }

            return ap;
        }

        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult> deleteAppointment(int appointmentId)
        {
            await appointmentDb.deleteAppointmentAsync(appointmentId);
            return Ok();
        }
    }
}