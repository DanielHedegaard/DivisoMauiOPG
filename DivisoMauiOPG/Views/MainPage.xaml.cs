using DivisoMauiOPG.Views;

namespace DivisoMauiOPG
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AdressesPage());
        }
    }
}
