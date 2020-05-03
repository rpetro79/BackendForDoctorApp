using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Backend.Provider
{
    public class CitiesProvider : ICitiesProvider
    {
        private readonly string countriesUrl = "countries";
        private readonly string citiesUrl = "cities/";
        private readonly string statesUrl = "states/";
        private readonly string authUrl = "getaccesstoken";
        private readonly Uri baseUri = new Uri("https://www.universal-tutorial.com/api/");
        private string authorization;
        private HttpClient client;

        public CitiesProvider()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = baseUri;
            getAuthorization().GetAwaiter().GetResult();
        }

        private async Task getAuthorization()
        {
            setupClientForAuthorization();

            string response = await client.GetStringAsync(authUrl);
            AuthenticationModel am = JsonConvert.DeserializeObject<AuthenticationModel>(response);
            authorization = "Bearer " + am.authenticationString;

            setupClientAfterAuthorization();
        }

        public async Task<List<string>> getCountries()
        {
            HttpResponseMessage response = await client.GetAsync(countriesUrl);

            if (!response.IsSuccessStatusCode)
            {
                response = await client.GetAsync(countriesUrl);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
            }

            string content = await response.Content.ReadAsStringAsync();

            List<CountryModel> responseCountries = JsonConvert.DeserializeObject<List<CountryModel>>(content);
            List<string> toReturnCountries = new List<string>();
            foreach(CountryModel c in responseCountries)
            {
                toReturnCountries.Add(c.countryName);
            }
            return toReturnCountries;
        }

        public async Task<List<string>> getRegions(string country)
        {
            HttpResponseMessage response = await client.GetAsync(statesUrl + country);

            if (!response.IsSuccessStatusCode)
            {
                response = await client.GetAsync(statesUrl + country);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
            }

            string content = await response.Content.ReadAsStringAsync();
            List<StateModel> states = JsonConvert.DeserializeObject<List<StateModel>>(content);
            List<string> toReturn = new List<string>();

            foreach (StateModel state in states)
            {
                toReturn.Add(state.state);
            }

            return toReturn;
        }

        public async Task<List<string>> getCities(string region)
        {
            HttpResponseMessage response = await client.GetAsync(citiesUrl + region);

            if (!response.IsSuccessStatusCode)
            {
                response = await client.GetAsync(citiesUrl + region);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
            }

            string content = await response.Content.ReadAsStringAsync();
            List<CityModel> cities = JsonConvert.DeserializeObject<List<CityModel>>(content);
            List<string> toReturnCities = new List<string>();

            foreach (CityModel city in cities)
            {
                toReturnCities.Add(city.city);
            }

            toReturnCities.Sort();
            return toReturnCities;
        }

        private void setupClientForAuthorization()
        {
            client.DefaultRequestHeaders.Add("api-token", "S5P6PLFnPOha7MM_LZu7JIjZLmyhw0gdNFiRqihIw8IaS_jfz6qdnQ-SfSpMXy8Akvc");
            client.DefaultRequestHeaders.Add("user-email", "ralucapetrovici10@gmail.com");
            if(client.DefaultRequestHeaders.Contains("Authorization"))
                client.DefaultRequestHeaders.Remove("Authorization");
        }

        private void setupClientAfterAuthorization()
        {
            client.DefaultRequestHeaders.Remove("api-token");
            client.DefaultRequestHeaders.Remove("user-email");
            client.DefaultRequestHeaders.Add("Authorization", authorization);
        }
    }
}
