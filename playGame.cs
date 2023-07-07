using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Collections.Generic;

namespace Treedle;
/**
 * TO-DO: 
 *      * Figure out if there is a way to add a loading screen or soemthing between MainPage and playGame.
 */
public partial class playGame : ContentPage
{
    int currentRow = 0;
    int currentColumn = 0;
    string MysteryWord = "APART";
    string guessWord = null;
    Grid gameGrid = null;

    public playGame()
    {
        //Creates the title information at the top of the screen.
        createTitle();

        //Creates the verticle layout that holds the items in the page
        VerticalStackLayout verticalStackLayout = new VerticalStackLayout {
            BackgroundColor = Colors.Black };



        //Adds the game grid to the vertical layout
        gameGrid = createGameGrid();
        verticalStackLayout.Add(gameGrid);

        //Adds all three rows of the keyboard to the vertical layout
        for (int keyboardRow = 0; keyboardRow < 3; keyboardRow++)
            verticalStackLayout.Add(createKeyboardGrid(keyboardRow));

        //Adds the vertical layout contents to the Content Page
        Content = verticalStackLayout;


    }
    /**
     * Adds cosmetics and proper settings to Navigation Page.
     */
    public void createTitle()
    {
        //Sets the title to Treedle
        NavigationPage.SetTitleView(this, new Label
        {
            Text = "Treedle",
            FontSize = 50,
            TextColor = Colors.White,
            HorizontalOptions = LayoutOptions.Center
        });

        //Removes the back button from the navigation bar.
        NavigationPage.SetHasBackButton(this, false);
    }
    /**
     * Creates the grid system in treedle. 
     * Creates all 6 rows and 5 Columns 
     */
    public Grid createGameGrid()
    {
        var len = 1;
        //Creates the grid with the appropriate cosmetics and settings
        Grid grid = new Grid
        {
            Margin = new Thickness(0, 40, 0, 90),
            ColumnSpacing = 10,
            RowSpacing = 10,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,


            RowDefinitions =
            {
                new RowDefinition( new GridLength(len, GridUnitType.Auto) ),
                new RowDefinition(new GridLength(len,GridUnitType.Auto) ),
                new RowDefinition(new GridLength(len,GridUnitType.Auto) ),
                new RowDefinition(new GridLength(len, GridUnitType.Auto)),
                new RowDefinition(new GridLength(len,GridUnitType.Auto) ),
                new RowDefinition(new GridLength(len,GridUnitType.Auto) )
            },
            ColumnDefinitions =
            {
                new ColumnDefinition(new GridLength(len,GridUnitType.Auto) ),
                new ColumnDefinition(new GridLength(len, GridUnitType.Auto)),
                new ColumnDefinition(new GridLength(len,GridUnitType.Auto) ),
                new ColumnDefinition(new GridLength(len,GridUnitType.Auto) ),
                new ColumnDefinition(new GridLength(len,GridUnitType.Auto) )
            }
        };

        //Creates each grid by making using the createBorder and createLabel Message.
        for (int row = 0; row < 5; row++)
            for (int col = 0; col < 6; col++)
                grid.Add(createBorder(createLabel("W",true, Colors.Black), Colors.Black), row, col);


        return grid;

    }

