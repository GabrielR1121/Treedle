using System.Collections.ObjectModel;
using Treedle.Model;
using Treedle.Service;
using Treedle.View;

namespace Treedle;
/**
 * Main Page View Class
 */
public partial class MainPage : ContentPage
{
    //Creates instance of word service
    WordService wordService;

    //TEmporary list to store word objects
    public ObservableCollection<Word> OriginalList { get; } = new();

    //List to store all string versions of the WordList
    public List<string> WordList { get; } = new();

    public MainPage()
	{
        //Sets instance of Wordservice class to new WordSevice
        wordService = new WordService();

        //Runs asynchronously the task to fill the world list
        Task.Run(fillWordList);

		InitializeComponent();
	}
    /**
     * Button to start the game
     */
    private async void btn_play_Clicked(object sender, EventArgs e)
    {
        //If the word list is empty dont allow the button to be executed.
        if(WordList.Count > 0) 
            await Navigation.PushAsync(new GamePage(WordList));
    }
    /**
     * Task to fill the word list using an instance w=of Word Service
     */
    public async Task fillWordList()
    {
        var jsonlist = await wordService.GetWords();

        foreach (var word in jsonlist)
            WordList.Add(word.word);

    }
}

