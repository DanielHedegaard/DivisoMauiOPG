using CLDB.Interfaces;
using System.Net.Http.Json;
using WebModels;

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

        private bool IsApiAlive()
        {
            var uri = $"{_apiRoot}";

            return true;
        }

        public async Task<List<DawaAddress>> GetAdresses(string searchKeyWord)
        {
            if (!IsApiAlive())
            {
                return null;
            }

            //before check search string uri= ?postnr=1234

            var uri = $"{_apiRoot}/adgangsadresser/autocomplete?q={searchKeyWord}";

            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<DawaAddress>>(uri);

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
