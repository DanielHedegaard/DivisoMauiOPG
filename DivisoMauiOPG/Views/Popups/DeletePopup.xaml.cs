using CLBL;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Alerts;
namespace DivisoMauiOPG.Views.Popups;

public partial class DeletePopup : Popup
{
    private string Id;

    public AdressesPage AdPage{ get; set; } 

    public DeletePopup(string id, AdressesPage adPage)
	{
		InitializeComponent();
        
        Id = id;
        AdPage = adPage;
    }

    private void noBtn_Clicked(object sender, EventArgs e)
    {
		this.Close();
    }

    private async void yesBtn_Clicked(object sender, EventArgs e)
    {
        int delId = 0;

        try
        {
            delId = Convert.ToInt32(Id);
        }
        catch 
        {
            //validation
            return;
        }

        bool result = await AdPage.DeleteAddress(delId);

        await AdPage.SeedAdressList(AddressConnection.LocalConn);
        this.Close();
    }
}