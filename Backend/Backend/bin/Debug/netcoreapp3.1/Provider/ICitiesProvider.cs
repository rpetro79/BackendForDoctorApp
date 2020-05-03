using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Provider
{
    public interface ICitiesProvider
    {
        Task<List<string>> getCountries();
        Task<List<string>> getCities(string countryName);
        Task<List<string>> getRegions(string country);
    }
}
