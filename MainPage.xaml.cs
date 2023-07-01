namespace Treedle;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void btn_play_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new playGame());
    }

    private void login_Clicked(object sender, EventArgs e)
    {

    }

    private void how_Clicked(object sender, EventArgs e)
    {

    }
}

