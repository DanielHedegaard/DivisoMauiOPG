using CLDB.Interfaces;
using Models;
using System.Net.Http.Json;

namespace CLDB.Services
{
    public class ApiService : IApiService
    {
        private readonly string _apiRoot;
        private readonly HttpClient _httpClient;
        
        public ApiService()
        {
            _apiRoot = "https://api.dataforsyningen.dk";
            _httpClient = new HttpClient();
        }

        private async Task<bool> IsApiAlive()
        {
            var uri = $"{_apiRoot}";

            return true;
        }

        public async Task<List<Address>> GetAdresses(string searchKeyWord)
        {
            if (!await IsApiAlive())
            {
                return null;
            }

            //before check search string uri= ?postnr=1234

            var uri = $"{_apiRoot}/adgangsadresser/autocomplete?q={searchKeyWord}";

            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<Address>>(uri);

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
