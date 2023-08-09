using Treedle.ViewModel;

namespace Treedle.View;
/**
 * Game Page View
 * 
 * This Page is binded to the GameViewModel Class that holds all execution commands
 */
public partial class GamePage : ContentPage
{
	//Constructor that receives the created wordlist to save time from loading and reloading the list
	public GamePage(List<string> wordList)
	{
		InitializeComponent();

		BindingContext = new GameViewModel(wordList);

		
	}
}