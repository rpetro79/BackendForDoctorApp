using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DbManagement;
using Backend.DbModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationsController : ControllerBase
    {
        private readonly ISpecializationsDb specializationsDb;

        public SpecializationsController(ISpecializationsDb specializationsDb)
        {
            this.specializationsDb = specializationsDb;
        }

        [HttpGet]
        public async Task<List<string>> getSpecializations()
        {
            return await specializationsDb.getSpecializationsAsync();
        }
    }
}