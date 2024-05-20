using CLDB.Services;
using Models;

namespace DivisoMauiOPG.Views
{
    public partial class AdressesPage : ContentPage
    {
        private ApiService apiService { get; set; }

        public List<Address> AddressList { get; set; }

        public AdressesPage()
        {
            apiService = new ApiService();
        }

        private async Task search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchTxt = "";

            if (!string.IsNullOrEmpty(search.Text)) 
            {
                searchTxt = search.Text;
            }
            else
            {
                return;
            }

            AddressList = await apiService.GetAdresses(searchTxt);
        }
    }
}
