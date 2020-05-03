using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Provider;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICitiesProvider provider;

        public CountriesController(ICitiesProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> getCountries()
        {
            List<string> countries =  await provider.getCountries();
            if (countries == null)
                return NotFound();
            return countries;
        }

        [HttpGet("{country}/{region}")]
        public async Task<ActionResult<List<string>>> getCountries(string country, string region)
        {
            List<string> cities = await provider.getCities(region);
            if (cities == null)
                return NotFound();
            return cities;
        }

        [HttpGet("{country}")]
        public async Task<ActionResult<List<string>>> getRegions(string country)
        {
            List<string> regions = await provider.getRegions(country);
            if (regions == null)
                return NotFound();
            return regions;
        }
    }
}