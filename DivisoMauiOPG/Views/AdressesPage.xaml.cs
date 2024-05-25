using CLBL.Repository;
using CLDB.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using DivisoMauiOPG.Views.Popups;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WebModels;

namespace DivisoMauiOPG.Views
{
    public partial class AdressesPage : ContentPage, INotifyPropertyChanged
    {
        private ApiService apiService { get; set; }
        private Repo repo { get; set; }

        public bool searchTabActive { get; set; }
        private ObservableCollection<DawaAddress> addressList { get; set; } = new();
        public ObservableCollection<DawaAddress> AddressList
        {
            get => addressList;
            set
            {
                if (addressList != value)
                {
                    addressList = value;
                    OnPropertyChanged();
                }
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        //
        public ICommand SearchCommand { get; }

        public AdressesPage()
        {
            InitializeComponent();

            BindingContext = this;
            //SearchCommand = new Command(OnSearch);

            apiService = new ApiService();
            repo = new Repo();


        }

        private async void AddressListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DawaAddress dw = e.SelectedItem as DawaAddress;

            if (searchTabActive)
            {
                bool result = await repo.AddAdress(dw);

                if (result)
                {
                    await this.DisplaySnackbar("Adressen er blevet gemt!");
                }
            }

            //saved tab
            else
            {
                this.ShowPopup(new DeletePopup(dw.adgangsadresse.id, this));
            }
        }

        private void searchTabBtn_Clicked(object sender, EventArgs e)
        {
            searchTabActive = true;

            AddressList.Clear();

            SearchTabBtnActive();
        }

        private async void savedTabBtn_Clicked(object sender, EventArgs e)
        {
            searchTabActive = false;

            savedTabBtn.BackgroundColor = Color.FromRgba("#002b4e");
            savedTabBtn.TextColor = Colors.White;

            searchTabBtn.BackgroundColor = Colors.White;
            searchTabBtn.TextColor = Color.FromRgba("#002b4e");
            searchTabBtn.BorderColor = Color.FromRgba("#002b4e");

            await SeedAdressList(AddressConnection.LocalConn);
        }
        private async void searchBtn_Clicked(object sender, EventArgs e)
        {
            searchTabActive = true;

            SearchTabBtnActive();

            await SeedAdressList(AddressConnection.DawaConn);
        }

        private void SearchTabBtnActive()
        {
            searchTabBtn.BackgroundColor = Color.FromRgba("#002b4e");
            searchTabBtn.TextColor = Colors.White;

            savedTabBtn.BackgroundColor = Colors.White;
            savedTabBtn.TextColor = Color.FromRgba("#002b4e");
        }

        public async Task SeedAdressList(AddressConnection addressConn)
        {
            AddressList.Clear();

            if (addressConn == AddressConnection.LocalConn)
            {
                List<DawaAddress> dawaAddressList = await repo.GetAllAddresses();

                if (dawaAddressList == null) { return; }

                AddressList = new ObservableCollection<DawaAddress>(dawaAddressList);
            }
            else
            {
                string searchTxt = search?.Text;

                if (string.IsNullOrEmpty(searchTxt))
                {
                    return;
                }

                AddressList = new ObservableCollection<DawaAddress>(await apiService.GetAdresses(searchTxt));
            }
        }

        public async Task<bool> DeleteAddress(int id)
        {
            return await repo.DeleteAdresses(id);
        }

        public new void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        
        
    }
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
