using Mopups.Services;
using System.Collections.ObjectModel;
using Treedle.Model;
using Treedle.Service;
using Treedle.View;
using Treedle.ViewModel;

namespace Treedle;

public partial class MainPage : ContentPage
{

    WordService wordService;

    public ObservableCollection<Word> OriginalList { get; } = new();

    public List<string> WordList { get; } = new();

    public MainPage()
	{
        wordService = new WordService();

        Task.Run(fillWordList);

		InitializeComponent();
	}

    private async void btn_play_Clicked(object sender, EventArgs e)
    {
        if(WordList.Count > 0) 
            await Navigation.PushAsync(new GamePage(WordList));
    }

    public async Task fillWordList()
    {
        var jsonlist = await wordService.GetWords();

        foreach (var word in jsonlist)
            WordList.Add(word.word);

    }

    private void login_Clicked(object sender, EventArgs e)
    {

    }

    private void how_Clicked(object sender, EventArgs e)
    {

    }
}

