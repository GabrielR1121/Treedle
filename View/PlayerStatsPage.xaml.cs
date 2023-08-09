using Mopups.Services;
using System.Collections.ObjectModel;
using Treedle.Model;

namespace Treedle.View;

public partial class PlayerStatsPage
{
    public List<string> WordList { get; } = new();
    public PlayerStatsPage(string correct, List<string>wordList)
	{
		InitializeComponent();
        WordList = wordList;

		correctword.Text = correct;

		
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new GamePage(WordList));
		await MopupService.Instance.PopAsync();
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
        await MopupService.Instance.PopAsync();
    }
}