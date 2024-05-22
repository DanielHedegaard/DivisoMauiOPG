using CLBL;
using CLDB.Services;
using WebModels;

namespace DivisoMauiOPG.Views
{
    public partial class AdressesPage : ContentPage
    {
        private ApiService apiService { get; set; }

        private Repo repo { get; set; }

        public List<DawaAddress> AddressList { get; set; }

        //public ICommand SearchCommand{ get; }

        public AdressesPage()
        {
            InitializeComponent();

            BindingContext = this;
            //SearchCommand = new Command(OnSearch);
            apiService = new ApiService();
            repo = new Repo();
        }

        //Fix search func debounce
        //private async void OnSearch()
        //{
        //    string searchTxt = search?.Text;

        //    if (string.IsNullOrEmpty(searchTxt))
        //    {
        //        return;
        //    }

        //    AddressList = await apiService.GetAdresses(searchTxt);
        //}

        private async void searchBtn_Clicked(object sender, EventArgs e)
        {
            

            SeedAdressList(AddressConn.DawaConn);
        }

        private async void saved_Clicked(object sender, EventArgs e)
        {
            SeedAdressList(AddressConn.LocalConn);
        }

        private async void SeedAdressList(AddressConn addressConn)
        {
            AddressResults.Children.Clear();

            if (addressConn == AddressConn.LocalConn)
            {
                AddressList = await repo.GetAllAddresses();
            }
            else
            {
                string searchTxt = search?.Text;

                if (string.IsNullOrEmpty(searchTxt))
                {
                    return;
                }

                AddressList = await apiService.GetAdresses(searchTxt);
            }

            if (AddressList == null) { return; }

            foreach (var address in AddressList)
            {
                AddressResults.Children.Add(new Label { Text = address.tekst });
            }
        }

        private enum AddressConn
        {
            LocalConn,
            DawaConn
        }
    }
}
