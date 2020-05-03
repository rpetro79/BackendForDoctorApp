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
    public class DoctorAppointmentTimesController : ControllerBase
    {
        private readonly IDoctorAppointmentTimesDb db;

        public DoctorAppointmentTimesController(IDoctorAppointmentTimesDb db)
        {
            this.db = db;
        }

        [HttpGet("{doctorId}/availableTimesFor/{date}")]
        public async Task<ActionResult<List<long>>> getAvailableTimesForDate(string doctorId, long date)
        {
            return await db.getAvailableTimesForDay(doctorId, date);
        }

        [HttpGet("{doctorId}")]
        public async Task<ActionResult<DoctorAppointmentTimes>> getDATForDoctor(string doctorId)
        {
            DoctorAppointmentTimes dat = await db.getDoctorAppointmentTimes(doctorId);
            if (dat == null)
                return NotFound();
            return dat;
        }

        [HttpPost("{doctorId}")]
        public async Task<ActionResult> postDAT(String doctorId, List<long> dat)
        {
            bool x = await db.postDAT(doctorId, dat);

            if(x)
            {
                return Accepted();
            }
            return Conflict();
        }

        [HttpPut]
        public async Task<ActionResult> putDAT(DoctorAppointmentTimes dat)
        {
            bool x = await db.putDAT(dat);
            if (x)
                return Accepted();
            return Conflict();
        }
    }
}