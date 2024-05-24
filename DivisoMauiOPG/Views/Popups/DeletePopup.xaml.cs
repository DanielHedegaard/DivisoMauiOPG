using CommunityToolkit.Maui.Views;

namespace DivisoMauiOPG.Views.Popups;

public partial class DeletePopup : Popup
{
	public DeletePopup()
	{
		InitializeComponent();
	}

    private void noBtn_Clicked(object sender, EventArgs e)
    {
		this.Close();
    }

    private void yesBtn_Clicked(object sender, EventArgs e)
    {
        //call delete - get item selected
    }
}