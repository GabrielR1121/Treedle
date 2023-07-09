namespace Treedle;

public partial class PlayerStats
{
    /**
     * This is a Pop Up window meant to show the player statistics.
     */
	public PlayerStats(string MysteryWord)
	{
		InitializeComponent();

        //Displays the Mystery Word. This is temporary while i make another popup
        MysteryLabel.Text = "The word was: "+ MysteryWord;
	}

    /**
     * When the play Again button is pressed restart the game and close the window
     */
    private void Button_Clicked(object sender, EventArgs e)
    {
        playGame.startGame();
        Close();
    }
}