using Treedle.ViewModel;

namespace Treedle.View;

public partial class GamePage : ContentPage
{
	
	public GamePage(List<string> wordList)
	{
		InitializeComponent();

		BindingContext = new GameViewModel(wordList);

		
	}
}