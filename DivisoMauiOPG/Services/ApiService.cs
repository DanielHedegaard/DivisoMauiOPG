using CLDB.Interfaces;
using System.Net.Http.Json;

namespace CLDB.Services
{
    public class ApiService : IApiService
    {
        private readonly string _apiRoot;
        private readonly HttpClient _httpClient;
        
        public ApiService()
        {
            _apiRoot = "http://wwww.localhost:1234";
            _httpClient = new HttpClient();
        }

        public async Task<List<string>> GetAdresses(string searchKeyWord)
        {
            var uri = $"{_apiRoot}/address?keyword={searchKeyWord}";

            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<string>>(uri);

                return result;
            }
            catch
            {
                return null;
            }
        }

        //public async Task<bool> AddAdress(string address)
        //{
        //    var uri = $"{_apiRoot}/address";

        //    try
        //    {
        //        var result = await _httpClient.PostAsJsonAsync(uri, address);

        //        return result.IsSuccessStatusCode;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> DeleteAdresses(int id)
        //{
        //    var uri = $"{_apiRoot}/address?={id}";

        //    try
        //    {
        //        var result = await _httpClient.DeleteAsync(uri);

        //        return result.IsSuccessStatusCode;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