    /**
     * Creates a default label that holds a default element of X.
     * W string is created to maintain box shape while user inputs letters of their own.
     * Receives either a default letter for the label or the letter the user pressed on the keyboard and 
     * a boolean to ask if the label should have a background color or not.
     * Returns a Label Object.
     */
    public Label createLabel(string letter, Boolean hasBackgroundColor, Color color)
    {
        if (hasBackgroundColor)
        {
            return new Label
            {
                Text = letter,
                LineBreakMode = LineBreakMode.CharacterWrap,
                TextColor = color,
                BackgroundColor = color,
                FontSize = 39,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center


            };
        }
        else {

             return new Label
            {
                Text = letter,
                LineBreakMode = LineBreakMode.CharacterWrap,
                TextColor = Colors.White,
                FontSize = 39,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

        }
    }
    /**
     * Creates a border for each created label with the approriate cosmetics and size settings.
     * Receives a label Object. 
     * Returns a Border Object with a label inside.
     */
    public Border createBorder(Label label, Color color)
    {
        return new Border
        {
            Content = label,
            BackgroundColor = color,
            Stroke = Color.FromArgb("#787c7f"),
            StrokeThickness = 2,
            Padding = new Thickness(30, 15),
            HorizontalOptions = LayoutOptions.Center,

        };
    }
    /**
     * Creates the keyboard grid.
     * Receives the row number of the keyboard. 
     * Returns the grid of buttons for the assigned row
     */
    public Grid createKeyboardGrid(int rowNumber)
    {
        //Keyboard design 
        Grid grid = new Grid
        {
            ColumnSpacing = 10,
            RowSpacing = 10,
            Margin = new Thickness(3),
            Padding = new Thickness(35, 0, 35, 0),
            HorizontalOptions = LayoutOptions.Center,
            RowDefinitions =
            {
                new RowDefinition()

            },
            ColumnDefinitions =
            {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition(),
            }
        };

        //List of List to create the row of letters of the keyboard.
        List<List<string>> myList = new List<List<string>>();
        myList.Add(new List<string> { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" });
        myList.Add(new List<string> { "A", "S", "D", "F", "G", "H", "J", "K", "L" });
        myList.Add(new List<string> { "Enter", "Z", "X", "C", "V", "B", "N", "M", "Delete" });

        int col = 0;
        foreach (string item in myList[rowNumber])
            grid.Add(createButton(item), col++, rowNumber);



        return grid;
    }
    /**
     * Creates a keyboard button. 
     * Receives the keyboard letter
     * Returns the button with the designated cosmetics and settings
     */
    public Button createButton(string letter)
    {
        var Button = new Button { };

        if (letter.CompareTo("Enter") == 0 || letter.CompareTo("Delete") == 0)
            Button = new Button
            {
                Text = letter,
                WidthRequest = 70,
                FontSize = 13,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.White,
                BackgroundColor = Color.FromArgb("#787c7f")
            };
        else
            Button = new Button
            {
                Text = letter,
                FontSize = 20,
                WidthRequest = 50,
                HeightRequest = 50,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.FromArgb("#787c7f")
            };

        if (Button.Text.CompareTo("Enter") == 0)
            Button.Clicked += Enter_Clicked;
        else if (Button.Text.CompareTo("Delete") == 0)
            Button.Clicked += Delete_Clicked;
        else
            Button.Clicked += Letter_Clicked;

        return Button;
    }
    /**
     * Action listener for when a letter key from the keyboard is pressed.
     */
    private void Letter_Clicked(object sender, EventArgs e) { 

        var clickedLetter = (sender as Button).Text;
    
        updateGrid(clickedLetter);

        guessWord += clickedLetter;
    }

    /**
    * Action listener for when the enter key is pressed.
    */
    private void Enter_Clicked(object sender,EventArgs e)
    {
        if (currentColumn == 5)
        {
            Dictionary<string, int> Guess = new Dictionary<string, int>();
            Dictionary<string, int> Mystery = new Dictionary<string, int>();

            for (int i = 0; i < guessWord.Length; i++)
                    if (Guess.ContainsKey(guessWord[i].ToString()))
                        Guess[guessWord[i].ToString()] += 1;
                    
                    else
                        Guess.Add(guessWord[i].ToString(), 1);


            for (int i = 0; i < MysteryWord.Length; i++)
                if (Mystery.ContainsKey(MysteryWord[i].ToString()))
                    Mystery[MysteryWord[i].ToString()] += 1;

                else
                    Mystery.Add(MysteryWord[i].ToString(), 1);


            for (int i = 0; i < guessWord.Length; i++)
                if (guessWord[i].CompareTo(MysteryWord[i]) == 0)
                {
                    Guess[guessWord[i].ToString()] -= 1;
                    gameGrid.Add(createBorder(createLabel("W", true, Color.FromArgb("#6ca965")), Color.FromArgb("#6ca965")), i, currentRow);
                    gameGrid.Add(createLabel(guessWord[i].ToString(), false, Colors.Black), i, currentRow);

                }
                else if (Mystery.ContainsKey(guessWord[i].ToString()) && Mystery[guessWord[i].ToString()] >= Guess[guessWord[i].ToString()])
                {
                    Guess[guessWord[i].ToString()] -= 1;
                    gameGrid.Add(createBorder(createLabel("W", true, Color.FromArgb("#c8b653")), Color.FromArgb("#c8b653")), i, currentRow);
                    gameGrid.Add(createLabel(guessWord[i].ToString(), false, Colors.Black), i, currentRow);
                }
                else
                {
                    gameGrid.Add(createBorder(createLabel("W", true, Color.FromArgb("#787c7f")), Color.FromArgb("#787c7f")), i, currentRow);
                    gameGrid.Add(createLabel(guessWord[i].ToString(), false, Colors.Black), i, currentRow);
                }
            guessWord = null;
            currentColumn = 0;
            currentRow += 1;
        }

    }

    /**
    * Action listener for when the delete key is pressed.
    */
    private void Delete_Clicked(object sender,EventArgs e)
    {
        if (currentColumn != 0)
            gameGrid.Add(createBorder(createLabel("W", true, Colors.Black), Colors.Black), --currentColumn, currentRow);

        else
            gameGrid.Add(createBorder(createLabel("W", true, Colors.Black), Colors.Black), currentColumn, currentRow);

        guessWord = guessWord.Remove(guessWord.Length-1);
    }

    /**
     * Updates the grid when a button is pressed. The action done depends on what key was pressed.
     * Receives the letter the user clicked on in the keyboard.
     */
    public void updateGrid(string letter)
    {
        if(currentColumn < 5)
            gameGrid.Add(createLabel(letter,false, Colors.Black), currentColumn++, currentRow);


               
    }
}