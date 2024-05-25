using CLBL.Repository;
using CommunityToolkit.Maui.Alerts;
using DivisoMauiOPG.Views;
using Models;

namespace DivisoMauiOPG
{
    public partial class MainPage : ContentPage
    {
        public Repo Repo { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Repo = new Repo(); 
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            //
            bool loginResult = await Repo.Login(loginEntry.Text);

            if (loginResult) { await Navigation.PushAsync(new AdressesPage()); }
            else { await this.DisplaySnackbar("Erorr"); }
        }
    }
}
